using System.Diagnostics;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories
{
    /// <summary>
    /// このアプリケーションの Repository の基底クラスを表します。
    /// </summary>
    public abstract class T4Repository
    {
        /// <summary>
        /// コンストラクター。・
        /// </summary>
        protected T4Repository()
        {
            this.DoNothing();
        }

        /// <summary>
        /// Singleton インスタンスを取得します。
        /// </summary>
        protected T4ProviderFactory Factory
        {
            get { return T4ProviderFactory.Instance; }
        }

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        protected void DoNothing()
        {
            // 何もしない
        }

        #region Private members...

        #endregion

    }
}