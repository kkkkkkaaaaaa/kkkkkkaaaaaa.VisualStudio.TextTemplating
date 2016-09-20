using System.CodeDom;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

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
        /// 
        /// </summary>
        public override Namespace Namespace
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
        public override MemberAttributes MemberAttribute
        {
            get { return base.MemberAttribute; }
            set
            {
                if (value != base.MemberAttribute)
                {
                    base.MemberAttribute = value;
                    this.OnPropertyChanged();
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
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
