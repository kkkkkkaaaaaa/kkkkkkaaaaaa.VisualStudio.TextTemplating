namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary>
    /// DbProviderFactory のテンプレートを生成するコンテキストを表します。
    /// </summary>
    public class ProviderFactoryContext : TextTemplatingContext
    {
        /// <summary>
        /// 
        /// </summary>
        public string InvariantName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConnectionStringSectionName { get; set; }
    }
}