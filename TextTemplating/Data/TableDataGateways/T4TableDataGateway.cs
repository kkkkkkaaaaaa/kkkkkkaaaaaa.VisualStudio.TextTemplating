using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.TableDataGateways
{
    /// <summary>
    /// 
    /// </summary>
    public class T4TableDataGateway
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DbDataReader GetColumnsSchema(string tableName, DbConnection connection)
        {
            var reader = Factory.CreateReader(connection);

            reader.CommandText = string.Format(@"SELECT * FROM {0} WHERE 1 <> 1", tableName);

            reader.ExecuteReader(CommandBehavior.SchemaOnly);

            return reader;
        }

        #region Protected members...

        protected static TextTemplatingProviderFactory Factory
        {
            get { return TextTemplatingProviderFactory.Instance; }
        }

        /// <summary>
        /// 何もしません。
        /// </summary>
        protected static void DoNOthing()
        {
            // 何もしない
        }

        #endregion

        #region  Private membes...

        /// <summary>
        /// コンストラクター。
        /// </summary>
        private T4TableDataGateway()
        {
            DoNOthing();
        }

        #endregion
    }
}
