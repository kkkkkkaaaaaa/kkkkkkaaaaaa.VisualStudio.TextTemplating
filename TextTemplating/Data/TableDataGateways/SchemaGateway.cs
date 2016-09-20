using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.TableDataGateways
{
    public /* static */  class SchemaGateway : TextTemplatingGateway
    {
        /// <summary>
        /// 列のスキーマ取得のため空のテーブルを取得して返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DbDataReader SelectEmptyTable(string tableName, DbConnection connection)
        {
            var reader = TextTemplatingGateway.Factory.CreateReader(connection);

            reader.CommandText = string.Format(@"SELECT * FROM {0} WHERE 1 <> 1", tableName);

            reader.ExecuteReader(CommandBehavior.SchemaOnly);

            return reader;
        }

        /// <summary>
        /// SelectEmptyTable() の非同期バージョンです。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static async Task<DbDataReader> SelectEmptyTableAsync(string tableName, DbConnection connection)
        {
            var reader = TextTemplatingGateway.Factory.CreateReader(connection);

            reader.CommandText = string.Format(@"SELECT * FROM {0} WHERE 1 <> 1", tableName);

            await reader.ExecuteReaderAsync(CommandBehavior.SchemaOnly);

            return reader;
        }
    }
}