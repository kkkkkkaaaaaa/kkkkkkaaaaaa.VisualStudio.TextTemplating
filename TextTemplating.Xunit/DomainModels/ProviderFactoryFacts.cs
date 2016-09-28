using System.IO;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    public class ProviderFactoryFacts : TextTemplatingFacts
    {
        [Fact()]
        public void CraeteProviderFactoryFact()
        {
            var ns = @"Data";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);
            ns = string.IsNullOrWhiteSpace(ns) ? "" : string.Format(@".{0}", ns);
            var context = new ProviderFactoryContext
            {
                Namespace = new Namespace(NAMESPACE, ns),
                Imports = new[] {@"System", @"System.Data.Common", @"System.Configuration", @"kkkkkkaaaaaa.Data.Common",},
                TypeName = new TypeName(@"TestProviderFactory"),
                ConnectionStringSectionName = @"db",
                InvariantName = @"USystem.Data.SqlClient",
                OutputPath = output,
            };

            var provider = new ProviderFactory(context);
            provider.CreateFactory();

            TextTemplatingProcess.StartExplorer(context.OutputPath);
        }
    }
}