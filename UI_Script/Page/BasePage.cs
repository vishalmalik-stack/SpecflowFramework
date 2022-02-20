﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace UI_Script.Page
{
    public class BasePage : Base
    {
        private IWebDriver _driver;
        
        public BasePage(IWebDriver driver):base(driver)
        {
            _driver = driver;
        }

        public override IWebElement getElement(By locator)
        {
            IWebElement element = null;
            try
            {
                element = _driver.FindElement(locator);                
            }
            catch (Exception e)
            {
                Console.WriteLine("Locator is not found " + locator.ToString());
                Console.WriteLine(e.Message);

            }

            return element;
        }

        public override string getText(By locator)
        {
          
           
               waitForelementVisible(locator);
               string text = getElement(locator).Text;
           
             return text;
        }

        public override string getPageTitle()
        {
            return _driver.Title;
        }

        public override void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public override void waitForelementExist(By locator)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);

            }
        }

        public override void waitForelementVisible(By locator)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);

            }
        }

        public void JavaScriptexecutorForClick(By locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", _driver.FindElement(locator));
       
        }
        public void JavaScriptexecutorForSend(By locator, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].value="+value+ "", _driver.FindElement(locator));

        }
        public void ClickOnButton(By locator)
        {
            try
            {
                waitForelementVisible(locator);
                IWebElement element  = _driver.FindElement(locator);
                element.Click();
            }
            catch (Exception e)
            {

                try
                {
                    
                    JavaScriptexecutorForClick(locator);
                }
                catch (Exception)
                {

                    throw;
                }
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }  
        }

        public void SendText(By locator, string value)
        {
            try
            {
                waitForelementVisible(locator);
                Thread.Sleep(5);
                IWebElement element = _driver.FindElement(locator);              
                element.SendKeys(value);

            }
            catch (Exception e)
            {
                try
                {
                    
                    JavaScriptexecutorForSend(locator,value);
                }
                catch (Exception)
                {

                    try
                    {
                        ActionsSendkey(locator, value);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }

        public void ActionsSendkey(By locator,string value)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            IWebElement element = _driver.FindElement(locator);
            Actions actions = new Actions(_driver);
            actions.SendKeys(element, value).Build().Perform();
        }



    }
}
