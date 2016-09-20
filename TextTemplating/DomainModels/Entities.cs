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

        public async Task<Entities> CreateEntitiesAsync()
        {
            var tables = this.Schema.GetTablesSchema();

            await tables.ToAsyncEnumerable()
                .ForEachAsync(async table => await this.CreateEntityAsync(table.TableName));

            return this;
        }


        /// <summary>
        /// CreateEntity() の非同期バージョンです。
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Entities CreateEntity(string table)
        {
            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            this.Context.TypeName = string.Format(@"{0}{1}", table, this.Context.TypeNameSuffix);
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
        public async Task<Entities> CreateEntityAsync(string table)
        {
            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            this.Context.TypeName = string.Format(@"{0}{1}", table, this.Context.TypeNameSuffix);
            this.Context.Columns = await this.Schema.GetColumnsSchemaAsync(table);

            var template = new EntityTemplate(this.Context);
            var text = template.TransformText();

            var path = Path.Combine(this.Context.OutputPath, string.Format(@"{0}.cs", this.Context.TypeName));
            this.Flush(path, text, new UTF8Encoding(true, true));

            return this;
        }

        public void CreateTablesMarkdownTable()
        {

        }

        public void CreateTableMrkdownTables()
        {

        }

        public void CreateTableMrkdownTable()
        {

        }
    }
}
