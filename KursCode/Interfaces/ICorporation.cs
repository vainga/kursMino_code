using KursCode.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface ICorporation
    {
        int CorporationId {  get; }
        int UserId {  get; }
        string CorporationName {  get; }
        List<vacancyClass> Vacancies { get; }
    }
}
