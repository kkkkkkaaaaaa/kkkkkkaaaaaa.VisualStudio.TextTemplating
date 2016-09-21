using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;

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
            var tables = default(IEnumerable<TableSchemaEntity>);

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

        public async Task<IEnumerable<TableDataGatewaysContext>> CreateGatewaysAsync()
        {
            var gateways = new Collection<TableDataGatewaysContext>();
            await this.Context.Entities
                .ToAsyncEnumerable()
                .ForEachAsync(async entity =>
                {
                    this.Context.CurrentEntity = entity;

                    var gateway = await this.CreateGatewayAsync(entity);
                    gateways.Add(gateway);
                });

            return gateways;
        }

        public async Task<TableDataGatewaysContext> CreateGatewayAsync(EntitiesContext entity)
        {
            var context = KandaDataMapper.MapToObject<TableDataGatewaysContext>(this.Context);
            context.CurrentEntity = KandaDataMapper.MapToObject<EntitiesContext>(entity);
            context.TableName = entity.TableName;
            context.TypeName = context.TypeName.GetTypeName(context.TableName);
            context.FileName = context.FileName.GetFileName(context.TableName);

            var tempalte = new TableDataGatewayTemplate(context);
            var text = tempalte.TransformText();


            if (!Directory.Exists(context.OutputPath)) { Directory.CreateDirectory(context.OutputPath); }
            var file = Path.Combine(context.OutputPath, string.Format(@"{0}.cs", context.FileName));
            await this.FlushAsync(file, text, this.Encoding);

            return context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        public void CreateGateway(string table)
        {
            /*
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

            var file = Path.Combine(this.Context.OutputPath, string.Format(@"{0}.cs") $@"{ this.Context.FileNameSuffix }.cs");
            this.Flush(file, text, this.Encoding);
            */
        }
    }
}