using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class RepositoriesFacts : TextTemplatingFacts
    {
        [Fact()]
        public async Task CreateRepositoriesAsyncFact()
        {
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var ns = default(Namespace);

            ns = new Namespace(NAMESPACE, @"Data.Repositories");
            var context = new RepositoriesContext
            {
                Namespace = ns,
                Imports = new[] { @"System", new Namespace(NAMESPACE, @"Data.TableDataGateways").ToString() },
                TypeName = new TypeName(@"", @"Repository"),
                FileName = new FileName(@"", @"cs"),
                Inherits = @"RepositoryBase",
                OutputPath = Path.Combine(output, ns.Child),
            };

            ns = new Namespace(NAMESPACE, @"Data.Aggregates");
            var entities = new Entities(new EntitiesContext
            {
                Namespace = ns,
                Imports = new[] { @"System", },
                TypeName = new TypeName(@"", @"Entity"),
                TypeAttributes = TypeAttributes.Public,
                IsPartial = true,
                Inherits = @"",
                MemberAttribute = MemberAttributes.Public,
                FileName = new FileName(@"", @"cs"),
                OutputPath = Path.Combine(output, ns.Child),
            }).CreateEntitiesAsync();
            entities.Wait();
            context.Entities = entities.Result;

            ns = new Namespace(NAMESPACE, @"Data.TableDataGateways");
            var gateways = new TableDataGateways(new TableDataGatewaysContext
            {
                Namespace = ns,
                Imports = new[] { @"System", },
                TypeName = new TypeName(@"", @"Gateway"),
                TypeAttributes = TypeAttributes.Public /*| TypeAttributes.Abstract*/,
                IsPartial = true,
                Inherits = @"GatewayBase",
                MemberAttribute = MemberAttributes.Public,
                FileName = new FileName(@"", @".cs"),
                // Entities = context.Entities,
                OutputPath = Path.Combine(output, ns.Child),
            }).CreateGatewaysAsync();
            gateways.Wait();
            context.Gateways = gateways.Result;

            var repositories = new Repositories(context)
                .CreateRepositoriesAsync();
            repositories.Wait();
            
            var process = default(Process);
            try
            {
                process = TextTemplatingProcess.StartExplorer(output);
            }
            finally
            {
                process?.Close();
            }
        }

    }
}