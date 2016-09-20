﻿using System.Collections.Generic;
using System.IO;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    public class TableDataGateways : TextTemplatingDomainModel<TableDataGatewaysContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public TableDataGateways(TableDataGatewaysContext context) : base(context)
        {
            this.DoNothing();
        }

        public void CreateGateways()
        {
            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            var connection = this.Factory.CreateConnection();
            var tables = default(IEnumerable<SqlTableSchemaEntity>);

            try
            {
                connection.Open();

                var schema = new SchemaRepository();
                tables = schema.GetTablesSchema(connection);
            }
            finally
            {
                connection?.Close();
            }

            foreach (var table in tables)
            {
                this.CreateGateway(table.TableName);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        public void CreateGateway(string table)
        {
            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            var connection = this.Factory.CreateConnection();

            try
            {
                connection.Open();

                var schema = new SchemaRepository();
                this.Context.Columns = schema.GetColumnsSchema(table, connection);
            }
            finally
            {
                connection?.Close();
            }

            this.Context.TableName = table;
            this.Context.EntityName = $@"{table}Entity";
            this.Context.TypeName = $@"{ this.Context.TableName }{ this.Context.TypeNameSuffix }";

            var entity = new EntitiesContext
            {
                TypeName = $@"{ table }Entity",
            };
            this.Context.Columns = this.Schema.GetColumnsSchema(table);

            var tempalte = new TableDataGatewayTemplate(this.Context, entity);
            var text = tempalte.TransformText();

            var file = Path.Combine(this.Context.OutputPath, $@"{ this.Context.TypeName }.cs");
            this.Flush(file, text, this.Encoding);
        }
    }
}