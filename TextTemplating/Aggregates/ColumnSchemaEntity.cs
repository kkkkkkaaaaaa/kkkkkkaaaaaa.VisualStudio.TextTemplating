using System;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    public class ColumnsSchemaEntity
    {
        public string ColumnName { get; set; }

        public Type DataType { get; set; }

        public string DataTypeName { get; set; }

        public int ColumnSize { get; set; }

        public int NumericScale { get; set; }
    }
}