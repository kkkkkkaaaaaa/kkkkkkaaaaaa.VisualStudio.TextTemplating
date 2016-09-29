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
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.TableName);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TypeName);
            this.Context.CurrentEntity = this.Context.Entities.FirstOrDefault(entity => entity.TableName == this.Context.TableName);

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