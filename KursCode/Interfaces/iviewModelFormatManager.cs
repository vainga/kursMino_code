using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface iviewModelFormatManager
    {
        string FormatLetter(string input);
        string FormatNumeric(string input);
        string FormatPhoneNumber(string input);
        string RemoveSpaces(string input);
    }
}
