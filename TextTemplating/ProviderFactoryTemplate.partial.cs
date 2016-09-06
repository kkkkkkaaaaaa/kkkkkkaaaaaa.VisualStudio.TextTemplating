using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProviderFactoryTemplate
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public ProviderFactoryTemplate(ProviderFactoryContext context)
        {
            this._context = context;
        }

        #region Protectd members...

        /// <summary>
        /// 
        /// </summary>
        protected ProviderFactoryContext Context
        {
            get { return _context; }
        }

        #endregion

        #region Private members...

        /// <summary>Context のバッキングフィールド。</summary>
        private readonly ProviderFactoryContext _context;

        #endregion
    }
}