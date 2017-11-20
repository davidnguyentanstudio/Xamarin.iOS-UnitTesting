using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace TableView.UITest
{
    [TestFixture]
    public class PersonsViewControllerTests
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .iOS
                .EnableLocalScreenshots()
                .StartApp();
        }

        [Test]
        public void PersonsViewController_Launched_Success()
        {
            app.WaitForElement((arg) => arg.Class("UINavigationBar").Marked("Persons"));
        }

        [Test]
        public void TapAddBarButton_Showing_EditViewController()
        {
            app.WaitForElement((arg) => arg.Class("UINavigationBar").Marked("Persons"));
            app.Tap((arg) => arg.Class("UIButton").Marked("Add"));
            app.WaitForElement((arg) => arg.Class("UINavigationBar").Marked("New Person"));
        }
    }
}
