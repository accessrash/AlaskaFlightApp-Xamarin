using System;
using AlaskaFlightApp.Core.Contracts.Interactions;
using AlaskaFlightApp.Core.Contracts.Service;
using Moq;
using MvvmCross.Navigation;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class UnitTestBase
    {
        protected Mock<IKeyboard> keyBoardMock { get; set; }
        protected Mock<IFlightDataService> flightDataServiceMock { get; set; }
        protected Mock<IConnectionService> connectionServiceMock { get; set; }
        protected Mock<IDialogService> dialogServiceMock { get; set; }
        protected Mock<IMvxNavigationService> mvaNavigationMock { get; set; }


        [SetUp] //Called before every test run
        public void UnitTestBaseSetUp()
        {
            keyBoardMock = new Mock<IKeyboard>();
            flightDataServiceMock = new Mock<IFlightDataService>();
            connectionServiceMock = new Mock<IConnectionService>();
            dialogServiceMock = new Mock<IDialogService>();
            mvaNavigationMock = new Mock<IMvxNavigationService>();
        }
    }
}
