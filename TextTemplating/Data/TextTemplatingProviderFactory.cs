using System;
using System.Configuration;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTemplatingProviderFactory : KandaDbProviderFactory
    {
        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        public static TextTemplatingProviderFactory Instance
        {
            get { return TextTemplatingProviderFactory._instance.Value; }
        }

        /// <summary>
        /// データーベースへの接続を生成して返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            var section = ConfigurationManager.ConnectionStrings[@"redmine"];

            var connection = base.CreateConnection();
            connection.ConnectionString = section.ConnectionString;

            return connection;
        }

        #region Protected members...

        /// <summary>
        /// コンストラクター。
        /// </summary>
        protected TextTemplatingProviderFactory() : base(DbProviderFactories.GetFactory(@"MySql.Data.MySqlClient"))
        {
            this.DoNothing();
        }

        #endregion

        #region Private members...

        /// <summary>
        /// Instance のバッキングフィールド。
        /// </summary>
        private static readonly Lazy<TextTemplatingProviderFactory> _instance = new Lazy<TextTemplatingProviderFactory>(() => new TextTemplatingProviderFactory());

        #endregion
    }
}