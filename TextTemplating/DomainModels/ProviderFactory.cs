using System.IO;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ProviderFactory : TextTemplatingDomainModel<ProviderFactoryContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public ProviderFactory(ProviderFactoryContext context) : base(context)
        {
            this.DoNothing();
        }

        /// <summary>
        /// KandaDbProviderFacatory を生成します。
        /// </summary>
        public void CreateFactory()
        {
            Directory.CreateDirectory(this.Context.OutputPath);

            var template = new ProviderFactoryTemplate(this.Context);
            var text = template.TransformText();

            var path = Path.Combine(this.OutputPath, this.Context.TypeName.ToString());
            this.Flush(path, text, this.Encoding);
        }
    }
}
