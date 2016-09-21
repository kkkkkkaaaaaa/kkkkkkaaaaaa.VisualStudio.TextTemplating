using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    /// <summary></summary>
    public partial class TableDataGatewayTemplate
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public TableDataGatewayTemplate(TableDataGatewaysContext context)
        {
            this._context = context;
        }
        
        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        protected TableDataGatewaysContext Context
        {
            get { return this._context; }
        }

        #endregion

        #region Private members...

        /// <summary></summary>
        private readonly TableDataGatewaysContext _context;
        /// <summary></summary>
        private readonly EntitiesContext _entity;

        #endregion
    }
}