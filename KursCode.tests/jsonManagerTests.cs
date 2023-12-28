using Clients;
using KursCode.Interfaces;
using KursCode.MVVM.Model.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.tests
{
    [TestClass]
    public class jsonManagerTests
    {
        [TestMethod]
        public void ToJson_ObjectSerialization_ReturnsValidJson()
        {
            IjsonManager jsonManager = new jsonManager();
            var inputObject = new workerClass();

            string result = jsonManager.ToJson(inputObject);

            Assert.IsNotNull(result);
        }
    }
}
