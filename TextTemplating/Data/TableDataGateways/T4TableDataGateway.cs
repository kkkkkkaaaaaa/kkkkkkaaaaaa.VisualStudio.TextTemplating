using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

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
            var reader = T4TableDataGateway.Factory.CreateReader(connection);

            reader.CommandText = string.Format(@"SELECT TOP 0 * FROM {0} WHERE 1 <> 1", tableName);

            reader.ExecuteReader(CommandBehavior.SchemaOnly);

            return reader;
        }

        #region Protected members...

        protected static T4ProviderFactory Factory
        {
            get { return T4ProviderFactory.Instance; }
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
            T4TableDataGateway.DoNOthing();
        }

        #endregion
    }
}
