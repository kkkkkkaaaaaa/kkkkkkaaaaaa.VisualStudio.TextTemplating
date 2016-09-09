using System.Collections.Generic;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class TableDataGatewaysContext : TextTemplatingContext
    {
        public string TableName { get; set; }

        public IEnumerable<SqlColumnsSchemaEntity> Columns { get; set; }

        public string EntityName { get; set; }
    }
}