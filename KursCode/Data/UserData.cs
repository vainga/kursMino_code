using KursCode.Interfaces;
using KursCode.MVVM.Model.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public class UserData
    {
        string userString;

        IFileManager _FileManager;
        IRepository _Repository;
        IDatabaseHelper _DBHelper;
        IjsonManager _JsonManager;

        public UserData()
        {
            _JsonManager = new jsonManager();

            _FileManager = new fileManager();
            _DBHelper = new DatabaseHelper(_FileManager.GetLocalPath("Users"));
            _DBHelper.DBName = "meet";
            _Repository = new Repository(_DBHelper);
        }

        public void Add(IUser user)
        {
            userString = _JsonManager.ToJson(user);
            _DBHelper.createTable("Users", new [] { "id INT AUTO_INCREMENT PRIMARY KEY", "user TEXT"});
            _Repository.Add<string>("Users",userString);
        }

        public void Delete(IUser user)
        {
            _Repository.Delete<string>("Users", user.userId);
        }

        public void Update(IUser user, string newValue)
        {
            _Repository.Change<string>("Users", user.userId, "user", newValue);
        }

        public void Search(IUser user)
        {
            _Repository.Search<string>("user", user.userId);
        }
    }
}
