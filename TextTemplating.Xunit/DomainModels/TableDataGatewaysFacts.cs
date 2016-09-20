using System.IO;
using System.Linq;
using kkkkkkaaaaaa.VisualStudio.TextTemplating;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    public class TableDataGatewaysFacts
    {
        [Fact()]
        public void CreateGatewaysFact()
        {
            var ns = @"TableDataGateways";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);
            var context = new TableDataGatewaysContext
            {
                Namespace = new Namespace(NAMESPACE, ns),
                Imports = new[] { "System.Data.Common", "kkkkkkaaaaaa.Data.Common" },
                TypeNameSuffix = @"Gateway",
                Inherits = "GatewayBase",
                OutputPath = output,
            };

            var gateways = new TableDataGateways(context);
            gateways.CreateGateways();

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
                TypeNameSuffix = @"Gateway",
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