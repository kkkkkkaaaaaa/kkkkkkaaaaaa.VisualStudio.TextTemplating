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

        protected string GetParameter(SqlColumnSchemaEntity column, int index)
        {
            var parameter = string.Format(@"@{0}", column.ColumnName.ToLower());

            if (new[] {@"nvarchar", @"varchar",}.Any(t => t == column.DataTypeName))
            {
                parameter = string.Format(@"{0} {1}({2})", parameter, column.DataTypeName, column.ColumnSize);
            }
            else if (new[] {@"money", @"numeric", @"decimal",}.Any(t => t == column.DataTypeName))
            {
                parameter = string.Format(@"{0} {1}({2})", parameter, column.DataTypeName, column.ColumnSize);
            }
            else if (new[] {@"datetime2", @"datetime",}.Any(t => t == column.DataTypeName))
            {
                parameter = string.Format(@"{0} {1}({2})", parameter, column.DataTypeName, column.NumericScale);
            }
            else
            {
                parameter = string.Format(@"{0} {1}", parameter, column.DataTypeName);
            }

            if (index > 0) { parameter = string.Format(@", {0}", parameter); }

            parameter = string.Format(@"    {0}", parameter);

            return parameter;
        }

        private T4SqlStoredProcedureContext _context;
    }
}