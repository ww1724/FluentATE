using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Share
{
    public static class AppFields
    {
        private static string AppName => "Fluent ATE";

        private static string DataFolderName => "Data";

        private static string LocalDataFileName => "data.db";

        private static string LogFolderName => "Log";

        public static string AppPath
        {
            get
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppName);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
        }

        public static string LogFilePath
        {
            get
            {
                string path = Path.Combine(AppPath, LogFolderName);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string filepath = Path.Combine(path, $"{DateTime.Today.ToShortDateString().Replace("/", "-")}.log");
                return filepath;
            }
        }

        public static string LocalDbFilePath
        {
            get
            {
                string dataFolderPath = Path.Combine(AppPath, DataFolderName);
                if (!Directory.Exists(dataFolderPath))
                    Directory.CreateDirectory(dataFolderPath);
                return Path.Combine(dataFolderPath, LocalDataFileName);
            }
        }


    }
}
