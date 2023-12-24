using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model
{
    public static class ClientCitizenshipExtensions
    {
        public static string ToStringLocalized(this ClientCitizenship value)
        {
            switch (value)
            {
                case ClientCitizenship.RussianFederation:
                    return "Российская Федерация";
                case ClientCitizenship.Other:
                    return "Другое";
                default:
                    return value.ToString();
            }
        }
    }
}
