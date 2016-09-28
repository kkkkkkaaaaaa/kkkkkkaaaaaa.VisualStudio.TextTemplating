using System;
using System.IO;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Windows.ComponentModel
{
    /// <summary>
    /// Entity のビューモデルを表します。
    /// </summary>
    public partial class EntitiesViewModel
    {
        /*
        public string NamespaceText
        {
            get { return this.Namespace.ToString(); }
            set
            {
                var temp = value.Split('.');
                base.Namespace = new Namespace(string.Concat(temp.Where((_, indecies) => indecies != temp.Length - 2)), temp[temp.Length - 1]);
            }
        }
        */

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
            this.OutputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), this.Namespace.Child);

            var entities = new Entities(this);
            entities.CreateEntities();

            TextTemplatingProcess.StartExplorer(this.OutputPath);
        }
        
        /// <summary>
        /// テキスト変換を実行します。
        /// </summary>
        public async void TransformTextAsync()
        {
            /*
            const string NAMESPACE = @".Redmine";

            var ns = @"DataTransferObjects";
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ns);

            var context = new EntitiesContext
            {
                Namespace = new Namespace(NAMESPACE, ns),
                Imports = new[] { @"System", },
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Class,
                IsPartial = true,
                TypeName = new TypeName(@"", @"", @"_entity"),
                Inherits = @"EntityBase",
                Implements = new[] { @"IEntity" },
                MemberAttribute = MemberAttributes.Assembly | MemberAttributes.Public | MemberAttributes.Final, // Public -> virtual, Public | Final -> public
                OutputPath = output,
            };
            */

            var entities = new Entities(this);
            await entities.CreateEntitiesAsync();
        }

        #region Private members...

        #endregion

    }
}