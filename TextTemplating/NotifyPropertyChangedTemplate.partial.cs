using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NotifyPropertyChangedTemplate
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public NotifyPropertyChangedTemplate(EntitiesContext context)
        {
            this._context = context;
        }

        public EntitiesContext Context
        {
            get { return this._context; }
        }

        #region Private members...

        /// <summary></summary>
        private readonly EntitiesContext _context;

        #endregion

    }
}