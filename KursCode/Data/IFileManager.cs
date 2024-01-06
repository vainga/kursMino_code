using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public interface IFileManager
    {
        string GetLocalPath(string nameFile);
    }
}
