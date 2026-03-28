using OpenQA.Selenium;
using SeleniumFramework.Models;
using SeleniumFramework.Utilities.Extensions;

namespace SeleniumFramework.Pages
{
    public class AddOwnerPage : BasePage
    {
        private readonly IWebDriver _driver;

        private IWebElement FirstNameField => _driver.FindElement(By.Id("firstName"));
        private IWebElement LastNameField => _driver.FindElement(By.Id("lastName"));
        private IWebElement AddressField => _driver.FindElement(By.Id("address"));
        private IWebElement CityField => _driver.FindElement(By.Id("city"));
        private IWebElement TelephoneField => _driver.FindElement(By.Id("telephone"));
        private IWebElement AddOwnerLink => _driver.FindElement(By.XPath("//a[@href='/owners/new']"));
        private IWebElement AddOwnerSubmitButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public AddOwnerPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void FillOwnerForm(OwnerModel owner)
        {
            FirstNameField.ClearAndSendText(owner.FirstName);

            LastNameField.ClearAndSendText(owner.LastName);

            AddressField.ClearAndSendText(owner.Address);

            CityField.ClearAndSendText(owner.City);

            TelephoneField.ClearAndSendText(owner.Telephone);
        }

        public void ClickAddOwnerLink()
        {
            AddOwnerLink.Click();
        }

        public void ClickAddOwnerSubmitButton()
        {
            AddOwnerSubmitButton.Click();
        }
    }
}

