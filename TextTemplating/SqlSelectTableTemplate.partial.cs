using System;
using System.Linq;
using System.Security.Policy;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    public partial class SqlSelectTableTemplate
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public SqlSelectTableTemplate(T4SqlStoredProcedureContext context)
        {
            this._context = context;
        }

        protected T4SqlStoredProcedureContext Context
        {
            get { return this._context; }
        }

        protected string GetParameter(SqlColumnsSchemaEntity columns, int index)
        {
            var parameter = string.Format(@"@{0}", columns.ColumnName.ToLower());

            if (new[] {@"nvarchar", @"varchar",}.Any(t => t == columns.DataTypeName))
            {
                parameter = string.Format(@"{0} {1}({2})", parameter, columns.DataTypeName, columns.ColumnSize);
            }
            else if (new[] {@"money", @"numeric", @"decimal",}.Any(t => t == columns.DataTypeName))
            {
                parameter = string.Format(@"{0} {1}({2})", parameter, columns.DataTypeName, columns.ColumnSize);
            }
            else if (new[] {@"datetime2", @"datetime",}.Any(t => t == columns.DataTypeName))
            {
                parameter = string.Format(@"{0} {1}({2})", parameter, columns.DataTypeName, columns.NumericScale);
            }
            else
            {
                parameter = string.Format(@"{0} {1}", parameter, columns.DataTypeName);
            }

            if (index > 0) { parameter = string.Format(@", {0}", parameter); }

            parameter = string.Format(@"    {0}", parameter);

            return parameter;
        }

        private T4SqlStoredProcedureContext _context;
    }
}