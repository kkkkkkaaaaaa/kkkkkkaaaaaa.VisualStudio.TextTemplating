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
    public class EntitiesViewModel : EntitiesContext, INotifyPropertyChanged
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

            this.PropertyChangedAsObservable()
                .Subscribe(p => this.DoNothing());

            this._model = new T4Entities(this);
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
                return string.Join(@", ", base.Imports);
            }
            set
            {
                if (value != this.ImportsText)
                {
                    base.Imports = value.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void TransformText()
        {
            if (this.Imports == null) { return; }

            this._model.CreateEntities();

            T4Process.Start(this._model.OutputPath);
        }

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Private members...

        /// <summary></summary>
        private readonly T4Entities _model;

        #endregion

    }
}