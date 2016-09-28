using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Windows.ComponentModel
{
    public class MainWindowViewModel //: MainWindowContext
    {
        public EntitiesViewModel Entities { get; set; }

        public NotifyPropertyChangedContext ViewModels { get; set; }

        public ProviderFactoryContext ProviderFactory { get; set; }

        public TableDataGatewaysViewModel Gateways { get; set; }

        public RepositoriesContext Repositories { get; set; }

        public string OutputPath { get; set; }
    }
}