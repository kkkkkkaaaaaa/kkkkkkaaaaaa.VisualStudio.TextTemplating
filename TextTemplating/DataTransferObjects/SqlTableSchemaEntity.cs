using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class SqlTableSchemaEntity
    {
        [KandaDataMapping(@"TABLE_SCHEMA")]
        public string TableSchema { get; set; }

        [KandaDataMapping(@"TABLE_CATALOG")]
        public string TableCatalog { get; set; }

        [KandaDataMapping(@"TABLE_NAME")]
        public string TableName { get; set; }

        [KandaDataMapping(@"TABLE_TYPE")]
        public string TableType { get; set; }
    }
}