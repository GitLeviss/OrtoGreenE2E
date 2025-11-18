using Microsoft.Playwright;

namespace zCustodiaUi.utils
{
    public static class VideoUtils
    {
        /// <summary>
        /// Força a finalização da gravação de vídeo antes do teardown
        /// </summary>
        public static async Task ForceVideoFinalization(IPage page)
        {
            try
            {
                // Espera um pouco para garantir que todas as operações foram concluídas
                await Task.Delay(500);

                // Tenta forçar a renderização final
                await page.EvaluateAsync("() => document.body.style.backgroundColor = 'transparent'");
                await Task.Delay(200);
                await page.EvaluateAsync("() => document.body.style.backgroundColor = ''");
            }
            catch
            {
                // Ignora erros, é apenas uma tentativa de garantir a finalização
            }
        }

        /// <summary>
        /// Verifica se o vídeo está sendo gravado corretamente
        /// </summary>
        public static async Task<bool> IsVideoRecording(IPage page)
        {
            try
            {
                var video = page.Video;
                if (video == null) return false;

                var path = await video.PathAsync();
                return !string.IsNullOrEmpty(path);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Aguarda um pouco e verifica o estado do vídeo
        /// </summary>
        public static async Task WaitForVideoStabilization(IPage page, int maxWaitMs = 3000)
        {
            int elapsed = 0;
            int checkInterval = 500;

            while (elapsed < maxWaitMs)
            {
                if (await IsVideoRecording(page))
                {
                    await Task.Delay(checkInterval);
                    elapsed += checkInterval;
                }
                else
                {
                    break;
                }
            }
        }
    }
}