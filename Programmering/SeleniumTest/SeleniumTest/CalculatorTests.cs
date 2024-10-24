using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
// NuGet packages must be updated to at least version 3.141

namespace SeleniumTest
{
    [TestClass]
    public class CalculatorTests
    {
        private static readonly string DriverDirectory = "E:\\- Cloud -\\Google Drive\\Files\\Documents\\Uddannelse\\- Datamatiker -\\- Programmering -\\- Misc -\\WebDrivers";
        private static string url = "D:\\- Repos -\\Datamatiker\\Hillgrove\\Programmering\\VUE-Calculator\\index.html";
        
        // Download drivers to your driver folder.
        // Driver version must match your browser version.
        // http://chromedriver.chromium.org/downloads

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //_driver = new ChromeDriver(DriverDirectory); // fast
            //_driver = new FirefoxDriver(DriverDirectory);  // slow
            _driver = new EdgeDriver(DriverDirectory); //  fast
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestTitle()
        {
            // Arrange

            _driver.Navigate().GoToUrl(url);

            // Act and Assert
            Assert.AreEqual("Vue Calculator", _driver.Title);

        }

        [TestMethod]
        public void TestAddition()
        {
            // Act
            IWebElement inputElement = _driver.FindElement(By.Id("wordInput"));
            inputElement.SendKeys("Selenium");

            IWebElement saveButtonElement = _driver.FindElement(By.Id("saveButton"));
            saveButtonElement.Click();

            IWebElement showButtonElement = _driver.FindElement(By.Id("showButton"));
            showButtonElement.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("output"));
            string text = outputElement.Text;

            // Assert
            Assert.AreEqual("Selenium", text);
        }
    }
}