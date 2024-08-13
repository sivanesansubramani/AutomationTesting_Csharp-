using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTesting_Csharp
{
    public class BasicAutomationTest
    {
        public BasicAutomationTest()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.google.com");
                driver.Manage().Window.Maximize();
                Thread.Sleep(8000);

                IWebElement searchBox = driver.FindElement(By.Name("q"));
                searchBox.SendKeys("Selenium C# tutorial");
                searchBox.Submit();

                // Scroll down the page
                Actions actions = new Actions(driver);
                actions.SendKeys(Keys.PageDown).Perform();
                Thread.Sleep(2000); // Pause for 2 seconds

                // Scroll up the page
                actions.SendKeys(Keys.PageUp).Perform();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(d => d.Title.Contains("Selenium C# tutorial"));
                Thread.Sleep(8000);

                if (driver.PageSource.Contains("Selenium C# tutorial"))
                {
                    //IWebElement link = driver.FindElement(By.XPath("h3[contains(text(),'Selenium C# tutorial')]"));
                    IWebElement textSelenium = driver.FindElement(By.XPath("(//h3[text()='Selenium with C# Tutorial'])[1]"));
                    textSelenium.Click();

                    //driver.Navigate().Back();
                    //driver.Navigate().Forward();
                    //driver.Navigate().Refresh();
                    //driver.Close();

                    Console.WriteLine("Test Passed");

                }
                else
                {
                    Console.WriteLine("Test Failed");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test Failed with Exception: {ex.Message}");
            }
            finally
            {
                driver.Quit();
                Console.ReadLine();
            }
        }
    }
}
