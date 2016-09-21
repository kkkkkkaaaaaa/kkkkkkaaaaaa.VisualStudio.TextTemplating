using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.TableDataGateways;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class SchemaRepository : TextTemplatingRepository
    {
        /// <summary>
        /// 現在のカタログのテーブル定義を取得して返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public IEnumerable<TableSchemaEntity> GetTablesSchema(DbConnection connection)
        {
            var schema = connection.GetTablesSchema();
            var reader = new DataTableReader(schema);

            // TODO: KandaDbDataMapper.MapToEnumerableAsync<T>()
            var tables = KandaDbDataMapper.MapToEnumerable<TableSchemaEntity>(reader);

            return tables;
        }
        
        /// <summary>
        /// 列のスキーマを取得して返します。
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public IEnumerable<ColumnsSchemaEntity> GetColumnsSchema(string tableName, DbConnection connection)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = SchemaGateway.SelectEmptyTable(tableName, connection);

                var schema = reader.GetSchemaTable();

                // TODO: KandaDbDataMapper.MapToEnumerableAsync<T>()
                var columns = KandaDbDataMapper.MapToEnumerable<ColumnsSchemaEntity>(schema);

                return columns;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// GetColumnsSchema() の非同期バージョンです。
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ColumnsSchemaEntity>> GetColumnsSchemaAsync(string tableName, DbConnection connection)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = await SchemaGateway.SelectEmptyTableAsync(tableName, connection);

                var schema = reader.GetSchemaTable();

                // TODO: KandaDbDataMapper.MapToEnumerableAsync<T>()
                var columns = KandaDbDataMapper.MapToEnumerable<ColumnsSchemaEntity>(schema);

                return columns;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// GetColumnsSchema() の非同期バージョンです。
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public async Task<DataTable> GetColumnsSchemaTableAsync(string tableName, DbConnection connection)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = await SchemaGateway.SelectEmptyTableAsync(tableName, connection);

                var schema = reader.GetSchemaTable();

                return schema;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        #region Private members...

        #endregion
    }
}