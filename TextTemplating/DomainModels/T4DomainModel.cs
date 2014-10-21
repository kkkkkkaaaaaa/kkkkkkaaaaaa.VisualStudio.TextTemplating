using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// ドメインモデルの基底クラスを表します。
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class T4DomainModel<TContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public  T4DomainModel(TContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public TContext Context
        {
            get {return this._context; }
        }

        #region Protected members...

        /// <summary>
        /// 現在のデータベースのプロバイダーのファクトリーを取得します。
        /// </summary>
        protected T4ProviderFactory Factory
        {
            get { return T4ProviderFactory.Instance; }
        }

        /// <summary>
        /// スキーマの Repository を取得します。
        /// </summary>
        protected SqlSchemaRepository SqlSchema
        {
            get { return SqlSchemaRepository.Instance; }
        }


        /// <summary>
        /// 現在のデータベースのテーブルのスキーマを取得して返します。
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<SqlTableSchemaEntity> GetTablesSchema()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this.Factory.CreateConnection();
                connection.Open();

                var tables = this.SqlSchema.GetTablesSchema(connection);

                return tables;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary>
        /// 指定したテーブルの列のスキーマを取得して返します。
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected IEnumerable<SqlColumnsSchemaEntity> GetColumnsSchema(string tableName)
        {
            var connection = default(DbConnection);

            try
            {
                connection = this.Factory.CreateConnection();
                connection.Open();

                var columns = this.SqlSchema.GetColumnsSchema(tableName, connection);

                return columns;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
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
