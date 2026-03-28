using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver _driver;

        public IEnumerable<IWebElement> GetErrorElementsForField(string fieldLabel) =>
        _driver.FindElements(By.XPath($"//div[label[text()='{fieldLabel}']]//span[@class='help-inline']"));
        public IWebElement FieldInput(string fieldLabel) =>
            _driver.FindElement(By.XPath($"//div[label[text()='{fieldLabel}']]//input"));

        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public bool HasErrorForField(string fieldLabel)
        {
            return GetErrorElementsForField(fieldLabel).Any(e => !string.IsNullOrWhiteSpace(e.Text));
        }

        public void FillField(string fieldLabel, string value)
        {
            var element = FieldInput(fieldLabel);

            if (fieldLabel.Contains("Date", StringComparison.OrdinalIgnoreCase))
            {
                string elementId = element.GetAttribute("id");
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript($"document.getElementById('{elementId}').value='{value}'");
            }
            else
            {
                element.Clear();
                element.SendKeys(value);
            }
        }
    }
}
