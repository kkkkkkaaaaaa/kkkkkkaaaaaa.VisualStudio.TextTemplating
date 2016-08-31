using System.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit
{
    public class TextTemplatingFacts
    {
        protected TextTemplatingProviderFactory Factory
        {
            [DebuggerStepThrough()]
            get { return TextTemplatingProviderFactory.Instance; }
        }
    }
}