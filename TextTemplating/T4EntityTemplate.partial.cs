using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
	public partial class T4EntityTemplate
	{
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
		public T4EntityTemplate(EntitiesContext context)
		{
			this._context = context;
		}

        #region Protected members...

        /// <summary>
        /// コンテキストを取得します。
        /// </summary>
        protected EntitiesContext Context
        {
            get { return this._context; }
        }

        #endregion

        #region Private members...

        /// <summary></summary>
        private readonly EntitiesContext _context;

        #endregion
	}
}