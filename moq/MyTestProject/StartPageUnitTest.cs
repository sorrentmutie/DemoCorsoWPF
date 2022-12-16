using DemoMoqLibrary;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace MyTestProject
{
    [TestClass]
    public class StartPageUnitTest
    {
        [TestMethod]
        public void TestPageMethod()
        {
            //var mockedStartPage = new Mock<StartPage>();
            //mockedStartPage.Setup(x => x.Name).Returns("Test");
            //mockedStartPage.Setup(x => x.DoSomething("Prova")).Returns("Something");

            //var myInstance = mockedStartPage.Object;
            // AAA
            var mockSmtpSender = new Mock<ISmtpSender>();
            mockSmtpSender.Setup(x => x.Send(It.IsAny<string>())).Returns(true);

            var myClass= new StartPage(mockSmtpSender.Object);
            myClass.Name = "Salvatore";
            var result = myClass.DoSomething("Prova");
            var expectedResult = "Prova, Salvatore";
            Assert.AreEqual(result, expectedResult);

        }
    }
}