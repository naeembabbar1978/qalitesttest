using NUnit.Framework;
using OpenQA.Selenium;
using qualitestproject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace qualitestproject.StepDefinitions
{
    [Binding]
    public sealed class MainStepDefinitions
    {
        private HomePage homePage;
        private CartPage cartPage;
        private IWebDriver _driver;

        private int lowPriceCartItemIndex;

        public MainStepDefinitions(IWebDriver driver)
        {
            _driver = driver;

            homePage = new HomePage(_driver);
            cartPage = new CartPage(_driver);
        }
        

        [Given(@"I add four random items to my cart")]
        public void GivenIHaveNavigatedToMyTestSite()
        {
            homePage.GoTo();
            homePage.AddRandomItemtoCart("/product/premium-quality-2/", By.Name("add-to-cart"));
            homePage.AddRandomItemtoCart("/product/happy-ninja/", By.Name("add-to-cart"));
            homePage.AddRandomItemtoCart("/product/ship-your-idea/", By.Name("add-to-cart"));
            homePage.AddRandomItemtoCart("/product/patient-ninja/", By.Name("add-to-cart"));
        }      

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            cartPage.GoTo();
        }

        [Then(@"i found four items listed in my cart")]
        public void ThenIFoundFourItemsListedInMyCart()
        {
            Assert.AreEqual(cartPage.GetTotalCartItems(), 4);
        }



        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
            lowPriceCartItemIndex = cartPage.FindLowPrice();
        }

        [Then(@"i am able to remove lowest price item from cart")]
        public void ThenIAmAbleToRemoveLowestPriceItemFromCart()
        {
            cartPage.RemoveCartItem(lowPriceCartItemIndex);
        }

        [Then(@"i am able to verify three items in my cart")]
        public void ThenIAmAbleToVerifyThreeItemsInMyCart()
        {
            Assert.AreEqual(cartPage.GetTotalCartItems(), 3);
            cartPage.Close();
        }




    }
}
