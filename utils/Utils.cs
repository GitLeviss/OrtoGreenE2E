
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace OrtogreenE2E.utils
{
    public class Utils
    {
        private readonly IPage page;
        public Utils(IPage page)
        {
            this.page = page;
        }

        [AllureStep("Write on step: {step}")]
        public async Task Write(string locator, string text, string step)
        {
            try
            {
                var elemento = page.Locator(locator);
                await elemento.WaitForAsync();
                await elemento.FillAsync(text);
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + " to write on step: " + step);
            }
        }
        
        [AllureStep("Click on step: {step}")]
        public async Task Click(string locator, string step, bool getByText = false)
        {
            try
            {
                string text = locator;
                if (getByText is true && !string.IsNullOrWhiteSpace(text))
                {
                    var elementoPorTexto = page.GetByText(locator);
                    await elementoPorTexto.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                    await elementoPorTexto.ClickAsync();
                    return;
                }

                var elemento = page.Locator(locator);
                await elemento.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                await elemento.ClickAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + " to click on step: " + step);
            }
        }

        [AllureStep("Validate Url on step: {step}")]
        public async Task ValidateUrl(string expectedUrl, string step)
        {
            try
            {
                await Expect(page).ToHaveURLAsync(expectedUrl);
            }
            catch
            {
                throw new PlaywrightException($"Don´t possible validate the url: {expectedUrl} on step: {step}");
            }
        }
        [AllureStep("Select Option on step: {step}")]
        public async Task SelectOptionAsync(string locator, string option, string step)
        {
            try
            {
                await page.Locator(locator).SelectOptionAsync(option);
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + " to select option on step: " + step);
            }
        }
        [AllureStep("Validate Text Visible On Screen on step: {step}")]
        public async Task ValidateTextIsVisibleOnScreen(string expectedText, string step)
        {
            try
            {
                ILocator text = page.GetByText(expectedText);
                await Expect(text).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Don´t possible found the text: {expectedText}, on screen" + ex.Message);
            }
        }







    }
}
