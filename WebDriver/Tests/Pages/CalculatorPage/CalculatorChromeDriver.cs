using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Pages.CalculatorPage
{
    class CalculatorChromeDriver
    {
        private IWebDriver driver;
        WebDriverWait wait;


        private By devSiteSearch = By.ClassName("devsite-search-form");
        private By googleSearch = By.XPath("//input[@class='devsite-search-field devsite-search-query']");
        private By switchToCalculator = By.XPath("//b[text()='Google Cloud Platform Pricing Calculator']/parent::a");
        private By newFirstFrame = By.XPath("//iframe[contains(@name,'goog_')]");
        private By instancesField =
                By.XPath("//md-input-container/child::input[@ng-model='listingCtrl.computeServer.quantity']");
        private By seriesOfMachine = By.XPath("//md-select[@name='series']/parent::md-input-container");
        private By seriesOfMachineModel = By.XPath("//md-option[@value='n1']");
        private By machineType = By.XPath("//label[text()='Machine type']/parent::md-input-container");
        private By computeEngine = By.XPath("//md-option[@value='CP-COMPUTEENGINE-VMIMAGE-N1-STANDARD-8']");
        private By gpusCheckBox = By.XPath("//md-checkbox[@aria-label='Add GPUs']");
        private By numberOfGpus = By.XPath("//md-select[@placeholder='Number of GPUs']");
        private By numberOfGpusModel = By.CssSelector("md-option[value='1'][class='ng-scope md-ink-ripple'][ng-disabled]");
        private By gpuType = By.XPath("//md-select[@placeholder='GPU type']");
        private By gpuTypeModel = By.XPath("//md-option[@value='NVIDIA_TESLA_V100']");
        private By localSsd = By.XPath("//md-select[@placeholder='Local SSD']");
        private By localSsdModel = By.CssSelector("#select_option_438");
        private By dataCenterLocation = By.XPath("//md-select[@placeholder='Datacenter location']");
        private By dataCenterLocationInFrankfurt = By.CssSelector("md-select-menu[class='md-overflow']" +
                " md-option[value='europe-west3'][ng-repeat*='fullRegionList']");
        private By committedUsage = By.XPath("//md-select[@placeholder='Committed usage']");
        private By oneYearUsage = By.CssSelector("#select_option_112");
        private By addToEstimateButton = By.XPath("//button[@aria-label='Add to Estimate']");
        private By informationInVmClassIsRegular = By.XPath("//div[contains (text(),'VM class: regular')]");
        private By InformationInInstanceTypeIncludeN1Standard8 =
                By.XPath("//div[contains (text(),'Instance type: n1-standard-8')]");
        private By regionIsFrankfurt = By.XPath("//div[contains (text(),'Region: Frankfurt')]");
        private By localSsdSpace2x375Gib = By.XPath("//div[contains (text(),'Local SSD: 2x375 GiB')]");
        private By commitmentTermOneYear = By.XPath("//div[contains (text(),'Commitment term: 1 Year')]");

        public CalculatorChromeDriver(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            this.driver = driver;
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
        }

        public void openCloudPage()
        {
            driver.Navigate().GoToUrl("https://cloud.google.com/");
        }

        public void goToGoogleCloudPlatformPricingCalculatorPage(String keyForCalculatorPageOpening)
        {
            driver.FindElement(devSiteSearch).Click();
            IWebElement textForGoogleSearch = driver.FindElement(googleSearch);
            textForGoogleSearch.Click();
            textForGoogleSearch.SendKeys(keyForCalculatorPageOpening);
            textForGoogleSearch.SendKeys(Keys.Enter);
            try
            {
                wait.Until(driver =>
               driver.FindElement(switchToCalculator));
                driver.FindElement(switchToCalculator).Click();
            }
            catch
            {
                driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");
            }
        }

        public void sendKeyInToNumberOfInstancesField(String keyForNumberOfInstances)
        {
            wait.Until(driver => driver.FindElement(newFirstFrame));
            IWebElement element = driver.FindElement(newFirstFrame);
            driver.SwitchTo().Frame(element);
            driver.SwitchTo().Frame("myFrame");
            wait.Until(driver => driver.FindElement(instancesField));
            IWebElement numberOfInstancesField = driver.FindElement(instancesField);
            numberOfInstancesField.SendKeys(keyForNumberOfInstances);
        }

        public void selectSeriesOfMachine()
        {
            wait.Until(driver => driver.FindElement(seriesOfMachine));
            driver.FindElement(seriesOfMachine).Click();
            wait.Until(driver => driver.FindElement(seriesOfMachineModel));
            driver.FindElement(seriesOfMachineModel).Click();
        }

        public void selectMachineType()
        {
            wait.Until(driver => driver.FindElement(machineType));
            driver.FindElement(machineType).Click();
            wait.Until(driver => driver.FindElement(computeEngine));
            driver.FindElement(computeEngine).Click();
        }

        public void ClickAddGpusCheckBox()
        {
            wait.Until(driver => driver.FindElement(gpusCheckBox));
            driver.FindElement(gpusCheckBox).Click();
        }

        public void selectNumberOfGpus()
        {
            wait.Until(driver => driver.FindElement(numberOfGpus));
            driver.FindElement(numberOfGpus).Click();
            wait.Until(driver => driver.FindElement(numberOfGpusModel));
            driver.FindElement(numberOfGpusModel).Click();
        }

        public void selectGpuType()
        {
            wait.Until(driver => driver.FindElement(gpuType));
            driver.FindElement(gpuType).Click();
            wait.Until(driver => driver.FindElement(gpuTypeModel));
            driver.FindElement(gpuTypeModel).Click();
        }

        public void selectLocalSsd()
        {
            wait.Until(driver => driver.FindElement(localSsd));
            driver.FindElement(localSsd).Click();
            wait.Until(driver => driver.FindElement(localSsdModel));
            driver.FindElement(localSsdModel).Click();
        }

        public void selectDataCenterLocation()
        {
            wait.Until(driver => driver.FindElement(dataCenterLocation));
            driver.FindElement(dataCenterLocation).Click();
            wait.Until(driver => driver.FindElement(dataCenterLocationInFrankfurt));
            driver.FindElement(dataCenterLocationInFrankfurt).Click();
        }

        public void selectCommittedUsage()
        {
            wait.Until(driver => driver.FindElement(committedUsage));
            driver.FindElement(committedUsage).Click();
            wait.Until(driver => driver.FindElement(oneYearUsage));
            driver.FindElement(oneYearUsage).Click();
        }

        public void pushAddToEstimate()
        {
            wait.Until(driver => driver.FindElement(addToEstimateButton));
            driver.FindElement(addToEstimateButton).Click();
        }

        public void checkInformationInVmClassIsRegular()
        {
            wait.Until(driver => driver.FindElement(informationInVmClassIsRegular));
            driver.FindElement(informationInVmClassIsRegular);
        }

        public void checkInformationInInstanceTypeIncludeN1Standard8()
        {
            wait.Until(driver => driver.FindElement(InformationInInstanceTypeIncludeN1Standard8));
            driver.FindElement(InformationInInstanceTypeIncludeN1Standard8);
        }

        public void checkRegionIsFrankfurt()
        {
            wait.Until(driver => driver.FindElement(regionIsFrankfurt));
            driver.FindElement(regionIsFrankfurt);
        }

        public void checkLocalSsdSpace2x375Gib()
        {
            wait.Until(driver => driver.FindElement(localSsdSpace2x375Gib));
            driver.FindElement(localSsdSpace2x375Gib);
        }

        public void checkCommitmentTermOneYear()
        {
            wait.Until(driver => driver.FindElement(commitmentTermOneYear));
            driver.FindElement(commitmentTermOneYear);
        }
    }
}
