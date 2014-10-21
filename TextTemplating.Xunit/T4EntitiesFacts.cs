using System.Collections.Generic;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit
{
    public class T4EntitiesFacts
    {
        [Fact()]
        public void CreateEntitiesFact()
        {
            var context = new EntitiesContext
            {
                Namespace = @"kkkkkkaaaaaa.DataTransferObjects",
                Imports = new[] { "System", },
                TypeNameSuffix = @"Entity",
            };
            var entities = new T4Entities(context)
                .CreateEntities();
        }
    }
}