using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumFramework.Models;

namespace SeleniumFramework.Pages
{
    public class AddPetPage : BasePage
    {
        private readonly IWebDriver _driver;
        private IWebElement NameField => _driver.FindElement(By.Id("name"));
        private IWebElement TypeDropdown => _driver.FindElement(By.Id("type"));
        private IWebElement AddPetButton => _driver.FindElement(By.XPath("//button[text()='Add Pet']"));

        public AddPetPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void FillPetDetails(PetModel pet)
        {
            NameField.SendKeys(pet.Name);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"document.getElementById('birthDate').value='{pet.Birthdate}'");
            new SelectElement(TypeDropdown).SelectByText(pet.Type);
        }

        public void ClickAddPetButton()
        {
            AddPetButton.Click();
        }
    }
}
