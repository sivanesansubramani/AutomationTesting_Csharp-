using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTesting_Csharp
{
    public class FaceBookAutomation
    {
        public FaceBookAutomation()
        {
            // Initialize the ChromeDriver
            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    // Maximize the browser window
                    driver.Manage().Window.Maximize();

                    // Navigate to Google
                    driver.Navigate().GoToUrl("https://www.google.com");

                    // Find the Google search box, type "Facebook", and hit Enter
                    IWebElement searchBox = driver.FindElement(By.Name("q"));
                    searchBox.SendKeys("Facebook");
                    searchBox.SendKeys(Keys.Enter);

                    // Wait for the search results to load
                    Thread.Sleep(2000);

                    // Click on the first link in the search results (Facebook page)
                    IWebElement fbLink = driver.FindElement(By.CssSelector("a[href*='facebook.com']"));

                    //open in a new tab code
                    // Open the Facebook link in a new tab using JavaScript
                    string fbUrl = fbLink.GetAttribute("href");
                    ((IJavaScriptExecutor)driver).ExecuteScript("window.open(arguments[0]);", fbUrl);

                    // Switch to the new tab
                    var tabs = driver.WindowHandles;
                    driver.SwitchTo().Window(tabs[1]); // Switch to the second tab

                    //fbLink.Click();

                    // Wait for the Facebook page to load
                    Thread.Sleep(2000);

                    try
                    {
                        // Find the username field, password field, and login button
                        IWebElement emailField = driver.FindElement(By.Id("email"));
                        IWebElement passwordField = driver.FindElement(By.Id("pass"));
                        IWebElement loginButton = driver.FindElement(By.Id("loginbutton"));


                        emailField.SendKeys("hello");
                        passwordField.SendKeys("hello");

                        loginButton.Click();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }

                    Thread.Sleep(5000);

                    //if (driver.Url.Contains("https://www.facebook.com/"))
                    if (driver.Url.Contains("login/device-based/regular/login/?login_attempt=1&lwv=100"))
                    {
                        Console.WriteLine("Test case passed: Login successful.");
                        driver.Navigate().Back();
                        Console.ReadLine();
                    }
                    else if (driver.Url.Contains("https://www.facebook.com/login/device-based/regular/login/?login_attempt=1&lwv=100"))
                    {
                        Console.WriteLine("Test case passed, but you need to verify username details.");
                        Thread.Sleep(2000);
                        driver.Navigate().Back();
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                finally
                {
                    // Close the browser
                    driver.Quit();
                }
            }
        }
    }
}
