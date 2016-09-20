using System.Collections.Generic;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    public class TableDataGatewaysContext : TextTemplatingContext
    {
        public string TableName { get; set; }

        public IEnumerable<ColumnsSchemaEntity> Columns { get; set; }

        public string EntityName { get; set; }
    }
}