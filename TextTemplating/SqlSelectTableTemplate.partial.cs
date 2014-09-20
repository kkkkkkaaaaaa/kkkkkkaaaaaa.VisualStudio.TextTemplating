using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    public partial class SqlSelectTableTemplate
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public SqlSelectTableTemplate(SqlTableContext context)
        {
            this._context = context;
        }

        protected SqlTableContext Context
        {
            get { return this._context; }
        }

        private SqlTableContext _context;
    }
}