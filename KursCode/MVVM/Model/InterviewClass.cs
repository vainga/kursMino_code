using Clients;
using KursCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using KursCode.Data;

namespace KursCode.MVVM.Model
{
    //[Serializable]
    //public class InterviewClass : Iinterview
    //{
    //    [JsonInclude]
    //    [JsonPropertyName("Date")]
    //    public DateTime Date { get; private set; }
    //    [JsonInclude]
    //    [JsonPropertyName("Time")]
    //    public TimeSpan Time { get; private set; }
    //    [JsonInclude]
    //    [JsonPropertyName("Duration")]
    //    public TimeSpan Duration { get; private set; }
    //    [JsonInclude]
    //    [JsonPropertyName("Worker")]
    //    public workerClass Worker { get; private set; }
    //    [JsonInclude]
    //    [JsonPropertyName("Vacansy")]
    //    public corporationClass Vacancy { get; private set; }

    //    public InterviewClass(DateTime date, TimeSpan time, TimeSpan duration, workerClass worker, corporationClass vacancy)
    //    {
    //        Date = date;
    //        Time = time;
    //        Duration = duration;
    //        Worker = worker;
    //        Vacancy = vacancy;
    //    }

    //    public InterviewClass() 
    //    {
    //        Date = new DateTime();
    //        Time = new TimeSpan();
    //        Duration = new TimeSpan();
    //    }

    //    public bool HasConflict(List<InterviewClass> existingInterviews)
    //    {
    //        DateTime newInterviewStart = Date + Time;

    //        DateTime newInterviewEnd = newInterviewStart + Duration;

    //        foreach (var existingInterview in existingInterviews)
    //        {
    //            DateTime existingInterviewStart = existingInterview.Date + existingInterview.Time;
    //            DateTime existingInterviewEnd = existingInterviewStart + existingInterview.Duration;

    //            if ((newInterviewStart >= existingInterviewStart && newInterviewStart < existingInterviewEnd) ||
    //                (newInterviewEnd > existingInterviewStart && newInterviewEnd <= existingInterviewEnd) ||
    //                (newInterviewStart <= existingInterviewStart && newInterviewEnd >= existingInterviewEnd))
    //            {
    //                return true;
    //            }
    //        }

    //        return false;
    //    }

    //    public string GetDBPath(int userid)
    //    {
    //        string executablePath = AppDomain.CurrentDomain.BaseDirectory;
    //        string parentPath = Directory.GetParent(executablePath).FullName;
    //        string dataFolderPath = Path.Combine(parentPath, "Data");
    //        string userFolderPath = Path.Combine(dataFolderPath, "UserData");
    //        string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userid}_ID_User");
    //        Directory.CreateDirectory(userSpecificFolderPath);
    //        string corporationDataFilePath = Path.Combine(userSpecificFolderPath, "interviews.json");
    //        return corporationDataFilePath;
    //    }

    //    public void AddData(int userid)
    //    {
    //        try
    //        {
    //            string dbPath = GetDBPath(userid);
    //            DatabaseHelper dbHelper = new DatabaseHelper(dbPath);

    //            if (!File.Exists(dbPath))
    //            {
    //                File.WriteAllText(dbPath, "[]");
    //            }

    //            List<InterviewClass> existingInterviews = dbHelper.GetAllEntities<InterviewClass>(dbPath);

    //            if (!HasConflict(existingInterviews))
    //            {
    //                dbHelper.SaveEntityToFile<InterviewClass>(this, existingInterviews);
    //            }
    //            else
    //            {
    //                throw new InvalidOperationException("Конфликт расписаний!");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new InvalidOperationException($"{ex.Message}");
    //        }
    //    }
    //}
}
