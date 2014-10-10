using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    public class T4SqlStoredProcedures : T4DomainModel<T4SqlStoredProcedureContext>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public T4SqlStoredProcedures CreateSelectProcedures()
        {
            var tables = this.GetTablesSchema();

            foreach (var table in tables)
            {
                this.Context.TableName = table.TableName;
                this.Context.Columns = this.GetColumnsSchema(this.Context.TableName);

                var template = new SqlSelectTableTemplate(this.Context);
                var text = template.TransformText();

                //this.WrtieToFile();
            }
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
