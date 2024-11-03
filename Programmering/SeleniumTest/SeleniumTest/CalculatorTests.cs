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
        private static string url = "E:\\- Repos -\\Hillgrove\\Datamatiker\\Programmering\\VUE-Calculator\\index.html";
        
        // Download drivers to your driver folder.
        // Driver version must match your browser version.
        // http://chromedriver.chromium.org/downloads

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast
            //_driver = new FirefoxDriver(DriverDirectory);  // slow
            //_driver = new EdgeDriver(DriverDirectory); //  fast
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
            // Arrange
            _driver.Navigate().GoToUrl(url);

            // Act
            // Input 1
            IWebElement input1Element = _driver.FindElement(By.Id("number1"));
            input1Element.SendKeys("1000");

            // Operator
            IWebElement selectOperatorElement = _driver.FindElement(By.Id("operation"));
            SelectElement select = new SelectElement(selectOperatorElement);
            select.SelectByValue("+");


            // Input 2
            IWebElement input2Element = _driver.FindElement(By.Id("number2"));
            input2Element.SendKeys("337");

            // Calculate
            IWebElement CalculateButtonElement = _driver.FindElement(By.Id("calculate"));
            CalculateButtonElement.Click();

            // Result
            IWebElement outputElement = _driver.FindElement(By.Id("result"));
            string result = outputElement.Text;

            // Assert
            Assert.AreEqual("1337", result);
        }
    }
}