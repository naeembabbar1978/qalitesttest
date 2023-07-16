using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qualitestproject.Pages
{
    public class CartPage 
    {
        private readonly IWebDriver _driver;
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public  string BaseUrl
        {
            get
            {
                return "https://cms.demo.katalon.com/cart/";
            }
        }


        public void GoTo()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public int GetTotalCartItems()
        {
            return _driver.FindElements(By.CssSelector(".cart tr[class*=cart_item]")).Count();
        }

        public int FindLowPrice()
        {
            var prices = _driver.FindElements(By.CssSelector(".cart tr[class*=cart_item] td[class=product-price]")).Select(t => decimal.Parse(t.Text.Replace("$",""))).ToArray();
            return Array.IndexOf(prices, prices.Min());
        }

        public void RemoveCartItem(int index)
        {
            string path = $".cart tr[class*=cart_item]:nth-child({index}";
            var cartToRemove = _driver.FindElement(By.CssSelector(path)).FindElement(By.TagName("a"));
            cartToRemove.Click();
            Thread.Sleep(2000);
        }

        public void Close()
        {
            _driver.Close();
        }
    }
}
