using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_chast2_422_Pushkina;
using System;
using System.Windows.Controls;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest4
    {
        private Frame _mainFrame;
        [TestMethod]
        public void AuthTestReg()
        {
            var page = new RegPage(_mainFrame);
            //Assert.IsTrue(page.Reg("Пушкин Павел Александрович", "pavel", "666", "666", "pavel@gmail.com"));
            Assert.IsFalse(page.Reg("Фёдоров Сергей Михайлович", "325sergey532", "325", "325", "325532@mail.com"));//логин существует
            Assert.IsFalse(page.Reg("Михалкова Виктория Романовна", "vik", "423", "423", "vikertyu@gmail.com"));//почта уже зарегистрирована
            Assert.IsFalse(page.Reg("Петр", "petr", "", "", "petr@wrt.com"));//пустой пароль
            Assert.IsFalse(page.Reg("Павел", "", "123", "123", "ppp@wrt.com"));//пустой логин

        }
    }
}
