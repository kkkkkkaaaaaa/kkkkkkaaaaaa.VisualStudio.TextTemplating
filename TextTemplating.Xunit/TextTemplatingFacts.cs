using System.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit
{
    /// <summary>
    /// データソースへのアクセスを提供するオブジェクトの Factory Method を提供します。
    /// </summary>
    public class TextTemplatingFacts
    {
        #region Protected members...

        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        protected TextTemplatingProviderFactory Factory
        {
            [DebuggerStepThrough()]
            get { return TextTemplatingProviderFactory.Instance; }
        }

        /// <summary></summary>
        protected const string NAMESPACE = @"Redmine";

        #endregion
    }
}