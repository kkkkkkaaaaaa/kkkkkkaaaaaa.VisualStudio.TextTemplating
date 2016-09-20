using System.Diagnostics;
using System.IO;
using System.Text;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    public class T4SqlStoredProcedures : TextTemplatingDomainModel<T4SqlStoredProcedureContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public T4SqlStoredProcedures(T4SqlStoredProcedureContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// テンプレートから選択プロシージャ―を生成します。
        /// </summary>
        /// <returns></returns>
        public T4SqlStoredProcedures CreateSelectProcedures()
        {
            var tables = this.Schema.GetTablesSchema();

            var dir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), @"Stred Procedures");
            Directory.CreateDirectory(dir);

            foreach (var table in tables)
            {
                this.Context.TableName = table.TableName;
                this.Context.Columns = this.Schema.GetColumnsSchema(this.Context.TableName);

                var template = new SqlSelectTableTemplate(this.Context);
                var text = template.TransformText();

                var path = Path.Combine(dir, string.Format(@"{0}Select{1}.sql", this.Context.ProcedureNamePrefix, this.Context.TableName));
                this.Flush(path, text, new UTF8Encoding(true, true));
            }

            Process.Start(@"explorer", string.Format(@"/e, /root, ""{0}""", dir));

            return this;
        }

        public T4SqlStoredProcedures CreateInsertProcedures()
        {
            return this;
        }


        public T4SqlStoredProcedures CreateUpdateProcedures()
        {
            return this;
        }

        public T4SqlStoredProcedures CreateDeleteProcedures()
        {
            return this;
        }
    }
}
