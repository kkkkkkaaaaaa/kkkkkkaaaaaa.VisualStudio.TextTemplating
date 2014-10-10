using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.TableDataGateways;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VIsualStudio.TextTemplating.Xunit
{
    public class SqlSelectTableTempalteFacts : T4Facts
    {
        [Fact()]
        public void CreateSelectTables()
        {
            var context = new T4SqlStoredProcedureContext
            {
                SchemaName = @"dbo", 
                ProcedureNamePrefix = @"usp_", 
            };

            var template = new T4SqlStoredProcedures(context)
                .CreateSelectProcedures()
                .CreateInsertProcedures()
                .CreateUpdateProcedures()
                .CreateDeleteProcedures();

        }

        /*
        [Fact()]
        public void Generate()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this.Factory.CreateConnection();
                connection.Open();

                var template = new SqlSelectTableTemplate(connection);
                var text = tempalte.TransformText();
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

            *//*
            var table = connection.GetTablesSchema();
            var reader = new DataTableReader(table);
            //KandaDbDataMapper.MapToCollection<Entity>(reader);
            *//*


            var connection = TTProviderFactory.Instance.CreateConnection();
            connection.Open();

            var table = connection.GetTablesSchema();
            var reader = new DataTableReader(table);
            var entities = KandaDbDataMapper.MapToEnumerable<SqlTableSchemaEntity>(reader);

            var reader = TTProviderFactory.Instance.CreateReader(connection);
            reader.CommandText = @"SELECT TOP 0 FROM Memberships WHERE 1 <> 1";
            reader.ExecuteReader();

            var schema = @"dbo";

            var context = new SqlTableContext
            {
                SchemaName = string.IsNullOrWhiteSpace(schema) ? @"" : string.Format(@"{0}.", schema), 
                ProcedurePrefix = @"usp_", 
                TableName = @"Table",
                //Columns = KandaDbDataMapper.MapToCollection<Entity>(reader),
            };

            var tempalte = new SqlSelectTableTemplate(context);
            var text = tempalte.TransformText();

            var encoding = new UTF8Encoding(true, false);
            var buffer = encoding.GetBytes(text);

            var stream = default(Stream);

            try
            {
                stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"{0}.sql", @"a")), FileMode.Create, FileAccess.Write);
                stream.Write(buffer, 0, buffer.Length);
            }
            finally
            {
                if (stream != null) { stream.Close(); }
            }
        }
        */
    }
}