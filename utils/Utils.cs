
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

        public async Task Click(string locator, string step)
        {
            try
            {
                var elemento = page.Locator(locator);
                await elemento.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                await elemento.ClickAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t Possible Found the element: " + locator + " to click on step: " + step);
            }
        }


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
        public async Task SelectOptionAsync(string locator,string option, string step)
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









    }
}
