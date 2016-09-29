using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            this.Context.TypeName = this.Context.TypeName.GetTypeName(table, this.Context.LetterCase);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TypeName);
            this.Context.Columns = this.Schema.GetColumnsSchema(table);
            this.Context.Columns.ToAsyncEnumerable().ForEach(column =>
            {
                if (this.Context.LetterCase != LetterCases.PascalCase) { return; }
                column.MappingName = column.ColumnName;

                // パスカルケース変換
                var name = @"";
                var i = 0;
                foreach (var c in column.ColumnName)
                {
                    if (i == 0) { name += char.ToUpper(c); }
                    else if (c == '_') { name += char.ToUpper(column.ColumnName[i + 1]); }
                    else if (column.ColumnName[i - 1] == '_') { this.DoNothing(); }
                    else { name += c; }
                    i++;
                }
                column.ColumnName = name;
            });

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
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.TableName, this.Context.LetterCase);
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
            var context = this.GetEntity(table);

            // テンプレート変換
            var template = new EntityTemplate(this.Context);
            var text = template.TransformText();
            
            // ファイル生成
            if (!Directory.Exists(this.OutputPath)) { Directory.CreateDirectory(this.OutputPath); }
            var path = Path.Combine(this.OutputPath, this.Context.FileName.ToString());
            this.Flush(path, text, new UTF8Encoding(true, true));

            // 生成時のコンテキストを返す
            return context;
        }


        /// <summary>
        /// CreateEntity() の非同期バージョンです。
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public EntitiesContext CreateEntity(string table)
        {
            var context = this.GetEntity(table);

            var template = new EntityTemplate(this.Context);
            var text = template.TransformText();

            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            var path = Path.Combine(this.Context.OutputPath, string.Format(@"{0}.cs", this.Context.TypeName));
            this.Flush(path, text);

            return context;
        }


        /// <summary>
        /// コンテキストとテンプレートから Entity を生成します。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EntitiesContext> CreateEntities()
        {
            var contexts = new Collection<EntitiesContext>();

            var tables = this.Schema.GetTablesSchema();
            foreach (var table in tables)
            {
                var context = this.CreateEntity(table.TableName);
                contexts.Add(context);
            }

            return contexts;
        }
    }
}
