using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
	public partial class T4EntityTemplate
	{
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
		public T4EntityTemplate(T4EntityContext context)
		{
			this._context = context;
		}

        #region Protected members...

        /// <summary>
        /// コンテキストを取得します。
        /// </summary>
        protected T4EntityContext Context
        {
            get { return this._context; }
        }

        #endregion

        #region Private members...

        /// <summary></summary>
        private readonly T4EntityContext _context;

        #endregion
	}
}