using System.Collections.Generic;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class T4SqlStoredProcedureContext : T4Context
    {
        public string SchemaName { get; set; }

        public string TableName { get; set; }

        public string ProcedureNamePrefix { get; set; }

        public IEnumerable<SqlColumnSchemaEntity> Columns { get; set; }
    }
}