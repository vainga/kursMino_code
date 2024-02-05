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
            _DBHelper = new DatabaseHelperSQLite(_FileManager.GetLocalPath("users.db"));
            _Repository = new Repository(_DBHelper);
        }

        public void Add(IUser user)
        {
            userString = _JsonManager.ToJson(user);
            _DBHelper.createTable("users", new[] { "id INTEGER PRIMARY KEY", "user TEXT" });
            _Repository.Add("users", new[] { "user" } , new object[] { userString });
        }

        public void Delete(IUser user)
        {
            _Repository.Delete<string>("users", user.userId);
        }

        public void Update(IUser user, IUser newValue)
        {
            string newStringUser = _JsonManager.ToJson(newValue);
            _Repository.Change<string>("users", user.userId, "user", newStringUser);
        }

        public IUser Search(IUser user)
        {
           return _Repository.Search<IUser>("users", user.userId);
        }

        public int GetLastId()
        {
            return _Repository.GetLastId("users");
        }
    }
}
