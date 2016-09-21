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

        public async Task<IEnumerable<EntitiesContext>> GetEntitiesAsync()
        {
            var entities = new Collection<EntitiesContext>();

            var tables = this.Schema.GetTablesSchema();
            await tables.ToAsyncEnumerable()
                .ForEachAsync(async table =>
                {
                    var entity = await this.GetEntityAsync(table.TableName);
                });

            return entities;
        }

        public async Task<EntitiesContext> GetEntityAsync(string table)
        {
            var entity = KandaDataMapper.MapToObject<EntitiesContext>(this.Context);
            entity.TableName = table;
            entity.TypeName = entity.TypeName.GetTypeName(entity.TableName);

            return entity;
        }


        /// <summary>
        /// CreateEntity() の非同期バージョンです。
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Entities CreateEntity(string table)
        {
            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            this.Context.TypeName = this.Context.TypeName.GetTypeName(table);
            this.Context.Columns = this.Schema.GetColumnsSchema(table);

            var template = new EntityTemplate(this.Context);
            var text = template.TransformText();

            var path = Path.Combine(this.Context.OutputPath, string.Format(@"{0}.cs", this.Context.TypeName));
            this.Flush(path, text, new UTF8Encoding(true, true));

            return this;
        }

        /// <summary>
        /// CreateEntity() の非同期バージョンです。
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public async Task<EntitiesContext> CreateEntityAsync(string table)
        {
            // 共通のコンテキストをコピー
            var context = KandaDataMapper.MapToObject<EntitiesContext>(this.Context);
            
            // 各 Entity 毎の生成条件
            context.TableName = table; // テーブル名
            context.Columns = await this.Schema.GetColumnsSchemaAsync(table); // 列のスキーマ
            //context.Attributes += (0 < context.TypeAttributes & TypeAttributes.Public) ? @"public" : @"internal";
            //context.Attributes += (0 < context.TypeAttributes & (TypeAttributes.Abstract | TypeAttributes.Sealed)) ? @" static" : @"";
            //context.Attributes += (0 < context.TypeAttributes & (TypeAttributes.Abstract)) ? @" abstract" : @"";
            //context.Attributes += (0 < context.TypeAttributes & (TypeAttributes.Sealed)) ? @" seald" : @"";
            //(context.MemberAttribute & MemberAttributes.Public) ? " public" : "";
            //(context.MemberAttribute & MemberAttributes.Family) ? " protectd" : "";
            context.TypeName = context.TypeName.GetTypeName(context.TableName); // クラス名

            // テンプレート変換
            var template = new EntityTemplate(context);
            var text = template.TransformText();

            // 出力場所
            if (!Directory.Exists(this.OutputPath)) { Directory.CreateDirectory(this.OutputPath); }

            // ファイル生成
            var path = Path.Combine(this.OutputPath, string.Format(@"{0}{1}.cs", context.TypeName, context.FileNameSuffix));
            this.Flush(path, text, new UTF8Encoding(true, true));

            // 生成時のコンテキストを返す
            return context;
        }
    }
}
