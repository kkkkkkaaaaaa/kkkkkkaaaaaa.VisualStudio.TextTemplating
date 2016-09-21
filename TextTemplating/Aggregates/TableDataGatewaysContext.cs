using System.Collections.Generic;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary>
    /// 
    /// </summary>
    public class TableDataGatewaysContext : TextTemplatingContext
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntitiesContext CurrentEntity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<EntitiesContext> Entities { get; set; }
    }
}