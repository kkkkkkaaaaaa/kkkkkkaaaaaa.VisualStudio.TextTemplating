using System.Diagnostics;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
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
                Arguments = $@"/e, ""{path}""",
            };

            var process = Process.Start(info);

            return process;
        }
    }
}