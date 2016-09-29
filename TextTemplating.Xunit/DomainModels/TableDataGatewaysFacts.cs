using System.CodeDom;
using System.IO;
using System.Reflection;
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
        public void CreateGatewaysFact()
        {
            var entities = new Entities(new EntitiesContext
            {
                Namespace = new Namespace(NAMESPACE, @"Aggregats.Entities"),
                Imports = new[] {@"System",},
                TypeAttributes = TypeAttributes.Public,
                Inherits = @"",
                TypeName = new TypeName(@"", @"", @"Entity"),
                LetterCase = LetterCases.PascalCase,
                MemberAttribute = MemberAttributes.Assembly,
            }).GetEntities();

            var ns = @"Data.TableDataGateways";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);
            var context = new TableDataGatewaysContext
            {
                Namespace = new Namespace(NAMESPACE, ns),
                Imports = new[] { "System.Data.Common", "Data", @"Redmine.Aggregates.Entities" },
                TypeName = new TypeName(@"", @"Gateway"),
                LetterCase = LetterCases.PascalCase,
                Inherits = "RedmineGateway",
                Entities = entities,
                OutputPath = output,
            };

            var gateways = new TableDataGateways(context);
            gateways.CreateGateways();

            TextTemplatingProcess.StartExplorer(context.OutputPath);
        }

        #region Private members...

        #endregion
    }
}