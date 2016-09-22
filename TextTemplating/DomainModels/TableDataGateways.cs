using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            
            //var tables = this.Schema.GetTablesSchema();
            //await tables

            this.Context.Entities = (this.Context.Entities ?? (await new Entities().GetEntitiesAsync()));
            await this.Context.Entities
                .ToAsyncEnumerable()
                .ForEachAsync(async table =>
                {
                    var gateway = await this.CreateGatewayAsync(table.TableName);
                    gateways.Add(gateway);
                });
            return gateways;
        }

        /// <summary>
        /// Table Data Gateway を生成してファイルを出力します。
        /// </summary>
        /// <returns></returns>
        public async Task<TableDataGatewaysContext> CreateGatewayAsync(string table)
        {
            // 現在のコンテキストを変更
            this.Context.TableName = table;
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.TableName);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TypeName.ToString());
            this.Context.CurrentEntity = this.Context.Entities.First(e => e.TableName == table);

            // 変換を実行
            var tempalte = new TableDataGatewayTemplate(this.Context);
            var text = tempalte.TransformText();

            // ファイルに書き出し
            if (!Directory.Exists(this.OutputPath)) { Directory.CreateDirectory(this.OutputPath); }
            var file = Path.Combine(this.OutputPath, this.Context.FileName.ToString());
            await this.FlushAsync(file, text);

            // コピーして返す
            var context = KandaDataMapper.MapToObject<TableDataGatewaysContext>(this.Context);

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