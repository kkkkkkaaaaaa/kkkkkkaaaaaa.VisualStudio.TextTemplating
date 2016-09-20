using System.Collections.Generic;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class T4SqlStoredProcedureContext : TextTemplatingContext
    {
        public string SchemaName { get; set; }

        public string TableName { get; set; }

        public string ProcedureNamePrefix { get; set; }

        public IEnumerable<ColumnsSchemaEntity> Columns { get; set; }
    }
}