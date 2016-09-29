using System.Collections.Generic;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary></summary>
    public class NotifyPropertyChangedContext : EntitiesContext
    {
        /// <summary></summary>
        public EntitiesContext CurrentEntity { get; set; }

        /// <summary></summary>
        public IEnumerable<ColumnsSchemaEntity> CurrentColumn { get; set; }

        /// <summary></summary>
        public IEnumerable<EntitiesContext> Entities { get; set; }
    }
}