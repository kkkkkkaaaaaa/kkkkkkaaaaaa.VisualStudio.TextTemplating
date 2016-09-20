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
        /// 分離クラスかどうかを表す値を取得または設定します。
        /// </summary>
        public bool IsPartial { get; set; }

        /// <summary>
        /// 実装するインターフェイスの配列を取得または設定します。
        /// </summary>
        public string[] Implements { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ColumnsSchemaEntity> Columns { get; set; }
    }
}
