using System.Collections.Generic;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    public class NotifyPropertyChangedContext : TextTemplatingContext
    {
        public IEnumerable<ColumnsSchemaEntity> Columns { get; set; }
    }
}