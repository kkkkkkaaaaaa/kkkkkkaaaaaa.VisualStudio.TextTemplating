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

        private T4SqlStoredProcedureContext _context;
    }
}