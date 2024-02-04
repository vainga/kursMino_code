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
        string corporationString;

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

        public void Add(ICorporation corporation)
        {
            corporationString = _JsonManager.ToJson(corporation);
            _DBHelper.createTable("Corporations", new[] { "id INT AUTO_INCREMENT PRIMARY KEY", "corporoation TEXT", "userId INT" });
            _Repository.Add<string>("Corporations", corporationString, corporation.UserId);
        }

        public void Delete(ICorporation corporation)
        {
            _Repository.Delete<string>("Corporations", corporation.CorporationId);
        }

        public void Update(ICorporation corporation, ICorporation newCorporation)
        {
            string newStringCorporation = _JsonManager.ToJson(newCorporation);
            _Repository.Change<string>("Corporations", corporation.CorporationId, "corporation", newStringCorporation);
        }

        public void Search(ICorporation corporation)
        {
            _Repository.Search<string>("corporation", corporation.CorporationId);
        }
    }
}
