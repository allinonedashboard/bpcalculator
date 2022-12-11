using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPCalculatorAcceptTest.Drivers
{
    public class browserDrivers
   : IDisposable
    {
        private readonly Lazy<IWebDriver> _myWebDriver;
        private bool _dummyValue;

        public browserDrivers()
        {
            _myWebDriver = new Lazy<IWebDriver>(MyWeb);
        }
        public IWebDriver Latest => _myWebDriver.Value;

        private IWebDriver MyWeb()
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--no-sandbox");
            chromeOptions.AddArguments("--disable-dev-shm-usage");
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArguments("--verbose");
            chromeOptions.AddArguments("--whitelisted-ips=''");
            chromeOptions.AddUserProfilePreference("download.default_directory", "YOUR_DownloadPath");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddArguments("disable-infobars");
            chromeOptions.AddArguments("start-maximized"); // open Browser in maximized mode
            chromeOptions.AddArguments("disable-infobars"); // disabling infobars
            chromeOptions.AddArguments("--disable-extensions"); // disabling extensions
            chromeOptions.AddArguments("--disable-gpu"); // applicable to windows os only
            chromeOptions.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
            // Bypass OS security model


            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            return chromeDriver;
        }
        public void Dispose()
        {
            if (_dummyValue)
            {
                return;
            }

            if (_myWebDriver.IsValueCreated)
            {
                Latest.Quit();
            }

            _dummyValue = true;
        }
    }
}