using System.CodeDom;
using System.IO;
using System.Reflection;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    public class EntitiesFacts
    {
        [Fact()]
        public void CreateEntitiesFact()
        {
            var ns = @"DataTransferObjects";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);

            ns = string.IsNullOrWhiteSpace(ns) ? "" : $".{ns}";
            var context = new EntitiesContext
            {
                Namespace = $@"kkkkkkaaaaaa.VisualStudio.TextTemplating{ns}",
                Imports = new[] { @"System", },
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Class, 
                IsPartial = true,
                TypeNameSuffix = "Entity",
                Inherits = @"EntityBase",
                Implements = @"IEntity",
                MemberAttributes = MemberAttributes.Assembly | MemberAttributes.Public | MemberAttributes.Final, // Public -> virtual, Public | Final -> public
                OutputPath =  output,
            };

            var entities = new Entities(context);
            entities.CreateEntities();

            TextTemplatingProcess.StartExplorer(output);
        }

        [Fact()]
        public void CreateEntityFact()
        {
            var ns = @"DataTransferObjects";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);

            ns = string.IsNullOrWhiteSpace(ns) ? "" : $".{ns}";
            var context = new EntitiesContext
            {
                Namespace = $@"kkkkkkaaaaaa.VisualStudio.TextTemplating{ns}",
                Imports = new[] { @"System", },
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Class,
                IsPartial = true,
                TypeNameSuffix = "Entity",
                Inherits = @"EntityBase",
                Implements = @"IEntity",
                MemberAttributes = MemberAttributes.Assembly | MemberAttributes.Public | MemberAttributes.Final, // Public -> virtual, Public | Final -> public
                OutputPath = output,
            };
            
            var entities = new Entities(context);
            entities.CreateEntity(@"TB_MATE_SALE_PRICE");

            TextTemplatingProcess.StartExplorer(output);
        }
    }
}