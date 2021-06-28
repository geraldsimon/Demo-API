using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Demo.BDD.Test.Config
{
    public class SeleniumHelper : IDisposable
    {
        public IWebDriver WebDriver;
        public readonly ConfigurationHelper Configuration;
        public WebDriverWait Wait;
        public static ITargetLocator CurrentFrame { get; private set; }

        public SeleniumHelper(ConfBrowser browser, ConfigurationHelper configuration, bool headless = true)
        {
            Configuration = configuration;
            WebDriver = WebDriverFactory.CreateWebDriver(browser, Configuration.WebDrivers, headless);
            CurrentFrame = WebDriver.SwitchTo();

            WebDriver.Manage().Window.Maximize();
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
        }

        public string ObterUrl()
        {
            return WebDriver.Url;
        }

        public void IrParaUrl(string url = "")
        {
            if (string.IsNullOrEmpty(url))
                url = Configuration.SiteUrl;

            Uri uri = new Uri(url);
            WebDriver.Navigate().GoToUrl(uri);
        }

        public bool ValidarConteudoUrl(string conteudo)
        {
            return Wait.Until(ExpectedConditions.UrlContains(conteudo));
        }

        public void ClicarLinkPorTexto(string linkText)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText)));
            link.Click();
        }

        public void ClicarBotaoPorId(string botaoId)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(botaoId)));
            botao.Click();
        }

        public void ClicarPorXPath(string xPath)
        {
            try
            {
                var elemento = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
                elemento.Click();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClicarQuickFormPorXPath(string xPath, string Name)
        { 
            var elemento1 = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            elemento1.Click();
            var elemento = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(Name)));
            elemento.Click();
        }

        public IWebElement ObterElementoPorClasse(string classeCss)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(classeCss)));
        }

        public IWebElement ObterElementoPorXPath(string xPath)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

        public void ScrollDow(int tabs = 1)
        {
            for (int count = 0; count < tabs - 1; count++)
            {
                CurrentFrame.ActiveElement().SendKeys(Keys.Tab);
            }
            CurrentFrame.ActiveElement().SendKeys(Keys.PageDown);
        }

        public void PreencherTextBoxPorId(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            campo.Click();
            campo.SendKeys(valorCampo);
        }

        public void ClearTextBoxPorId(string idCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            campo.Clear();
        }

        public void PreencherTextBoxPorXPath(string XPath, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(XPath)));
            campo.Click();
            campo.SendKeys(valorCampo);
        }

        public void PreencherTextBoxPorName(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(idCampo)));
            campo.Clear();
            campo.SendKeys(valorCampo);
        }

        public void PreencherDropDownPorId(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            var selectElement = new SelectElement(campo);
            selectElement.SelectByValue(valorCampo);
        }

        public void PreencherDropDownPorName(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(idCampo)));
            var selectElement = new SelectElement(campo);
            selectElement.SelectByValue(valorCampo);
        }

        public string ObterTextoElementoPorClasseCss(string className)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;
        }

        public string ObterTextoElementoPorId(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }

        public string ObterValorTextBoxPorId(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)))
                .GetAttribute("value");
        }

        public IEnumerable<IWebElement> ObterListaPorClasse(string className)
        {
            return Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(className)));
        }

        public bool ValidarSeElementoExistePorIr(string id)
        {
            return ElementoExistente(By.Id(id));
        }

        public void VoltarNavegacao(int vezes = 1)
        {
            for (var i = 0; i < vezes; i++)
            {
                WebDriver.Navigate().Back();
            }
        }

        public void ObterScreenShot(string actionName, string feature)
        {
            var path = $"{Configuration.FolderPath}{Configuration.FolderPicture}//{feature}//";
            CreateFolder(path);

            var fileName = $"{DateTime.Now.ToFileTime()}_{actionName}.png";
            SaveScreenShot(WebDriver.TakeScreenshot(), $"{path}{fileName}");
        }

        private void SaveScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile($"{fileName}", ScreenshotImageFormat.Png);
        }

        private void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private bool ElementoExistente(By by)
        {
            try
            {
                WebDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Dispose()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}