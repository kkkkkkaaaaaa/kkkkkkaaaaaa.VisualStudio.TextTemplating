using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    /// <summary>
    /// EntityTemplate の部分クラスを表します。
    /// </summary>
	public partial class EntityTemplate
	{
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
		public EntityTemplate(EntitiesContext context)
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
