using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit
{
    public class SqlSelectTableTempalteFacts : T4Facts
    {
        [Fact()]
        public void CreateSelectProcedures()
        {
            var context = new T4SqlStoredProcedureContext
            {
                SchemaName = @"dbo", 
                ProcedureNamePrefix = @"usp_", 
            };

            var template = new T4SqlStoredProcedures(context)
                .CreateSelectProcedures();
        }

        [Fact(Skip = "")]
        public void CreateUpdateTables()
        {
            var context = new T4SqlStoredProcedureContext
            {
                SchemaName = @"dbo",
                ProcedureNamePrefix = @"usp_",
            };

            var template = new T4SqlStoredProcedures(context)
                .CreateUpdateProcedures();
        }

        [Fact(Skip = "")]
        public void CreateInsertTables()
        {
            var context = new T4SqlStoredProcedureContext
            {
                SchemaName = @"dbo",
                ProcedureNamePrefix = @"usp_",
            };

            var template = new T4SqlStoredProcedures(context)
                .CreateInsertProcedures();
        }

        [Fact(Skip = "")]
        public void CreateDeleteProcedures()
        {
            var context = new T4SqlStoredProcedureContext
            {
                SchemaName = @"dbo",
                ProcedureNamePrefix = @"usp_",
            };

            var template = new T4SqlStoredProcedures(context)
                .CreateDeleteProcedures();
        }
    }
}