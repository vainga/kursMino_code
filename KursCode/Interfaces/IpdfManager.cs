using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IpdfManager
    {
        byte[] SelectPDF();
        byte[] fromBase64toPdf(string pdfBase64);
        string toBase64(byte[] pdfBytes);
    }
}
