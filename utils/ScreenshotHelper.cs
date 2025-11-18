using Allure.Net.Commons;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.utils
{
    public static class ScreenshotHelper
    {
        private static readonly string ScreenshotsDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "screenshots");

        static ScreenshotHelper()
        {
            if (!Directory.Exists(ScreenshotsDir))
            {
                Directory.CreateDirectory(ScreenshotsDir);
            }
        }

        public static void ClearOldScreenshots()
        {
            if (Directory.Exists(ScreenshotsDir))
            {
                var files = Directory.GetFiles(ScreenshotsDir, "*.png");
                foreach (var file in files)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {
                        // Ignora erros ao deletar arquivos
                    }
                }
            }
        }

        public static async Task CaptureAndAttachScreenshotAsync(IPage page, string testName, string stats)
        {
            try
            {
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var fileName = $"{testName}_{timestamp}.png";
                var filePath = Path.Combine(ScreenshotsDir, fileName);

                await page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = filePath,
                    FullPage = true
                });

                AllureApi.AddAttachment(stats, "image/png", filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao capturar screenshot: {ex.Message}");
            }
        }

        public static string GetTestName()
        {
            var testContext = TestContext.CurrentContext;
            return $"{testContext.Test.ClassName}_{testContext.Test.Name}"
                .Replace(" ", "_")
                .Replace(".", "_")
                .Replace(":", "_")
                .Replace("\"", "")
                .Replace("'", "")
                .Replace("/", "_")
                .Replace("\\", "_");
        }

        public static async Task CaptureAssertionScreenshotAsync(IPage page, string assertionName, string stepDescription)
        {
            try
            {
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var fileName = $"ASSERTION_{assertionName}_{timestamp}.png";
                var filePath = Path.Combine(ScreenshotsDir, fileName);

                await page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = filePath,
                    FullPage = true
                });

                AllureApi.AddAttachment($"Assertion: {assertionName} - {stepDescription}", "image/png", filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao capturar screenshot de asserção: {ex.Message}");
            }
        }

        public static async Task AssertWithScreenshotAsync(IPage page, Func<Task> assertionAction, string assertionName, string stepDescription)
        {
            try
            {
                await assertionAction();
                await CaptureAssertionScreenshotAsync(page, assertionName, stepDescription);
            }
            catch (Exception ex)
            {
                await CaptureAssertionScreenshotAsync(page, $"{assertionName}_FAILED", stepDescription);
                throw;
            }
        }
    }
}
