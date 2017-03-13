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
using System.IO;

namespace Service
{


    public class DirectoryFileManager :IFileManager
    {
        #region singleton
        private static readonly object padlock = new object();
        private static DirectoryFileManager current;
        private DirectoryFileManager() { }
        public static DirectoryFileManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new DirectoryFileManager();
                    }
                return current;
            }
        }
        #endregion

        #region methods

        #region Public
        public nc.FileInfo Upload(string folder,string fileName, string fileType, byte[] fileData,IContextUser contextUser)
        {
            return Upload(folder,fileName, fileType, DateTime.Now, fileData, contextUser);
        }
        public nc.FileInfo Upload(string folder,string fileName,string fileType,DateTime? fileDate,byte[] fileData ,IContextUser contextUser)
        {
            nc.FileInfo fileInfo= FileInfoService.Current.GetNew();
            fileInfo.Folder = folder;
            fileInfo.FileName = fileName;
            fileInfo.FileType = fileType;            
            //fileInfo.Data = new Binary(fileData);
            fileInfo.Date = fileDate.HasValue?fileDate:DateTime.Now;
            fileInfo.Checked = false;
            FileInfoService.Current.Add(fileInfo,contextUser);
            File.WriteAllBytes(FilePath(fileInfo), fileData);
            return fileInfo;
        }
        public nc.FileInfo Download(string folder, string fileName)
        {
            return Download(folder, fileName, null);
        }
        public nc.FileInfo Download(string folder, string fileName, int? fileVersion)
        {
            nc.FileInfo fileInfo = FileInfoService.Current.FirstOrDefault(new FileInfoFilter() { Folder = folder, FileName = fileName, FileVersion = fileVersion, FileVersion_To = fileVersion, OrderByProperty = "FileVersion", OrderByDesc = true });
            fileInfo.Data = GetFile(fileInfo);
            return fileInfo;
        }
        public nc.FileInfo Download(int fileInfoId)
        {
            nc.FileInfo fileInfo =FileInfoService.Current.GetById(fileInfoId);
            fileInfo.Data = GetFile(fileInfo);
            return fileInfo;
        }
        #endregion

        #region protecteds
        protected string FilePath(nc.FileInfo fileInfo)
        {
            return Path.Combine(fileInfo.Folder, fileInfo.FileName);
        }
        protected Binary GetFile(nc.FileInfo fileInfo)
        {
            return new Binary(File.ReadAllBytes(FilePath(fileInfo)));
        }
        #endregion

        #endregion
    }
}
