using System.Diagnostics;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics
{
    /// <summary>
    /// プロセスへのアクセスを提供するクラスです。
    /// </summary>
    public static class TextTemplatingProcess
    {
        /// <summary>
        /// エクスプローラーで指定したパスを開きます。
        /// </summary>
        /// <param name="path">開くパス。</param>
        /// <returns></returns>
        public static Process StartExplorer(string path)
        {
            var info = new ProcessStartInfo
            {
                FileName = @"explorer.exe",
                Arguments = string.Format(@"/e, ""{0}""", path),
            };

            var process = Process.Start(info);

            return process;
        }
    }
}