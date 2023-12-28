using Clients;
using KursCode.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.tests
{
    [TestClass]
    public class corporationClassTests
    {
        private static string GetCorporationDBPath(int userid)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userid}_ID_User");
            Directory.CreateDirectory(userSpecificFolderPath);
            return userSpecificFolderPath;
        }

        [TestMethod]
        public void AddData_WithValidUserId_NoExceptionsThrown()
        {
                int userId = 1;
                corporationClass corporationInstance = new corporationClass("CorporationName", "Post", "Email", "City", "Description",
                    new ObservableCollection<string>(), new ObservableCollection<string>(), "Citizenship", "Employment", "Shedule", "Status",
                    "WorkExperienceMax", "SalaryMin", "SalaryMax", "PhoneNumber", "Education", "Age", "PDF");

                corporationInstance.AddData(userId);

                string corporationFolderPath = GetCorporationDBPath(userId);
                string corporationDataFilePath = Path.Combine(corporationFolderPath, "corporation.json");

                Assert.IsTrue(File.Exists(corporationDataFilePath));

                DatabaseHelper dbHelper = new DatabaseHelper(corporationDataFilePath);
                List<corporationClass> jsonObjects = dbHelper.GetAllEntities<corporationClass>(corporationDataFilePath);

                Assert.IsNotNull(jsonObjects);
                Assert.IsTrue(jsonObjects.Any());
        }

        [TestMethod]
        public void ReadAllJsonFromDatabase_WithValidUserId_ReturnsList()
        {
            int userId = 1;

            corporationClass corporationInstance = new corporationClass();
            corporationInstance.AddData(userId);
            List<string> jsonStrings = corporationInstance.ReadAllJsonFromDatabase(userId);

            Assert.IsNotNull(jsonStrings);
        }



    }
}
