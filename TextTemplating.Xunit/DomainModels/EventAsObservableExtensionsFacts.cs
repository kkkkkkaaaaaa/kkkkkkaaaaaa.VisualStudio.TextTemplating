﻿using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit.DomainModels
{
    public class EventAsObservableExtensionsFacts : TextTemplatingFacts
    {
        [Fact()]
        public void CreateEventAsObservableExtensionsFact()
        {
            var ns = new Namespace(NAMESPACE, @"Windows.Reactive");
            var imports = new[]
            {
                "System.Windows",
                "System.Windows.Controler.Primitives",
            };
            var types = new[]
            {
                // WPF コントロール
                typeof(UIElement),
                typeof(FrameworkElement),
                // typeof(Panel),
                // typeof(ContentControl),
                // typeof(TextBlock),
                // typeof(Page),
                // typeof(AccessText),
                // typeof(AdornedElementPlaceholder),
                typeof(Control),
                typeof(Calendar),
                typeof(Window),
                typeof(ButtonBase),
                // typeof(Button),
                typeof(ToggleButton),
                typeof(RangeBase),
                typeof(Image),
                typeof(InkCanvas),
                typeof(MediaElement),
                typeof(DatePicker),
                // typeof(ContentPresenter),
                // typeof(),
            };
            
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            var context = new EventAsObservableContext
            {
                Namespace = ns,
                Imports = imports,
                Types = types,
                TypeName = new TypeName(@"", @"Extensions"),
                OutputPath = Path.Combine(output, ns.Child),
            };

            var observable = new EventAsObservableExtensions(context);
            observable.CreateEventAsObservableExtensions();

            TextTemplatingProcess.StartExplorer(output);
        }
    }
}