using System;
using System.CodeDom;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.ComponentModel
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EntitiesViewModel : EntitiesContext, INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティー変更イベントハンドラ―。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// コンストラクター。
        /// </summary>
        public EntitiesViewModel()
        {
            /*
            this.PropertyChangedAsObservable()
                .Where(p => (p.EventArgs.PropertyName == @"Namespace"))
                .Subscribe(p => this.TransformText());
            */
        }


        /// <summary>
        /// 
        /// </summary>
        public override string Namespace
        {
            get { return base.Namespace; }
            set
            {
                if (value != base.Namespace)
                {
                    base.Namespace = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string TypeNameSuffix
        {
            get { return base.TypeNameSuffix; }
            set
            {
                if (value != base.TypeNameSuffix)
                {
                    base.TypeNameSuffix = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override MemberAttributes MemberAttributes
        {
            get { return base.MemberAttributes; }
            set
            {
                if (value != base.MemberAttributes)
                {
                    base.MemberAttributes = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 
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
                }
            }
        }

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}