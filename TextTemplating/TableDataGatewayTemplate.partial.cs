using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    public partial class TableDataGatewayTemplate
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public TableDataGatewayTemplate(TableDataGatewaysContext context, EntitiesContext entity)
        {
            this._context = context;
            this._entity = entity;
        }
        
        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        protected TableDataGatewaysContext Context
        {
            get { return this._context; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected EntitiesContext Entity
        {
            get { return this._entity; }
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