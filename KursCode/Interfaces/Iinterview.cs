using Clients;
using KursCode.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface Iinterview
    {
        public DateTime Date { get; }
        public TimeSpan Time { get; }
        public TimeSpan Duration { get; }
        public workerClass Worker { get; }
        public corporationClass Vacancy { get; }
        bool HasConflict(List<InterviewClass> existingInterviews);
        void AddData(int userid);
        string GetDBPath(int userid);
    }
}
