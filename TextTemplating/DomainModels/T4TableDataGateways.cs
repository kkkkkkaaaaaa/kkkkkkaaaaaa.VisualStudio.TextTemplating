using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    public class T4TableDataGateways : T4DomainModel<T4TableDataGatewayContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public T4TableDataGateways(T4TableDataGatewayContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// TableDataGateway を生成します。
        /// </summary>
        /// <returns></returns>
        public T4TableDataGateways CreateGateways()
        {


            return this;
        }
    }
}