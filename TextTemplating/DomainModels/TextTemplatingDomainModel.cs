﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// ドメインモデルの基底クラスを表します。
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class TextTemplatingDomainModel<TContext> where TContext : TextTemplatingContext
    {
        /// <summary>
        /// コンストラクター。ｓ
        /// </summary>
        /// <param name="context"></param>
        [DebuggerStepThrough()]
        public  TextTemplatingDomainModel(TContext context)
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

        /// <summary>
        /// 出力先ディレクトリーのパスを取得します。
        /// </summary>
        public string OutputPath
        {
            [DebuggerStepThrough()]
            get { return this._context.OutputPath; }
        }

        /// <summary>
        /// エンコーディング。
        /// </summary>
        public Encoding Encoding { get; } = new UTF8Encoding(true, true);

        #region Protected members...

        /// <summary>
        /// 現在のデータベースのプロバイダーのファクトリーを取得します。
        /// </summary>
        protected TextTemplatingProviderFactory Factory
        {
            get { return TextTemplatingProviderFactory.Instance; }
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

                var schema = new SchemaRepository();
                var tables = schema.GetTablesSchema(connection);

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
        protected IEnumerable<ColumnsSchemaEntity> GetColumnsSchema(string tableName)
        {
            var connection = default(DbConnection);

            try
            {
                connection = this.Factory.CreateConnection();
                connection.Open();

                var schema = new SchemaRepository();
                var columns = schema.GetColumnsSchema(tableName, connection);

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
                stream?.Close();
            }
        }

        /// <summary>
        /// 指定した文字列をファイルに書き込みます。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        protected void Flush(string path, string text)
        {
            this.Flush(path, text, this.Encoding);
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
