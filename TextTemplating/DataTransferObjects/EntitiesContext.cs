using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class EntitiesContext : TextTemplatingContext
    {
        public bool IsPartial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] Implements { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SqlColumnsSchemaEntity> Columns { get; set; }
    }
}
