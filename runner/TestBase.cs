//testbase

using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using OrtoGreenE2E.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.utils;

namespace OrtogreenE2E.runner
{
    public class TestBase
    {
        protected IPage page;
        private IPlaywright? playwright;
        private IBrowser? browser;
        private IBrowserContext? context;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            VideoHelper.ClearOldVideos();
        }

        protected async Task<IPage> OpenBrowserAsync()
        {
            playwright = await Playwright.CreateAsync();

            var isCi = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI")) ||
                       string.Equals(Environment.GetEnvironmentVariable("TF_BUILD"), "True", StringComparison.OrdinalIgnoreCase);

            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = true,
                Args = new[] { "--no-sandbox", "--disable-dev-shm-usage" }
            };

            browser = await playwright.Chromium.LaunchAsync(launchOptions);

            var videosDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "videos");
            Directory.CreateDirectory(videosDir);

            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
                IgnoreHTTPSErrors = true,
                RecordVideoDir = videosDir,
                RecordVideoSize = new RecordVideoSize { Width = 1366, Height = 768 }
            };

            context = await browser.NewContextAsync(contextOptions);
            page = await context.NewPageAsync();

            var config = new ConfigurationManager();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var linkPortal = config["Links:Ortogreen"];
            await page.GotoAsync(linkPortal!);
            await page.EvaluateAsync("document.body.style.zoom='75%';");


            return page;
        }

        protected async Task CloseBrowserAsync()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();

            try
            {
                await VideoUtils.ForceVideoFinalization(page);

                if (context != null)
                {
                    await context.CloseAsync();
                }

                await VideoHelper.AttachVideoAsync(page, status);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar v�deo no teardown: {ex.Message}");
            }
            finally
            {
                try
                {
                    if (browser != null)
                    {
                        await browser.CloseAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao fechar browser: {ex.Message}");
                }

                try
                {
                    playwright?.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao dispose playwright: {ex.Message}");
                }
            }
        }


    }
}