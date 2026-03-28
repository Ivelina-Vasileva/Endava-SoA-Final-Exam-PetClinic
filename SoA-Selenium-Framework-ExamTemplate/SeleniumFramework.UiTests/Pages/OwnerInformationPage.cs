using OpenQA.Selenium;
using SeleniumFramework.Models;

namespace SeleniumFramework.Pages
{
    public class OwnerInformationPage : BasePage
    {
        private readonly IWebDriver _driver;
        private IWebElement OwnerNameDisplay => _driver.FindElement(By.XPath("//th[text()='Name']/following-sibling::td"));
        private IWebElement OwnerAddressDisplay => _driver.FindElement(By.XPath("//th[text()='Address']/following-sibling::td"));
        private IWebElement AddNewPetButton => _driver.FindElement(By.XPath("//a[contains(text(), 'Add New Pet')]"));
        private IEnumerable<IWebElement> PetContainers(PetModel pet) =>
        _driver.FindElements(By.XPath($"//dl[dd[text()='{pet.Name}'] and " +
                                      $"dd[text()='{pet.Birthdate}'] and " +
                                      $"dd[text()='{pet.Type}']]"));

        private IEnumerable<IWebElement> GetVisitElementsForPet(PetModel pet, string description) =>
        _driver.FindElements(By.XPath(
            $"//tr[th/dl[dd[text()='{pet.Name}'] and " +
            $"dd[text()='{pet.Birthdate}'] and " +
            $"dd[text()='{pet.Type}']]]" +
            $"/td//table//td[@headers='visitDescription' and text()='{description}']"));

        public OwnerInformationPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public string GetOwnerName()
        {
            return OwnerNameDisplay.Text;
        }

        public bool IsPetPresent(PetModel pet)
        {
            return PetContainers(pet).Any();
        }

        public bool IsVisitPresentForPet(PetModel pet, string description)
        {
            return GetVisitElementsForPet(pet, description).Any();
        }

        public string GetOwnerAddress()
        {
            return OwnerAddressDisplay.Text;
        }

        public void ClickAddNewPetButton()
        {
            AddNewPetButton.Click();
        }
    }
}
