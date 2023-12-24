using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model
{
    public static class ClientEmploymentExtensions
    {
        public static string ToStringLocalized(this ClientEmployment value)
        {
            switch (value)
            {
                case ClientEmployment.full:
                    return "Полная";
                case ClientEmployment.partial:
                    return "Частичная";
                case ClientEmployment.internship:
                    return "Стажировка";
                default:
                    return value.ToString();
            }
        }
    }
}
