using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// Entity のドメインモデルです。
    /// </summary>
    public class Entities : TextTemplatingDomainModel<EntitiesContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        [DebuggerStepThrough()]
        public Entities(EntitiesContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        [DebuggerStepThrough()]
        public Entities() : this(new EntitiesContext())
        {
            this.DoNothing();
        }


        public IEnumerable<EntitiesContext> GetEntities()
        {
            var entities = new Collection<EntitiesContext>();
            var tables = this.Schema.GetTablesSchema();
            foreach (var table in tables)
            {
                var entity = this.GetEntity(table.TableName);
                entities.Add(entity);
            }

            return entities;
        }

        private EntitiesContext GetEntity(string table)
        {
            this.Context.TableName = table;
            this.Context.TypeName = this.Context.TypeName.GetTypeName(table);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TableName);
            this.Context.Columns = this.Schema.GetColumnsSchema(table);

            var context = KandaDataMapper.MapToObject<EntitiesContext>(this.Context);

            return context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EntitiesContext>> GetEntitiesAsync()
        {
            var entities = new Collection<EntitiesContext>();

            var tables = this.Schema.GetTablesSchema();
            await tables.ToAsyncEnumerable()
                .ForEachAsync(async table =>
                {
                    var entity = await this.GetEntityAsync(table.TableName);
                    entities.Add(entity);
                });

            return entities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public async Task<EntitiesContext> GetEntityAsync(string table)
        {
            // 現在のコンテキストを変更
            this.Context.Columns = await this.Schema.GetColumnsSchemaAsync(table);
            this.Context.TableName = table;
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.TableName);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TableName);
            
            // コピー
            var entity = KandaDataMapper.MapToObject<EntitiesContext>(this.Context);

            return entity;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EntitiesContext>> CreateEntitiesAsync()
        {
            var tables = this.Schema.GetTablesSchema();

            var entities = new Collection<EntitiesContext>();
            await tables.ToAsyncEnumerable()
                .ForEachAsync(async table =>
                {
                    var entity = await this.CreateEntityAsync(table.TableName);
                    entities.Add(entity);
                });

            return entities;
        }


        /// <summary>
        /// CreateEntity() の非同期バージョンです。
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public async Task<EntitiesContext> CreateEntityAsync(string table)
        {
            // 現在のコンテキストを更新
            this.Context.TableName = table;
            this.Context.Columns = await this.Schema.GetColumnsSchemaAsync(table);
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.TableName);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TypeName);

            // テンプレート変換
            var template = new EntityTemplate(this.Context);
            var text = template.TransformText();
            
            // ファイル生成
            if (!Directory.Exists(this.OutputPath)) { Directory.CreateDirectory(this.OutputPath); }
            var path = Path.Combine(this.OutputPath, this.Context.FileName.ToString());
            this.Flush(path, text, new UTF8Encoding(true, true));

            // 共通のコンテキストをコピー
            var context = KandaDataMapper.MapToObject<EntitiesContext>(this.Context);

            // 生成時のコンテキストを返す
            return context;
        }


        /// <summary>
        /// CreateEntity() の非同期バージョンです。
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Entities CreateEntity(string table)
        {   
            this.Context.TypeName = this.Context.TypeName.GetTypeName(table);
            this.Context.Columns = this.Schema.GetColumnsSchema(table);

            var template = new EntityTemplate(this.Context);
            var text = template.TransformText();

            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            var path = Path.Combine(this.Context.OutputPath, string.Format(@"{0}.cs", this.Context.TypeName));
            this.Flush(path, text);

            return this;
        }


        /// <summary>
        /// コンテキストとテンプレートから Entity を生成します。
        /// </summary>
        /// <returns></returns>
        public Entities CreateEntities()
        {
            // if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            var tables = this.Schema.GetTablesSchema();
            foreach (var table in tables)
            {
                this.CreateEntity(table.TableName);
            }

            return this;
        }
    }
}
