using System.Diagnostics;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics
{
    /// <summary>
    /// プロセスにアクセスします。ｃ
    /// </summary>
    public static class TextTemplatingProcess
    {
        /// <summary>
        /// エクスプローラーを開始します。
        /// </summary>
        /// <param name="path"></param>
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