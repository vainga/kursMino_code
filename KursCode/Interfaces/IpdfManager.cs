using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IpdfManager
    {
        public void SelectPDF(string PDF_fileName, string pdfBase64);
    }
}
