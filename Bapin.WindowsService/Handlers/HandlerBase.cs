using Core.Extensions;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Bapin.WindowsService.Handlers
{
    public abstract class HandlerBase
    {
        //private static string endpoint;
        private readonly object syncHandler = new object();
        private int pollingInterval;
        private DateTime? scheduledTime;
        private static readonly ILog Log = LogManager.GetLogger(typeof(HandlerBase));

        public HandlerBase(string name, int pollingInterval, DateTime? scheduledTime)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("A name should be provided for the handler");

            PollingInterval = pollingInterval;
            Name = name;
            if (scheduledTime.HasValue)
            {
                ScheduledTime = scheduledTime;
            }

            //var client = new BaseClient();
            //endpoint = client.Endpoint;
        }

        public event BapinService.StatusUpdatedEventHandler StatusUpdated = (isError, messageText) =>
        {
            // snip
        };

        public string Name { get; private set; }

        public bool Enabled
        {
            get { return Thread != null; }
        }

        public int PollingInterval
        {
            get
            {
                return pollingInterval;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("PollingInterval should be at least 1");
                }

                pollingInterval = value;
            }
        }

        public DateTime? ScheduledTime
        {
            get
            {
                return scheduledTime;
            }

            set
            {
                scheduledTime = value;
            }
        }

        private Thread Thread { get; set; }

        public void StopProcess()
        {
            lock (syncHandler)
            {
                if (!Enabled) return;
                Thread.Abort();
                Thread = null;
            }
        }

        public void StartProcess()
        {
            lock (syncHandler)
            {
                if (Enabled) return;

                // Create the new thread and start it
                Thread = new Thread(DoThreadedProcessing)
                {
                    Name = Name.CaseSeparate(),
                    IsBackground = true,
                };

                Thread.Start();
            }
        }

        protected virtual void OnStatusUpdated(bool isError, string messageText)
        {
            StatusUpdated(isError, messageText);
        }

        protected abstract void DoProcess();

        private void DoThreadedProcessing()
        {
            try
            {
                // Stay on this thread until aborted
                while (true)
                {
                    Console.WriteLine("Bapin Service TryDoProcess...");

                    if (!scheduledTime.HasValue)
                    {
                        TryDoProcess();
                        Thread.Sleep(PollingInterval * 1000);
                    }
                    else 
                    {
                        //if (DateTime.Now.Hour == scheduledTime.Value.Hour && DateTime.Now.Minute == scheduledTime.Value.Minute)
                        if (DateTime.Now >= scheduledTime.Value)
                        {
                            //If Scheduled Time is passed set Schedule for the next day.
                            scheduledTime = scheduledTime.Value.AddDays(1);

                            OnStatusUpdated(false, this.Name + " start running. Next run: " + scheduledTime.Value);

                            TryDoProcess();
                        }

                        try
                        {
                            Thread.Sleep((int)(scheduledTime.Value - DateTime.Now).TotalSeconds * 1000);
                        }
                        catch (System.Threading.ThreadAbortException)
                        {
                            OnStatusUpdated(false, "Thread Aborted");
                        }                      
                    }
                }
            }
            catch (ThreadAbortException ex)
            {
                Log.Error(ex);
            }
        }

        private void TryDoProcess()
        {
            try
            {
                DoProcess();
            }
            catch (Exception ex)
            {
                OnStatusUpdated(true, "An unhandled exception occurred.");
                OnStatusUpdated(true, BapinService.BuildErrorDetails(ex));
            }
        }

        private bool UrlIsResponding(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 60000;
            request.Method = "GET"; // HEAD?
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (TaskCanceledException te)
            {
                // Check ex.CancellationToken.IsCancellationRequested here.
                // If false, it's pretty safe to assume it was a timeout.
                if (te.CancellationToken.IsCancellationRequested)
                {
                    //Error("TaskCanceledException Is Cancellation Requested");
                }
                else
                {
                    //Error("TaskCanceledException assume it was a timeout");
                }

                return false;
            }
            catch (WebException we)
            {
                //Error("WebException UrlIsResponding ", we);
                Log.Error(we);
                return false;
            }
            catch (Exception e)
            {
                //Error("Exception UrlIsResponding", e);
                Log.Error(e);
                return false;
            }
        }
    }
}
