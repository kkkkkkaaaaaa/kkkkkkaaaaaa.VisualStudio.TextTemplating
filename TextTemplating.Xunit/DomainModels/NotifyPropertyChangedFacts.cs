using System.IO;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    public class NotifyPropertyChangedFacts
    {
        public class NotifyPropertyChangedTemplateFacts
        {
            [Fact()]
            public void Fact()
            {
                var ns = @"ComponentModel";
                var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);

                ns = string.IsNullOrWhiteSpace(ns) ? ns : $".{ns}";

                var context = new EntitiesContext()
                {
                    Namespace = ns,
                    Imports = new[] {@"System.ComponentModel", @"DataTransferObjects" },
                    TypeName = @"TB_MATE_SALE_PRICE",
                    TypeNameSuffix = @"ViewModel",
                    Inherits = @"TestViewModel",
                    Implements = new [] { @"INortifyPropertyChanged" },
                    OutputPath = output,
                };

                var viewmodel = new NotifyPropertyChanged(context);
                viewmodel.CreateViewModel(context.TypeName);

                TextTemplatingProcess.StartExplorer(context.OutputPath);
            }
        }
    }
}
