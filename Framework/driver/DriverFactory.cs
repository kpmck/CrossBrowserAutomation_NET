using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Microsoft.Edge.SeleniumTools;

namespace CrossBrowserAutomation.Framework
{
    public class DriverFactory
    {

        private static string driversPath = String.Concat(Environment.CurrentDirectory, "\\drivers");

        public static IWebDriver WebDriver(Browser type, Device device = Device.Desktop)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case Browser.Edge:
                    driver = EdgeDriver(device);
                    break;
                case Browser.Firefox:
                    driver = FirefoxDriver(device);
                    break;
                case Browser.Chrome:
                    driver = ChromeDriver(device);
                    break;
                case Browser.Phone:
                    driver = PhoneDriver();
                    break;
            }
            return driver;
        }

        private static IWebDriver PhoneDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.EnableMobileEmulation("iPhone X");
            return new ChromeDriver(driversPath, options);
        }

        private static ChromeDriver ChromeDriver(Device device)
        {
            ChromeOptions options = new ChromeOptions();
            switch (device)
            {
                case Device.Desktop:
                    options.AddArgument("--start-maximized");
                    break;
                case Device.Tablet:
                    options.EnableMobileEmulation("iPad");
                    options.AddArgument("--window-size=768,700");
                    break;
            }
            return new ChromeDriver(driversPath, options);
        }

        private static FirefoxDriver FirefoxDriver(Device device)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driversPath, "geckodriver.exe");
            FirefoxOptions options = new FirefoxOptions();
            switch (device)
            {
                case Device.Desktop:
                    options.AddArgument("--width=1200");
                    options.AddArgument("--height=700");
                    break;
                case Device.Tablet:
                    options.AddArgument("--width=768");
                    options.AddArgument("--height=700");
                    break;
            }
            return new FirefoxDriver(service, options);
        }


        private static EdgeDriver EdgeDriver(Device device)
        {
            EdgeOptions options = new EdgeOptions
            {
                UseChromium = true
            };
            EdgeDriver _driver = null;
            switch (device)
            {
                case Device.Desktop:
                    options.AddArgument("--start-maximized");
                    _driver = new EdgeDriver(driversPath, options);
                    break;
                case Device.Tablet:
                    options.EnableMobileEmulation("iPad");
                    _driver = new EdgeDriver(driversPath, options);
                    break;
            }
            return _driver;
        }
    }
}
