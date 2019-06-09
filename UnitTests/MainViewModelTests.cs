using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AlaskaFlightApp.Core.Models;
using AlaskaFlightApp.Core.ViewModels;
using Moq;
using NUnit.Framework;
using UnitTests;

namespace Tests
{
    [TestFixture]
    public class Tests: UnitTestBase
    {

        MainViewModel Subject { get; set; }
        [SetUp]
        public void Setup()
        {
            Subject = new MainViewModel(flightDataServiceMock.Object, connectionServiceMock.Object, dialogServiceMock.Object, mvaNavigationMock.Object);
            Subject.keyboard = keyBoardMock.Object;
        }

        [Test]
        public void ClickSearchCallsCheckOnline()
        {
            Subject.SearchCommand.Execute();
            connectionServiceMock.Verify(x => x.CheckOnline(), Times.Once);
        }

        [Test]
        public void ClickSearchCallsDismissKeyboard()
        {
            Subject.SearchCommand.Execute();
            keyBoardMock.Verify(x => x.dismissKeyboard(), Times.Once);
        }

        [Test]
        public void ClickSearchCallsGetFlightDetailsWhenOnline()
        {
            connectionServiceMock.Setup(x => x.CheckOnline()).Returns(true);
            flightDataServiceMock.Setup(x => x.GetFlightDetails(It.IsAny<string>())).Returns(Task.FromResult(new List<FlightModel>()));
            Subject.SearchCommand.Execute();
            flightDataServiceMock.Verify(x => x.GetFlightDetails(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ClickSearchCallsShowAlertAsyncWhenOnlineAndSearchResultIsEmpty()
        {
            connectionServiceMock.Setup(x => x.CheckOnline()).Returns(true);
            flightDataServiceMock.Setup(x => x.GetFlightDetails(It.IsAny<string>())).Returns(Task.FromResult(new List<FlightModel>()));
            Subject.SearchCommand.Execute();
            dialogServiceMock.Verify(x => x.ShowAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ClickSearchCallsShowAlertAsyncWhenConnectionIsFalse()
        {
            connectionServiceMock.Setup(x => x.CheckOnline()).Returns(false);
            Subject.SearchCommand.Execute();
            dialogServiceMock.Verify(x => x.ShowAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}