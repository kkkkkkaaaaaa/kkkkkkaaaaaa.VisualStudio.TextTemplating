using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.TableDataGateways;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class T4Repository
    {
        /*
        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        public static T4Repository Instance
        {
            get { return T4Repository._instance.Value; }
        }
        */

        /// <summary>
        /// 
        /// </summary>
        protected T4Repository()
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
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

        /// <summary></summary>
        private readonly static Lazy<T4Repository> _instance = new Lazy<T4Repository>(() => new T4Repository());

        #endregion

    }
}