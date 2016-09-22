using System.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit
{
    /// <summary>
    /// データソースへのアクセスを提供するオブジェクトの Factory Method を提供します。
    /// </summary>
    public class TextTemplatingFacts
    {
        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        protected TextTemplatingProviderFactory Factory
        {
            [DebuggerStepThrough()]
            get { return TextTemplatingProviderFactory.Instance; }
        }

        protected const string NAMESPACE = @"Estelle.Asme";
    }
}