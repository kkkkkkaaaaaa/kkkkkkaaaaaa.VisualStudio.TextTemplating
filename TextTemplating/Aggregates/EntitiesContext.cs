using System.Collections.Generic;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary>
    /// Entity を生成するコンテキストを表します。
    /// </summary>
    public class EntitiesContext : TextTemplatingContext
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 列のメタデータを取得または設定します。
        /// </summary>
        public IEnumerable<ColumnsSchemaEntity> Columns { get; set; }
    }
}
