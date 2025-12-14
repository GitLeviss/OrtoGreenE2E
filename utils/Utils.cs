
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
                var element = page.Locator(locator);
                await Expect(element).ToBeVisibleAsync();
                await Expect(element).ToBeEnabledAsync();
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await element.FocusAsync();
                await element.FillAsync(text);
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t Possible write on element: {locator} on step: {step} Details: {ex.Message}");
            }
        }
        public async Task WriteCredentials(string locator, string text, string step)
        {
            try
            {
                var elemento = page.Locator(locator);
                await elemento.WaitForAsync();
                await elemento.FillAsync(text);
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t Possible write on element: {locator} on step: {step} Details: {ex.Message}");
            }
        }
        [AllureStep("Clear on step: {step}")]
        public async Task Clear(string locator, string step)
        {
            try
            {
                var elemento = page.Locator(locator);
                await elemento.WaitForAsync();
                await elemento.ClearAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t Possible clear on element: {locator} on step: {step} Details: {ex.Message}");
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
                    var textElement = page.GetByText(locator);
                    await textElement.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                    await textElement.ClickAsync();
                    return;
                }

                var element = page.Locator(locator);

                await Expect(element).ToBeVisibleAsync();
                await Expect(element).ToBeEnabledAsync();
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await element.ClickAsync(new LocatorClickOptions
                {
                    Timeout = 60000
                });
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t Possible click on element: {locator} on step: {step} Details: {ex.Message}");
            }
        }

        [AllureStep("Validate Url on step: {step}")]
        public async Task ValidateUrl(string expectedUrl, string step)
        {
            try
            {
                await Expect(page).ToHaveURLAsync(expectedUrl);
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate the url: {expectedUrl} on step: {step} Details: {ex.Message}");
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
        [AllureStep("Validate Text Visible On Screen on step: {step}")]
        public async Task ValidateTextIsNotVisibleOnScreen(string expectedText, string step)
        {
            try
            {
                ILocator text = page.GetByText(expectedText);
                await Expect(text).Not.ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Don´t possible found the text: {expectedText}, on screen" + ex.Message);
            }
        }
        [AllureStep("Validate Element Visible On Screen on step: {step}")]
        public async Task ValidateElementIsVisibleOnScreen(string locator, string step)
        {
            try
            {
                ILocator text = page.Locator(locator);
                await Expect(text).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Don´t possible found the element: {locator}, on screen" + ex.Message);
            }
        }
        [AllureStep("Get Text of element - on step: {step}")]
        public async Task<string> GetTextOfElement(string locator, string step)
        {
            try
            {
                string value = await page.Locator(locator).InnerTextAsync();

                return value;

            }
            catch (Exception ex)
            {
                throw new Exception($"{locator} does not exist. Details: {ex.Message}");
            }

        }

        [AllureStep("Get Text of element - on step: {step}")]
        public async Task GetTextOfElementConvertToIntAndCompare(string locator, int expectedValue, string step)
        {
            try
            {
                string value = await page.Locator(locator).InnerTextAsync();
                int intValue = Convert.ToInt32(value);
                Assert.That(expectedValue, Is.EqualTo(intValue));
            }
            catch (Exception ex)
            {
                throw new Exception($"{locator} does not exist. Details: {ex.Message}");
            }

        }
        [AllureStep("Get Text of element - on step: {step}")]
        public async Task GetTextOfElementAndCompare(string locator,string expectedText, string step)
        {
            try
            {
                string text = await page.Locator(locator).InnerTextAsync();
                await Expect(page.Locator(locator)).ToHaveTextAsync(expectedText);
            }
            catch (Exception ex)
            {
                throw new Exception($"{locator} does not exist. Details: {ex.Message}");
            }

        }

        [AllureStep("Scrool and maintain position - on step: {step}")]
        public async Task ScrollToElementAndMaintainPosition(string locator, string step)
        {
            try
            {
                var element = page.Locator(locator);
                await element.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                await element.ScrollIntoViewIfNeededAsync();

                // Wait for any JavaScript to settle
                await Task.Delay(1000);

                // Check if element is still visible, if not scroll again
                var isVisible = await element.IsVisibleAsync();
                if (!isVisible)
                {
                    await element.ScrollIntoViewIfNeededAsync();
                    await Task.Delay(500);
                }
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t Possible Found the element:  {locator} to scroll and maintain position on step: {step}. Details {ex.Message}");
            }
        }







    }
}
