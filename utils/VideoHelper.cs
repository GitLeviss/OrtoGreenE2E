using Allure.Net.Commons;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.utils
{
    public static class VideoHelper
    {
        private static string VideosDir => Path.Combine(TestContext.CurrentContext.TestDirectory, "videos");

        public static void ClearOldVideos()
        {
            if (Directory.Exists(VideosDir))
            {
                try
                {
                    Directory.Delete(VideosDir, true);
                }
                catch
                {
                }
            }

            Directory.CreateDirectory(VideosDir);
        }

        public static async Task AttachVideoAsync(IPage page, string testStatus)
        {
            if (page == null)
            {
                return;
            }

            try
            {
                var video = page.Video;
                if (video == null)
                {
                    Console.WriteLine("Nenhum vídeo associado à página.");
                    return;
                }

                var videoPath = await video.PathAsync();
                if (string.IsNullOrWhiteSpace(videoPath) || !File.Exists(videoPath))
                {
                    Console.WriteLine($"Caminho de vídeo inválido: {videoPath}");
                    return;
                }

                var testName = GetTestName();
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var extension = Path.GetExtension(videoPath);
                var finalFileName = $"{testName}_{testStatus}_{timestamp}{extension}";
                var finalPath = Path.Combine(VideosDir, finalFileName);

                Directory.CreateDirectory(VideosDir);
                File.Copy(videoPath, finalPath, true);

                var fileInfo = new FileInfo(finalPath);
                if (fileInfo.Length <= 0)
                {
                    Console.WriteLine($"Arquivo de vídeo vazio: {finalPath}");
                    return;
                }

                AllureApi.AddAttachment($"Video - {testStatus}", "video/mp4", finalPath);
                Console.WriteLine($"Vídeo anexado: {finalFileName} ({fileInfo.Length} bytes)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao anexar vídeo: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
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
    }

}

