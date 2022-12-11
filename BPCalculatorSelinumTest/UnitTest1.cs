using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace BPCalculatorSelinumTest
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private String webAppUri;

        [TestInitialize]                // run before each unit test
        public void Setup()
        {
            // read URL from SeleniumTest.runsettings
            this.webAppUri = testContextInstance.Properties["webAppUri"].ToString();
            //this.webAppUri = "https://bpcheck.azurewebsites.net";
        }

        [TestMethod]
        public void TestMethod1()
        {
            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }
            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {

                driver.Navigate().GoToUrl(webAppUri);
                IWebElement bpSystolic = driver.FindElement(By.Id("Bp_Systolic"));
                bpSystolic.SendKeys("70");

                IWebElement bpDiastolic = driver.FindElement(By.Id("BP_Diastolic"));
                bpDiastolic.SendKeys("40");

                driver.FindElement(By.Id("form1")).Submit();

                // explictly wait for result with "BPValue" item
                IWebElement BPValueElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id("bpVal")));

                // item comes back like "BMIValue: 24.96"
                String bp = BPValueElement.Text.ToString();

            }
        }
    }
}