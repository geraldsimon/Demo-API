using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Demo.BDD.Test.Config
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(ConfBrowser browser, string caminhoDriver, bool headless)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case ConfBrowser.Firefox:
                    var optionsFireFox = new FirefoxOptions();
                    if (headless)
                        optionsFireFox.AddArgument("--headless");

                    webDriver = new FirefoxDriver(caminhoDriver, optionsFireFox);

                    break;
                case ConfBrowser.Chrome:
                    var optionsChrome = new ChromeOptions();

                    if (headless)
                        optionsChrome.AddArgument("--headless");

                    webDriver = new ChromeDriver(caminhoDriver, optionsChrome);

                    break;
            }

            return webDriver;
        }
    }
}

