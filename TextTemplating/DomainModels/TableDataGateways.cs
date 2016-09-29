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

        public IEnumerable<TableDataGatewaysContext> CreateGateways()
        {
            var contexts = new Collection<TableDataGatewaysContext>();

            var tables = this.Schema.GetTablesSchema();

            foreach (var table in tables)
            {
                var context = this.CreateGateway(table.TableName);
                contexts.Add(context);
            }

            return contexts;
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
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.TableName, this.Context.LetterCase);
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
        public TableDataGatewaysContext CreateGateway(string table)
        {
            this.Context.TableName = table;
            this.Context.CurrentEntity = this.Context.Entities.FirstOrDefault(e => e.TableName == table);
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.TableName, this.Context.LetterCase);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TypeName);


            var context = KandaDataMapper.MapToObject<TableDataGatewaysContext>(this.Context);

            var template = new TableDataGatewayTemplate(context);
            var text = template.TransformText();

            if (!Directory.Exists(this.OutputPath)) { Directory.CreateDirectory(this.OutputPath); }
            var file = Path.Combine(this.OutputPath, string.Format(@"{0}.cs", this.Context.FileName));
            this.Flush(file, text);

            return context;
        }
    }
}