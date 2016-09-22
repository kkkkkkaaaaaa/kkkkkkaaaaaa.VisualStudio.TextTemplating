using System.IO;
using System.Threading.Tasks;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    /// <summary></summary>
    public class TableDataGatewaysFacts : TextTemplatingFacts
    {
        /// <summary></summary>
        [Fact()]
        public async Task CreateGatewaysAsyncFact()
        {
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var ns = default(Namespace);

            // Table Data Gateway
            ns = new Namespace(NAMESPACE, @"TableDataGateways");
            var context = new TableDataGatewaysContext
            {
                Namespace = ns,
                Imports = new[] { "System.Data.Common", "kkkkkkaaaaaa.Data.Common" },
                TypeName = new TypeName(@"", @"", @"Gateway"),
                FileName = new FileName(@"", @"", @".cs"),
                Inherits = "GatewayBase",
                OutputPath = Path.Combine(output, ns.Child),
            };

            // Entities
            ns = new Namespace(NAMESPACE, @"Aggregates");
            context.Entities = await new Entities(new EntitiesContext
            {
                Namespace = ns,
                Imports = new [] { @"System", },
                TypeName = new TypeName(@"", @"", @"Entity"),
                FileName = new FileName(@"", @"", @"cs"),
                Inherits = @"",
                OutputPath = Path.Combine(output, ns.Child),

            }).CreateEntitiesAsync();

            var gateways = new TableDataGateways(context);
            await gateways.CreateGatewaysAsync();

            TextTemplatingProcess.StartExplorer(output);
        }


        [Fact()]
        public void CreateGatewayFact()
        {
            var ns = @"TableDataGateways";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);
            var context = new TableDataGatewaysContext
            {
                Namespace = new Namespace(NAMESPACE, ns),
                Imports = new[] {"System.Data.Common", "kkkkkkaaaaaa.Data.Common"},
                TypeName = new TypeName(@"", @"", @"Gateway"),
                Inherits = "GatewayBase",
                OutputPath = output,
            };

            var gateways = new TableDataGateways(context);
            gateways.CreateGateway(@"attachments");

            TextTemplatingProcess.StartExplorer(context.OutputPath);
        }

        #region Private members...

        #endregion
    }
}