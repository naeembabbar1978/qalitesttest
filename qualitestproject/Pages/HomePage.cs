using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace qualitestproject.Pages
{
    public class HomePage 
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public  string BaseUrl
        {
            get
            {
                return "https://cms.demo.katalon.com/";
            }
        }
        public void GoTo()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        


        public void AddRandomItemtoCart(string page, By findBy)
        {
            _driver.Navigate().GoToUrl(BaseUrl + page);
            _driver.FindElement(findBy).Click();

        }
      
    }
}
