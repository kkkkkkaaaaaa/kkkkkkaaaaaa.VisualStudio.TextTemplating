using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    public class SchemaService
    {
        /// <summary>
        /// 現在のデータベースのテーブルのスキーマを取得して返します。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TableSchemaEntity> GetTablesSchema()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this._factory.CreateConnection();
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
        /// GetColumnsSchemaAsync() の非同期バージョンです。
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ColumnsSchemaEntity>> GetColumnsSchemaAsync(string tableName)
        {
            var connection = default(DbConnection);

            try
            {
                connection = this._factory.CreateConnection();
                await connection.OpenAsync();

                var schema = new SchemaRepository();
                var columns = await schema.GetColumnsSchemaAsync(tableName, connection);

                return columns;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


        /// <summary>
        /// 列のスキーマを取得して返します。
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IEnumerable<ColumnsSchemaEntity> GetColumnsSchema(string tableName)
        {
            var connection = default(DbConnection);

            try
            {
                connection = this._factory.CreateConnection();
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
        /// 列のスキーマを取得して返します。
        /// </summary>
        /// <param name="tableName">テーブル名。</param>
        /// <returns>DataTableReader()</returns>
        public async Task<DbDataReader> GetColumnsSchemaTableAsync(string tableName)
        {
            var connection = default(DbConnection);

            try
            {
                connection = this._factory.CreateConnection();
                await connection.OpenAsync();

                var schema = new SchemaRepository();
                var columns = await schema.GetColumnsSchemaTableAsync(tableName, connection);

                return new DataTableReader(columns);
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        #region Private members...

        /// <summary></summary>
        private DbProviderFactory _factory = TextTemplatingProviderFactory.Instance;

        #endregion
    }
}
