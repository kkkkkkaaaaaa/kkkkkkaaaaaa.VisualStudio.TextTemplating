using System;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class SqlColumnSchemaEntity
    {
        public string ColumnName { get; set; }

        public Type DataType { get; set; }

        public string DataTypeName { get; set; }

        public int ColumnSize { get; set; }

        public int NumericScale { get; set; }
    }
}