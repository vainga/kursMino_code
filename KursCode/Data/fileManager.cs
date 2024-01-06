using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public class fileManager : IFileManager
    {
        public string GetLocalPath(string nameFile)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string endFilePAth = Path.Combine(dataFolderPath, $"{nameFile}");
            return endFilePAth;
        }
    }
}
