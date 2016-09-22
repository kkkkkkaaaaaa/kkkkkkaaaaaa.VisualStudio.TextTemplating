using System.Collections.Generic;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    public partial class RepositoriesContext : TextTemplatingContext
    {
        public virtual IEnumerable<EntitiesContext> Entities { get; set; }

        public virtual IEnumerable<TableDataGatewaysContext> Gateways { get; set; }

        public TableDataGatewaysContext CurrentGateway { get; set; }

        public EntitiesContext CurrentEntity { get; set; }
    }
}
