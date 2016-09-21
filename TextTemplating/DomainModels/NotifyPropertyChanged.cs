using System.Data;
using System.IO;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class NotifyPropertyChanged : TextTemplatingDomainModel<EntitiesContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public NotifyPropertyChanged(EntitiesContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// テーブルから InotifyPropertyChanged 実装クラスを生成します。
        /// </summary>
        public void CreateViewModels()
        {
            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            var connection = this.Factory.CreateConnection();

            try
            {
                connection.Open();

                var schema = new SchemaRepository();
                var tables = schema.GetTablesSchema(connection);

                foreach (var table in tables)
                {
                    this.CreateViewModel(table.TableName);
                }
            }
            finally
            {
                connection?.Close();
            }
        }

        /// <summary>
        /// 指定したテーブルから InotifyPropertyChanged 実装クラスを生成します。
        /// </summary>
        public void CreateViewModel(string table)
        {
            if (!Directory.Exists(this.Context.OutputPath)) { Directory.CreateDirectory(this.Context.OutputPath); }

            var connection = this.Factory.CreateConnection();

            try
            {
                connection.Open();
                var schema = new SchemaRepository();
                this.Context.TableName = table;
                this.Context.TypeName = new TypeName(this.Context.TableName);
                this.Context.Columns = schema.GetColumnsSchema(table, connection);

                var template = new NotifyPropertyChangedTemplate(this.Context);
                var text = template.TransformText();

                var file = Path.Combine(this.Context.OutputPath, this.Context.TypeName.ToString());
                this.Flush(file, text, this.Encoding);
            }
            finally
            {
                connection?.Close();
            }
        }
    }
}