using System;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class T4ProviderFactory : KandaDbProviderFactory
    {
        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        public static T4ProviderFactory Instance
        {
            get { return T4ProviderFactory._instance.Value; }
        }

        /// <summary>
        /// データーベースへの接続を生成して返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            var builder = base.CreateConnectionStringBuilder();
            builder.Add(@"Server", @"(local)");
            builder.Add(@"Initial Catalog", @"kkkkkkaaaaaa");
            builder.Add(@"Integrated Security", @"True");

            var connection = base.CreateConnection();
            connection.ConnectionString = builder.ConnectionString;

            return connection;
            // return base.CreateConnection();
        }

        #region Protected members...

        /// <summary>
        /// コンストラクター。
        /// </summary>
        protected T4ProviderFactory() : base(DbProviderFactories.GetFactory(@"System.Data.SqlClient"))
        {
            this.DoNothing();
        }

        #endregion

        #region Private members...

        /// <summary>
        /// Instance のバッキングフィールド。
        /// </summary>
        private static readonly Lazy<T4ProviderFactory> _instance = new Lazy<T4ProviderFactory>(() => new T4ProviderFactory());

        #endregion
    }
}