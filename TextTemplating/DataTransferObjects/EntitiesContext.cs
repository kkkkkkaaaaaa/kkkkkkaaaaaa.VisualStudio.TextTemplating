using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class EntitiesContext : T4Context
    {
        public string Inherits { get; set; }

        public string Implements { get; set; }

        public IEnumerable<SqlColumnsSchemaEntity> Columns { get; set; }
    }
}
