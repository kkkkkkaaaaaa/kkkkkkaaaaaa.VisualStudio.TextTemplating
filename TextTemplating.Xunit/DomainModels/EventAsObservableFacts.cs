using System.IO;
using System.Windows.Controls.Primitives;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    public class EventAsObservableFacts : TextTemplatingFacts
    {
        [Fact()]
        public void Fact()
        {
            var ns = @"Windows.Reactive";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);

            ns = string.IsNullOrWhiteSpace(ns) ? "" : $".{ns}";
            var context = new EventAsObservableContext
            {
                Types = new [] { typeof(ButtonBase), typeof(ToggleButton), },
                OutputPath = output,
                Imports = new[] { "System.Windows.Controler.Primitives", },
                Namespace = $@"kkkkkkaaaaaa.VisualStudio.TextTemplating{ns}",
            };

            var obersvable = new EventAsObservable(context);
            obersvable.TransformText();

            TextTemplatingProcess.StartExplorer(context.OutputPath);
        }
    }
}