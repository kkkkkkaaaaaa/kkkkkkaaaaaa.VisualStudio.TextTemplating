using System.IO;
using System.Linq;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class NotifyPropertyChanged : TextTemplatingDomainModel<NotifyPropertyChangedContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public NotifyPropertyChanged(NotifyPropertyChangedContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// テーブルから InotifyPropertyChanged 実装クラスを生成します。
        /// </summary>
        public void CreateViewModels()
        {
            foreach (var entity in this.Context.Entities)
            {
                this.CreateViewModel(entity.TableName);
            }
        }

        /// <summary>
        /// 指定したテーブルから InotifyPropertyChanged 実装クラスを生成します。
        /// </summary>
        public NotifyPropertyChangedContext CreateViewModel(string table)
        {
            this.Context.TableName = table;
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.TableName, this.Context.LetterCase);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TypeName);
            this.Context.CurrentEntity = this.Context.Entities.FirstOrDefault(entity => entity.TableName == this.Context.TableName);
            /*
            this.Context.CurrentEntity.Columns.ToAsyncEnumerable().ForEach(column =>
            {
                if (this.Context.LetterCase != LetterCases.PascalCase) { return; }
                column.MappingName = column.ColumnName;
                column.MappedName = column.ColumnName;

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
                column.MappedName = name;
            });
            */

            var template = new NotifyPropertyChangedTemplate(this.Context);
            var text = template.TransformText();

            if (!Directory.Exists(this.OutputPath)) { Directory.CreateDirectory(this.OutputPath); }
            var file = Path.Combine(this.Context.OutputPath, this.Context.FileName.ToString());
            this.Flush(file, text);

            var context = KandaDataMapper.MapToObject<NotifyPropertyChangedContext>(this.Context);

            return context;
        }
    }
}