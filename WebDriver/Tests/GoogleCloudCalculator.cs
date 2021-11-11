using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Pages.CalculatorPage;

namespace Tests
{
    [TestFixture]
    public class GoogleCloudCalculator
    {
        private IWebDriver driver;


        [Test]
        public void CostEstimate()
        {
            CalculatorChromeDriver calculatorPage = new CalculatorChromeDriver(driver);

            calculatorPage.openCloudPage();
            calculatorPage.goToGoogleCloudPlatformPricingCalculatorPage(
                    "Google Cloud Platform Pricing Calculator");
            calculatorPage.sendKeyInToNumberOfInstancesField("4");
            calculatorPage.selectSeriesOfMachine();
            calculatorPage.selectMachineType();
            calculatorPage.ClickAddGpusCheckBox();
            calculatorPage.selectNumberOfGpus();
            calculatorPage.selectGpuType();
            calculatorPage.selectLocalSsd();
            calculatorPage.selectDataCenterLocation();
            calculatorPage.selectCommittedUsage();
            calculatorPage.pushAddToEstimate();

            calculatorPage.checkInformationInVmClassIsRegular();
            calculatorPage.checkInformationInInstanceTypeIncludeN1Standard8();
            calculatorPage.checkRegionIsFrankfurt();
            calculatorPage.checkLocalSsdSpace2x375Gib();
            calculatorPage.checkCommitmentTermOneYear();
        }


        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }


        [SetUp]
        public void SetupTest()
        {
            ChromeOptions options = new ChromeOptions();


            options.AddArguments("load-extension=C:\\Users\\Asus\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extensions\\gighmmpiobklfepjocnamgkkbiglidom\\4.39.1_0");

            driver = new ChromeDriver(options);

        }


    }
}
