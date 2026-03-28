using OpenQA.Selenium;
using SeleniumFramework.Models;
using SeleniumFramework.Utilities.Extensions;

namespace SeleniumFramework.Pages
{
    public class AddVisitPage : BasePage
    {
        private readonly IWebDriver _driver;
        private IWebElement DescriptionField => _driver.FindElement(By.Id("description"));
        private IWebElement AddVisitButton => _driver.FindElement(By.XPath("//button[text()='Add Visit']"));
        private IWebElement DisplayedPetName => _driver.FindElement(By.XPath("//table[@aria-describedby='pet']/tbody/tr/td[1]"));
        private IWebElement DisplayedPetBirthDate => _driver.FindElement(By.XPath("//table[@aria-describedby='pet']/tbody/tr/td[2]"));
        private IWebElement DisplayedPetType => _driver.FindElement(By.XPath("//table[@aria-describedby='pet']/tbody/tr/td[3]"));
        private IWebElement DisplayedOwnerName => _driver.FindElement(By.XPath("//table[@aria-describedby='pet']/tbody/tr/td[4]"));
        private IWebElement AddVisitLink(int ownerId, int petId) =>
            _driver.FindElement(By.XPath($"//a[@href='/owners/{ownerId}/pets/{petId}/visits/new']"));

        public AddVisitPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void ClickAddVisitForPet(int ownerId, int petId)
        {
            var element = AddVisitLink(ownerId, petId);
               _driver.ScrollToElementAndClick(element);
        }

        public void FillVisitDetails(VisitModel visit)
        {
            DescriptionField.SendKeys(visit.Description);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"document.getElementById('date').value='{visit.Date}'");
        }

        public void ClickAddVisitButton()
        {
            AddVisitButton.Click();
        }

        public string GetPetNameText()
        {
            return DisplayedPetName.Text;
        }

        public string GetPetBirthDateText()
        {
            return DisplayedPetBirthDate.Text;
        }

        public string GetPetTypeText()
        {
            return DisplayedPetType.Text;
        }

        public string GetOwnerNameText()
        {
            return DisplayedOwnerName.Text;
        }
    }
}