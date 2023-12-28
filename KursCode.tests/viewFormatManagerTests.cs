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
    public class viewFormatManagerTests
    {
        [TestMethod]
        public void FormatNumeric_ValidInput_ReturnsDigitsOnly()
        {
            iviewModelFormatManager formatManager = new viewFormatManager();
            string input = "abc123xyz";
            string result = formatManager.FormatNumeric(input);
            Assert.AreEqual("123", result);
        }

        [TestMethod]
        public void FormatLetter_ValidInput_ReturnsLettersOnly()
        {
            iviewModelFormatManager formatManager = new viewFormatManager();
            string input = "a1b2c3";
            string result = formatManager.FormatLetter(input);
            Assert.AreEqual("abc", result);
        }

        [TestMethod]
        public void RemoveSpaces_ValidInput_ReturnsStringWithoutSpaces()
        {
            iviewModelFormatManager formatManager = new viewFormatManager();
            string input = "a b c";
            string result = formatManager.RemoveSpaces(input);
            Assert.AreEqual("abc", result);
        }

        [TestMethod]
        public void FormatPhoneNumber_ValidInput_ReturnsFormattedPhoneNumber()
        {
            iviewModelFormatManager formatManager = new viewFormatManager();
            string input = "+7 123 456-78-90";
            string result = formatManager.FormatPhoneNumber(input);
            Assert.AreEqual("+7-123-456-78-90", result);
        }

        [TestMethod]
        public void FormatPhoneNumber_InputWithExtraCharacters_ReturnsFormattedPhoneNumber()
        {
            iviewModelFormatManager formatManager = new viewFormatManager();
            string input = "+7 (123) 456-78-90 ext. 123";
            string result = formatManager.FormatPhoneNumber(input);
            Assert.AreEqual("+7-123-456-78-90", result);
        }

        [TestMethod]
        public void FormatPhoneNumber_TooManyDigits_ReturnsFormattedPhoneNumberWithTruncatedInput()
        {
            iviewModelFormatManager formatManager = new viewFormatManager();
            string input = "+71234567890123";
            string result = formatManager.FormatPhoneNumber(input);
            Assert.AreEqual("+7-123-456-78-90", result);
        }

        [TestMethod]
        public void FormatPhoneNumber_InvalidInput_ReturnsEmptyString()
        {
            iviewModelFormatManager formatManager = new viewFormatManager();
            string input = "abc";
            string result = formatManager.FormatPhoneNumber(input);
            Assert.AreEqual(string.Empty, result);
        }
    }
}
