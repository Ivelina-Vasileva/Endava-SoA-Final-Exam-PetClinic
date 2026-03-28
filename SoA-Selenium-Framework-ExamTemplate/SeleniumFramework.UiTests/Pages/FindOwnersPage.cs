using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public class FindOwnersPage : BasePage
    {
        private readonly IWebDriver _driver;

        private IWebElement FindOwnersButton => _driver.FindElement(By.XPath("//button[contains(text(), 'Find Owner')]"));
        private IWebElement LastNameSearchField => _driver.FindElement(By.XPath("//*[@id='lastName' and @class='form-control']"));
        private IWebElement FirstOwner => _driver.FindElement(By.XPath("//table//tr[1]//a"));
        private IReadOnlyCollection<IWebElement> SearchErrorMessages => _driver.FindElements(By.XPath("//*[@id='owner.errors']")); 
        public FindOwnersPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void ClickFindOwnersButton()
        {
            FindOwnersButton.Click();
        }

        public void SelectFirstOwner()
        {
            FirstOwner.Click();
        }
        
        public void ClickSearchOwnerForm()
        {
            LastNameSearchField.Click();
        }
        public void FillSearchField(string value)
        {
            LastNameSearchField.Clear();
            if (!string.IsNullOrEmpty(value))
            {
                LastNameSearchField.SendKeys(value);
            }

        }
        public bool IsSearchErrorDisplayed()
        {
            return SearchErrorMessages.Any(e => e.Displayed);
        }
    }
}

