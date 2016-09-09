using System;
using System.IO;
using System.Linq;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.ComponentModel
{
    /// <summary>
    /// Entity のビューモデルを表します。
    /// </summary>
    public partial class EntitiesViewModel
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public EntitiesViewModel()
        {

        }

        public string NamespaceText
        {
            get { return this.Namespace.ToString(); }
            set
            {
                var temp = value.Split('.');
                this.Namespace = new Namespace(string.Concat(temp.Where((_, indecies) => indecies != temp.Length - 2)), temp[temp.Length - 1]);
            }
        }

        /// <summary>
        /// using。
        /// </summary>
        public string ImportsText
        {
            get
            {
                var text = (base.Imports == null)
                    ? @""
                    : string.Join(@", ", base.Imports);

                return text;
            }
            set
            {
                if (value != this.ImportsText)
                {
                    base.Imports = value.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// テキスト変換を実行します。
        /// </summary>
        public void TransformText()
        {
            this.OutputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), this.Namespace.Name);

            var entities = new Entities(this);
            entities.CreateEntities();

            TextTemplatingProcess.StartExplorer(this.OutputPath);
        }

        #region Private members...

        #endregion

    }
}