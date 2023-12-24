using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model
{
    public static class ClientStatusExtensions
    {
        public static string ToStringLocalized(this ClientStatus value)
        {
            switch (value)
            {
                case ClientStatus.Success:
                    return "Приняты";
                case ClientStatus.atWork:
                    return "В работе";
                case ClientStatus.interviewScheduled:
                    return "Назначено собеседование";
                case ClientStatus.rejected:
                    return "Отклонены";
                default:
                    return value.ToString();
            }
        }
    }
}
