using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace Superheroes.UITests
{
    [TestFixture]
    public class Tests
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp.iOS.StartApp();
        }

        [Test]
        public void WhenIPickThanosAndGamoraThanosShouldWin()
        {
            app.WaitForElement("Batman");

            app.Tap("Gamora");
            app.Tap("Thanos");

            app.Tap("Fight");

            var resultLabel = app.Query("ResultLabel").First();
            Assert.AreEqual("Thanos wins", resultLabel.Text);
        }
    }
}