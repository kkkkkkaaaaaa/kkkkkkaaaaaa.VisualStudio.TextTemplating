using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit
{
    public class T4Facts
    {
        protected T4ProviderFactory Factory
        {
            get { return T4ProviderFactory.Instance; }
        }

        protected SqlSchemaRepository Schema
        {
            get { return SqlSchemaRepository.Instance; }
        }
    }
}