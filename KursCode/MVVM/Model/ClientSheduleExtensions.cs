using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model
{
    public static class ClientSheduleExtensions
    {
        public static string ToStringLocalized(this ClientShedule value)
        {
            switch (value)
            {
                case ClientShedule.Full:
                    return "Полный день";
                case ClientShedule.Flexible:
                    return "Гибкий график";
                case ClientShedule.Removable:
                    return "Сменный график";
                case ClientShedule.Remote:
                    return "Удаленная работа";
                default:
                    return value.ToString();
            }
        }
    }
}
