using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// ドメインモデルの基底クラスを表します。
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class TextTemplatingDomainModel<TContext> where TContext : ITextTemplatingAggregate
    {
        /// <summary>
        /// Entity 生成条件を取得または設定します。
        /// </summary>
        public TContext Context
        {
            get {return this._context; }
        }

        /// <summary>
        /// 出力先ディレクトリーのパスを取得します。
        /// </summary>
        public string OutputPath
        {
            [DebuggerStepThrough()]
            get { return this._context.OutputPath; }
        }

        /// <summary>
        /// スキーマサービス。
        /// </summary>
        public SchemaService Schema { get; } = new SchemaService();

        /// <summary>
        /// エンコーディング。
        /// </summary>
        public Encoding Encoding { get; } = new UTF8Encoding(true, true);

        #region Protected members...

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        [DebuggerStepThrough()]
        protected TextTemplatingDomainModel(TContext context)
        {
            this._context = context;
        }


        /// <summary>
        /// 現在のデータベースのプロバイダーのファクトリーを取得します。
        /// </summary>
        protected TextTemplatingProviderFactory Factory
        {
            get { return TextTemplatingProviderFactory.Instance; }
        }
        

        /// <summary>
        /// 指定した文字列をファイルに書き込みます。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        /// <param name="encoding"></param>
        protected void Flush(string path, string text, Encoding encoding)
        {
            var stream = default(TextWriter);

            try
            {
                stream = new StreamWriter(path, false, encoding);
                stream.Write(text);
                stream.Flush();
            }
            finally
            {
                if (stream != null) { stream.Close(); }
            }
        }

        /// <summary></summary>
        protected void Flush(string path, string text)
        {
            this.Flush(path, text, this.Encoding);
        }
        
        /// <summary>
        /// Flush() の非同期バージョンです。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        /// <param name="encoding"></param>
        protected async Task FlushAsync(string path, string text, Encoding encoding)
        {
            var stream = default(TextWriter);

            try
            {
                stream = new StreamWriter(path, false, encoding);
                await stream.WriteAsync(text);
                await stream.FlushAsync();
            }
            finally
            {
                if (stream != null) { stream.Close(); }
            }
        }

        /// <summary></summary>
        protected async Task FlushAsync(string path, string text)
        {
            await this.FlushAsync(path, text, this.Encoding);
        }

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        protected void DoNothing()
        {
            // 何もしない
        }

        #endregion

        #region Private memberes...

        /// <summary>コンテキスト。</summary>
        private readonly TContext _context;

        #endregion
    }
}
