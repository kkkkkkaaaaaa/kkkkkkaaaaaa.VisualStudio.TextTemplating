using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.TableDataGateways;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

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
        public IEnumerable<SqlTableSchemaEntity> GetTablesSchema(DbConnection connection)
        {
            var schema = connection.GetTablesSchema();
            var reader = new DataTableReader(schema);

            var tables = KandaDbDataMapper.MapToEnumerable<SqlTableSchemaEntity>(reader);

            return tables;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public IEnumerable<ColumnsSchemaEntity> GetColumnsSchema(string tableName, DbConnection connection)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = TextTemplatingGateway.GetColumnsSchema(tableName, connection);

                var schema = reader.GetSchemaTable();

                var columns = KandaDbDataMapper.MapToEnumerable<ColumnsSchemaEntity>(schema);

                return columns;
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