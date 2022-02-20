﻿using OpenQA.Selenium;


namespace UI_Script.Page
{
    
    public class AccountPage : BasePage
    {
        By clickLogin = By.XPath("//*[text()='Sign in']");
        By crmUsername = By.XPath("//input[@name='email']");
        By clickContinue = By.XPath("//input[@id='continue']");
        By crmPassword = By.XPath("//input[@name='password']");
        By SubmitBtn = By.XPath("//input[@id='signInSubmit']");
        By checkInfoSaved = By.XPath("//*[text()='Hello, rashmi']");





        public AccountPage(IWebDriver driver) : base(driver)
        {

        }


        public void NavigateToAmazone(string url)
        {
            GoToUrl(url);
        }


        public void LoginCRM(string userName, string password)
        {

            waitForelementExist(clickLogin);
            ClickOnButton(clickLogin);
            waitForelementVisible(crmUsername);
            SendText(crmUsername, userName);
            waitForelementVisible(clickContinue);
            ClickOnButton(clickContinue);
            SendText(crmPassword, password);



        }

        public void ClickonSubmitBtn()
        {
            ClickOnButton(SubmitBtn);
        }



        public string AccoutSaved()
        {
            waitForelementVisible(checkInfoSaved);
            return getText(checkInfoSaved);
        }
    }
}
