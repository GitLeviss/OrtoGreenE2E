using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtogreenE2E.runner
{
    public class TestBase
    {

        private IPlaywright? playwright;
        private IBrowser? browser;
        private IBrowserContext? context;

        protected async Task<IPage> OpenBrowserAsync()
        {

            playwright = await Playwright.CreateAsync();

            // Detecta CI (Azure DevOps define TF_BUILD=true)
            var isCi = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"))
            || string.Equals(Environment.GetEnvironmentVariable("TF_BUILD"), "True", StringComparison.OrdinalIgnoreCase);

            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = false, // Headless no CI, pode ser false local
                                  //Headless = isCi,
                Args = new[] { "--no-sandbox", "--disable-dev-shm-usage" }
            };

            var contextOptions = new BrowserNewContextOptions()
            {
                ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 },
                IgnoreHTTPSErrors = true
            };

            browser = await playwright.Chromium.LaunchAsync(launchOptions);
            context = await browser.NewContextAsync(contextOptions);
            var page = await context.NewPageAsync();

            var config = new ConfigurationManager();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var linkOrtogreen = config["Links:Ortogreen"] ?? throw new InvalidOperationException("Ortogreen link not found in configuration");
            await page.GotoAsync(linkOrtogreen);
            return page;
        }

        protected async Task CloseBrowserAsync()
        {
            if (context != null)
                await context.CloseAsync();
            if (browser != null)
                await browser.CloseAsync();
            playwright?.Dispose();
        }

    }
}