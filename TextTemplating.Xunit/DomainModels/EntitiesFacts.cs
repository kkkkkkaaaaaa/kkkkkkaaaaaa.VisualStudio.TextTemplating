using System.CodeDom;
using System.IO;
using System.Reflection;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    /// <summary></summary>
    public class EntitiesFacts
    {
        /// <summary></summary>
        [Fact()]
        public void CreateEntitiesFact()
        {
            var ns = @"Aggregates.Entities";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);

            var context = new EntitiesContext
            {
                Namespace = new Namespace(NAMESPACE, ns),
                Imports = new[] { @"System", @"Data", },
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Class, 
                IsPartial = true,
                TypeName = new TypeName(@"", @"", @"Entity"),
                LetterCase = LetterCases.PascalCase,
                Inherits = @"",
                Implements = new [] { @"" },
                MemberAttribute = MemberAttributes.Assembly | MemberAttributes.Public | MemberAttributes.Final, // Public -> virtual, Public | Final -> public
                OutputPath =  output,
            };

            var entities = new Entities(context);
            entities.CreateEntities();

            TextTemplatingProcess.StartExplorer(output);
        }
        
        /// <summary></summary>
        [Fact()]
        public void CreateEntityFact()
        {
            var ns = @"DataTransferObjects";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);

            var context = new EntitiesContext
            {
                Namespace = new Namespace(NAMESPACE, ns),
                Imports = new[] { @"System", },
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Class,
                IsPartial = true,
                TypeName = new TypeName(@"", @"", @"Entity"),
                Inherits = @"EntityBase",
                Implements = new string [0],
                MemberAttribute = MemberAttributes.Assembly | MemberAttributes.Public | MemberAttributes.Final, // Public -> virtual, Public | Final -> public
                OutputPath = output,
            };
            
            var entities = new Entities(context);
            //entities.CreateEntity(@"TB_MATE_SALE_PRICE");
            entities.CreateEntity(@"issues");

            TextTemplatingProcess.StartExplorer(output);
        }


        #region Private members...

        /// <summary></summary>
        private const string NAMESPACE = @"Redmine";

        #endregion
    }
}