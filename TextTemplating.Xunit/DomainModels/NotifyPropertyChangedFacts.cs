using System.IO;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    public class NotifyPropertyChangedFacts : TextTemplatingFacts
    {
        [Fact()]
        public void CreateViewModelsFact()
        {
            var entities = new Entities(new EntitiesContext
                {
                    Namespace = new Namespace(NAMESPACE, @"Aggregates.Entities"),
                    TypeName = new TypeName(@"", @"Entity"),
                    LetterCase = LetterCases.PascalCase,
                }).GetEntities();

            var ns = new Namespace(NAMESPACE, @"Web.Mvc.ComponentModel");
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var context = new NotifyPropertyChangedContext
            {
                Namespace = ns,
                Imports = new[] { @"System.ComponentModel", @"System.Runtime.CompilerServices", @"Redmine.Aggregates.Entities" },
                Inherits = @"",
                Implements = new[] { @"INotifyPropertyChanged" },
                TypeName = new TypeName(@"", @"ViewModel"),
                LetterCase = LetterCases.PascalCase,
                FileName = new FileName(@"", @"vm.cs"),
                Entities = entities,
                OutputPath = Path.Combine(output, ns.Child),
            };

            var viewmodel = new NotifyPropertyChanged(context);
            viewmodel.CreateViewModels();

            TextTemplatingProcess.StartExplorer(context.OutputPath);
        }
    }
}
