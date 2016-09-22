namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary>
    /// このアプリケーションの集約を表すマーカーインターフェイスです。
    /// </summary>
    public interface ITextTemplatingAggregate
    {
        /// <summary>
        /// ファイルを出力するパスを取得または設定します。
        /// </summary>
        string OutputPath { get; set; }

    }
}
