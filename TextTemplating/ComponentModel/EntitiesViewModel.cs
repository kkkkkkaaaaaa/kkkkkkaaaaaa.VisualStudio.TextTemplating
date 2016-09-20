using System;
using System.CodeDom;
using System.IO;
using System.Linq;
using System.Reflection;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
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



        /// <summary>
        /// テキスト変換を実行します。
        /// </summary>
        public async void TransformTextAsync()
        {
            const string NAMESPACE = @"Estelle.Asme.Redmine";

            var ns = @"DataTransferObjects";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);

            var context = new EntitiesContext
            {
                Namespace = new Namespace(NAMESPACE, ns),
                Imports = new[] { @"System", },
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Class,
                IsPartial = true,
                TypeNameSuffix = "_entity",
                Inherits = @"EntityBase",
                Implements = new[] { @"IEntity" },
                MemberAttribute = MemberAttributes.Assembly | MemberAttributes.Public | MemberAttributes.Final, // Public -> virtual, Public | Final -> public
                OutputPath = output,
            };

            var entities = new Entities(context);
            await entities.CreateEntitiesAsync();

            TextTemplatingProcess.StartExplorer(output);
        }

        #region Private members...

        #endregion

    }
}