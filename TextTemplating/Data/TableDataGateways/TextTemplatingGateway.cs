using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.TableDataGateways
{
    /// <summary>
    /// Table Data Gateway の Layer Super Type です。
    /// </summary>
    public class TextTemplatingGateway
    {
        /// <summary>
        /// 列のスキーマ取得のため空のテーブルを取得して返します。
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
        private TextTemplatingGateway()
        {
            DoNOthing();
        }

        #endregion
    }
}
