using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public class FileHelper
    {
        public string GetPath(int userid,string nameFile)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            string dbPath = Path.Combine(userFolderPath, $"{userid}_ID_User");
            Directory.CreateDirectory(dbPath);
            string workerDataFilePath = Path.Combine(dbPath, nameFile);
            return dbPath;
        }
    }
}
