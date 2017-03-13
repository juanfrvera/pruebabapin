using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Application.Controls
{
    public partial class MessageBar : UserControl, ITextControl, IUserInterfaceMessage
    {

        #region Properties

        public string CssError
        {
            get { return Convert.ToString(ViewState["CssError"], CultureInfo.CurrentCulture); }
            set { ViewState["CssError"] = value; }
        }

        public string CssInfo
        {
            get { return Convert.ToString(ViewState["CssInfo"], CultureInfo.CurrentCulture); }
            set { ViewState["CssInfo"] = value; }
        }

        public string CssWarning
        {
            get { return Convert.ToString(ViewState["CssWarning"], CultureInfo.CurrentCulture); }
            set { ViewState["CssWarning"] = value; }
        }

        public Unit Height
        {
            get { return MessagePanel.Height; }
            set { MessagePanel.Height = value; }
        }

        public Unit Width
        {
            get { return MessagePanel.Width; }
            set { MessagePanel.Width = value; }
        }

        private string _text;

        #endregion

        #region Methods

        public void DisplayError(string message)
        {
            DisplayMessage(message, CssError);
        }

        public void DisplayInfo(string message)
        {
            DisplayMessage(message, CssInfo);
        }

        public void DisplayWarning(string message)
        {
            DisplayMessage(message, CssWarning);
        }

        public void DisplayMessage(string message)
        {
            DisplayMessage(message, null);
        }

        public void DisplayMessage(string message, string cssClass)
        {
            MessageLabel.Text = message;
            MessageLabel.Visible = true;
            MessagePanel.CssClass = cssClass;
            UpdateMessagePanel();
        }

        public void ClearMessage()
        {
            MessageLabel.Text = null;
            MessageLabel.Visible = false;
            MessagePanel.CssClass = null;
            UpdateMessagePanel();
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _text = value;
                    DisplayError(value);
                }
                else
                    _text = String.Empty;
            }
        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.MessageLabel.Text != null)
                //limpia mensaje en cualquier viaje al servidor de la pagina
                this.ClearMessage();

            if (!IsPostBack)
                InitializeControl();

        }



        private void InitializeControl()
        {
            CssError = (string.IsNullOrEmpty(CssError)) ? "error" : CssError;
            CssInfo = (string.IsNullOrEmpty(CssInfo)) ? "info" : CssInfo;
            CssWarning = (string.IsNullOrEmpty(CssWarning)) ? "warning" : CssWarning;
        }


        private void UpdateMessagePanel()
        {
            var panel = FindControl("MessageUpdatePanel") as UpdatePanel;
            if (panel != null) panel.Update();
        }

    }
}