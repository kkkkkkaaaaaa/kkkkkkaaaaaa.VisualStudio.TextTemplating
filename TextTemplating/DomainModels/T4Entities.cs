using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class T4Entities : T4DomainModel<T4EntityContext>
    {
        /// <summary>
        /// コンテキスト。
        /// </summary>
        /// <param name="context"></param>
        public T4Entities(T4EntityContext context) : base(context)
        {
            this.DoNothing();
        }

        public T4Entities CreatEntity()
        {
            var tables = this.GetTablesSchema();

            var dir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), @"DataTransferObjects");
            Directory.CreateDirectory(dir);

            foreach (var table in tables)
            {
                this.Context.TypeName = table.TableName;
                this.Context.Columns = this.GetColumnsSchema(table.TableName);

                var text = this.transformEntity();

                var path = Path.Combine(dir, string.Format(@"{0}.cs", this.Context.TypeName));
                this.WrtieToFile(path, text, new UTF8Encoding(true, true));
            }

            Process.Start(@"explorer", string.Format(@"/e, /root, {0}", dir));

            return this;
        }

        private string transformEntity()
        {
            var template = new T4EntityTemplate(this.Context);
            var text = template.TransformText();

            return text;
        }
    }
}
