using KursCode.Interfaces;
using KursCode.MVVM.Model.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace KursCode.Data
{
    public class UserData
    {
        //string userString;

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
            //userString = _JsonManager.ToJson(user);
            _DBHelper.createTable("users", new[] { "Id INTEGER PRIMARY KEY", "Login TEXT", "Password TEXT" });
            _Repository.Add("users", new[] { "Login", "Password" } , new object[] { user._Login, user._Password});
        }

        public void Delete(IUser user)
        {
            _Repository.Delete<string>("users", user.userId);
        }

        //public void Update(IUser user, IUser newValue)
        //{
        //    string newStringUser = _JsonManager.ToJson(newValue);
        //    _Repository.Change<string>("users", user.userId, "user", newStringUser);
        //} Потом добавить замену только пароля и email

        public int SearchId(IUser user)
        {
            int id = _Repository.SearchtoId("users","Login", user._Login);
            return id;
        }

        public string SearchPassword(IUser user)
        {
            var password = _Repository.SearchbyId("users", user.userId, "Password");
            return password.ToString();
        }

        public int GetLastId()
        {
            return _Repository.GetLastId("users");
        }
    }
}
