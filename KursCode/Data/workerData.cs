using KursCode.Interfaces;
using KursCode.MVVM.Model.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public class workerData
    {
        string userString;

        IFileManager _FileManager;
        IRepository _Repository;
        IDatabaseHelper _DBHelper;
        IjsonManager _JsonManager;

        public workerData()
        {
            _JsonManager = new jsonManager();

            _FileManager = new fileManager();
            _DBHelper = new DatabaseHelper(_FileManager.GetLocalPath("Workers"));
            _DBHelper.DBName = "meet";
            _Repository = new Repository(_DBHelper);
        }

        public void Add()
        {
            userString = _JsonManager.ToJson(user);
            _DBHelper.createTable("Workers", new[] { "id INT AUTO_INCREMENT PRIMARY KEY", "worker TEXT", "userId INT" });
            _Repository.Add<string>("Workers", userString);
        }

        public void Delete()
        {
            _Repository.Delete<string>("Workers",);
        }

        public void Update(, string newValue)
        {
            _Repository.Change<string>("Workers", user.userId, "worker", newValue);
        }

        public void Search()
        {
            _Repository.Search<string>("worker", user.userId);
        }
    }
}
