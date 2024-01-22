using KursCode.Interfaces;
using KursCode.MVVM.Model.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public class corporationData
    {
        string workerString;

        IFileManager _FileManager;
        IRepository _Repository;
        IDatabaseHelper _DBHelper;
        IjsonManager _JsonManager;

        public corporationData()
        {
            _JsonManager = new jsonManager();

            _FileManager = new fileManager();
            _DBHelper = new DatabaseHelper(_FileManager.GetLocalPath("Workers"));
            _DBHelper.DBName = "meet";
            _Repository = new Repository(_DBHelper);
        }

        public void Add(IWorker worker)
        {
            workerString = _JsonManager.ToJson(worker);
            _DBHelper.createTable("Corporations", new[] { "id INT AUTO_INCREMENT PRIMARY KEY", "worker TEXT", "status TEXT", "userId INT" });
            _Repository.Add<string>("Corporations", workerString, worker._Status, worker.UserId);
        }

        public void Delete(IWorker worker)
        {
            _Repository.Delete<string>("Corporations", worker.WorkerId);
        }

        public void Update(IWorker worker, IWorker newValue)
        {
            string newStringWorker = _JsonManager.ToJson(newValue);
            _Repository.Change<string>("Corporations", worker.WorkerId, "corporation", newStringWorker);
        }

        public void Search(IWorker worker)
        {
            _Repository.Search<string>("corporation", worker.WorkerId);
        }
    }
}
