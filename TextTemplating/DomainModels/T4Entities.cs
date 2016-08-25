using System.Diagnostics;
using System.IO;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// Entity のドメインモデルです。
    /// </summary>
    public class T4Entities : T4DomainModel<EntitiesContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public T4Entities(EntitiesContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public T4Entities()
            : this(new EntitiesContext())
        {
            this.DoNothing();
        }

        /// <summary>
        /// テンプレートとコンテキストから Entity を生成します。
        /// </summary>
        /// <returns></returns>
        public T4Entities CreateEntities()
        {
            var tables = this.GetTablesSchema();

            this.Context.OutputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), @"DataTransferObjects");
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
