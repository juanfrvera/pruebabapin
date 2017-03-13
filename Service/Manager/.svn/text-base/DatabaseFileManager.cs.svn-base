using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Service;
using System.Data.SqlClient;
using Business;

namespace Service
{


    public class DatabaseFileManager :IFileManager
    {
        #region singleton
        private static readonly object padlock = new object();
        private static DatabaseFileManager current;
        private DatabaseFileManager() { }
        public static DatabaseFileManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new DatabaseFileManager();
                    }
                return current;
            }
        }
        #endregion

        public FileInfo Upload(string folder,string fileName, string fileType, byte[] fileData,IContextUser contextUser)
        {
            return Upload(folder,fileName, fileType, DateTime.Now, fileData, contextUser);
        }
        public FileInfo Upload(string folder,string fileName,string fileType,DateTime? fileDate,byte[] fileData ,IContextUser contextUser)
        {
            FileInfo fileInfo= FileInfoService.Current.GetNew();
            fileInfo.FileName = fileName;
            fileInfo.FileType = fileType;
            fileInfo.Folder = folder;
            fileInfo.Data = new Binary(fileData);
            fileInfo.Date = fileDate.HasValue?fileDate:DateTime.Now;
            fileInfo.Checked = false;
            FileInfoService.Current.Add(fileInfo,contextUser);
            return fileInfo;
        }

        public FileInfo Download(string folder, string fileName)
        {
            return Download(folder, fileName, null);
        }
        public FileInfo Download(string folder, string fileName, int? fileVersion)
        {
            return FileInfoService.Current.FirstOrDefault(new FileInfoFilter() { Folder = folder, FileName = fileName, FileVersion = fileVersion, FileVersion_To = fileVersion, OrderByProperty = "FileVersion", OrderByDesc =true });
        }
        public FileInfo Download(int fileInfoId)
        {
            return FileInfoService.Current.GetById(fileInfoId);
        }
    }
}
