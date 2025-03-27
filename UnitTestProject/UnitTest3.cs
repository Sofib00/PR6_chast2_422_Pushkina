using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR6_chast2_422_Pushkina;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new MainWindow();
            Assert.IsTrue(page.Auth("3334445ан", "3334445"));

            Assert.IsTrue(page.Auth("325sergey532", "325532"));
            Assert.IsTrue(page.Auth("vik3322", "4235"));
            Assert.IsTrue(page.Auth("mikle", "mik325"));
            Assert.IsTrue(page.Auth("gony2000", "gonytop"));
            Assert.IsTrue(page.Auth("ariana666", "ariana666"));
            Assert.IsTrue(page.Auth("smittttt", "666"));
            Assert.IsTrue(page.Auth("gagaga", "ga333ga"));
            Assert.IsTrue(page.Auth("pitbred", "333"));
            Assert.IsTrue(page.Auth("tom", "tom222"));
            Assert.IsTrue(page.Auth("rimyoy", "rimtop"));
            Assert.IsTrue(page.Auth("hat", "hathot"));
        }
        [TestMethod]
        public void AuthTestPr5()
        {
            var page = new MainWindow();
            Assert.IsTrue(page.Auth("3334445ан", "3334445"));
            Assert.IsFalse(page.Auth("gony2000", "333"));//неверный пароль
            Assert.IsFalse(page.Auth("smit", "666"));//неверный логин
            Assert.IsFalse(page.Auth("", "666"));//пустой логин
            Assert.IsFalse(page.Auth("gony2000", ""));//пустой пароль

        }
    }
}
