using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    /// <summary>
    /// Repository のテンプレート。
    /// </summary>
    public partial class RepositoryTemplate
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public RepositoryTemplate (RepositoriesContext context)
        {
            this._context = context;
        }

        #region Protected members...
        
        /// <summary>
        /// 
        /// </summary>
        protected RepositoriesContext Context
        {
            get { return this._context; }
        }

        #endregion

        #region Private members...

        /// <summary></summary>
        private readonly RepositoriesContext _context;

        #endregion
    }
}