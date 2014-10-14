using System.Diagnostics;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// プロセスにアクセスします。ｃ
    /// </summary>
    public static class T4Process
    {
        /// <summary>
        /// エクスプローラーを開始します。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Process Start(string path)
        {
            var info = new ProcessStartInfo
            {
                FileName = @"explorer.exe",
                Arguments = string.Format(@"/e, /root, ""{0}""", path),
            };

            var process = Process.Start(info);

            return process;
        }
    }
}