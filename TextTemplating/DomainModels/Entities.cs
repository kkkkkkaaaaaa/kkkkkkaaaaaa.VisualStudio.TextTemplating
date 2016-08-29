using System.Diagnostics;
using System.IO;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// Entity のドメインモデルです。
    /// </summary>
    public class Entities : TextTemplatingDomainModel<EntitiesContext>
    {
        [DebuggerStepThrough()]
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public Entities(EntitiesContext context) : base(context)
        {
            this.DoNothing();
        }

        [DebuggerStepThrough()]
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public Entities() : this(new EntitiesContext())
        {
            this.DoNothing();
        }

        /// <summary>
        /// テンプレートとコンテキストから Entity を生成します。
        /// </summary>
        /// <returns></returns>
        public Entities CreateEntities()
        {
            var tables = this.GetTablesSchema();
            
            Directory.CreateDirectory(this.Context.OutputPath);

            foreach (var table in tables)
            {
                this.Context.TypeName = table.TableName;
                this.Context.Columns = this.GetColumnsSchema(table.TableName);

                var template = new T4EntityTemplate(this.Context);
                var text = template.TransformText();

                var path = Path.Combine(this.Context.OutputPath, string.Format(@"{0}.cs", this.Context.TypeName));
                this.Flush(path, text, new UTF8Encoding(true, true));
            }

            return this;
        }
    }
}
