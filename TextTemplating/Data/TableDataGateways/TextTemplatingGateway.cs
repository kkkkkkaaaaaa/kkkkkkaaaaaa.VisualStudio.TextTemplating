using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.TableDataGateways
{
    /// <summary>
    /// Table Data Gateway の Layer Super Type です。
    /// </summary>
    public /* static */ class TextTemplatingGateway
    {
        #region Protected members...

        /// <summary>
        /// データアクセスオブジェクトの Factory Method を提供します。
        /// </summary>
        protected static TextTemplatingProviderFactory Factory
        {
            get { return TextTemplatingProviderFactory.Instance; }
        }

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        protected static void DoNothing()
        {
            // 何もしない
        }

        #endregion

        #region  Private membes...

        /// <summary>
        /// コンストラクター。
        /// </summary>
        protected TextTemplatingGateway()
        {
            TextTemplatingGateway.DoNothing();
        }

        #endregion
    }
}
