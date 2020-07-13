using CrossBrowserAutomation.Framework;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CrossBrowserAutomation.Tests
{
    public class BaseClass
    {
        public static IWebDriver _driver;
        public static string _applicationPath = "http://automationpractice.com/index.php";
        public Browser _browser;
        public Device _device;

        public By mobileMenu = By.CssSelector(".cat-title");
        public By mobileTabletQuickViewIcon = By.CssSelector(".quick-view-mobile");

        [SetUp]
        public void SetUp()
        {
            _driver = DriverFactory.WebDriver(_browser, _device);
            _driver.Navigate().GoToUrl(_applicationPath);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }
    }

    [TestFixture(Browser.Chrome, Device.Desktop)]
    [TestFixture(Browser.Firefox, Device.Desktop)]
    [TestFixture(Browser.Edge, Device.Desktop)]
    public class DesktopTests : BaseClass
    {
        public DesktopTests(Browser browser, Device device)
        {
            _browser = browser;
            _device = device;
        }

        [Test]
        public void MobileView_Displayed_False()
        {
            Assert.IsFalse(_driver.FindElement(mobileMenu).Displayed, "The mobile menu is displayed");
            Assert.IsFalse(_driver.FindElement(mobileTabletQuickViewIcon).Displayed, "The mobile/tablet quick view icon is displayed.");
        }
    }

    [TestFixture(Browser.Phone, Device.Phone)]
    public class PhoneTests : BaseClass
    {
        public PhoneTests(Browser browser, Device device)
        {
            _browser = browser;
            _device = device;
        }

        [Test]
        public void MobileView_Displayed_True()
        {
            Assert.IsTrue(_driver.FindElement(mobileMenu).Displayed, "The mobile menu is not displayed");
            Assert.IsTrue(_driver.FindElement(mobileTabletQuickViewIcon).Displayed, "The mobile/tablet quick view icon is not displayed.");
        }
    }

    [TestFixture(Browser.Chrome, Device.Tablet)]
    [TestFixture(Browser.Firefox, Device.Tablet)]
    [TestFixture(Browser.Edge, Device.Tablet)]
    public class TabletTests : BaseClass
    {
        public TabletTests(Browser browser, Device device)
        {
            _browser = browser;
            _device = device;
        }

        [Test]
        public void MobileView_Displayed_False()
        {
            Assert.IsFalse(_driver.FindElement(mobileMenu).Displayed, "The mobile menu is displayed");
            Assert.IsTrue(_driver.FindElement(mobileTabletQuickViewIcon).Displayed, "The mobile/tablet quick view icon is not displayed.");
        }
    }
}
