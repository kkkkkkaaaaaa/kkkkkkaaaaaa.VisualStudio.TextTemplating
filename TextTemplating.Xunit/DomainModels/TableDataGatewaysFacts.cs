using System.IO;
using System.Linq;
using System.Threading.Tasks;
using kkkkkkaaaaaa.VisualStudio.TextTemplating;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    /// <summary></summary>
    public class TableDataGatewaysFacts
    {
        /// <summary></summary>
        [Fact()]
        public async Task CreateGatewaysFact()
        {
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var ns = default(Namespace);

            // Table Data Gateway
            ns = new Namespace(NAMESPACE, @"TableDataGateways");
            var context = new TableDataGatewaysContext
            {
                Namespace = new Namespace(NAMESPACE, ns.Child),
                Imports = new[] { "System.Data.Common", "kkkkkkaaaaaa.Data.Common" },
                TypeName = new TypeName(@"", @"", @"Gateway"),
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
                Inherits = @"",
                OutputPath = Path.Combine(output, ns.Child),

            }).CreateEntitiesAsync();

            var gateways = new TableDataGateways(context);
            await gateways.CreateGatewaysAsync();

            TextTemplatingProcess.StartExplorer(context.OutputPath);
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

        /// <summary></summary>
        private const string NAMESPACE = @"Estelle.Asme.Redmine";

        #endregion
    }
}