/*
<#@ template language="C#" #>
<#= string.Format(@"namespace {0} ", this.Context.Namespace) #> {
<#	foreach(var import in this.Context.Imports) { #>
<#=		string.Format(@"	using {0};", import) #>
<#	} #>

	/// <summary>
<#=	string.Format(@"	/// {0} の View Model を表します。", this.Context.TypeName)  #>
	/// </sumary>
<#=	string.Format(@"public class {0}{1} : {2}, INotifyPropertyChanged", this.Context.TypeName, this.Context.TypeNameSuffix, this.Context.Inherits) #>
	{
        /// <summary>
        /// コンストラクター。
        /// </summary>
<#=		string.Format(@"		public {0}{1}()", this.Context.TypeName, this.Context.TypeNameSuffix) #>
		{
			this.DoNothing();
		}

<#		foreach (var column in this.Context.Columns) { #>
        /// <summary>
<#=		string.Format(@"		/// {0} を取得または設定します。", column.ColumnName) #>
        /// </summary>
<#=		string.Format(@"public override {0} {1}", column.DataTypeName, column.ColumnName) #>
        {
<#=			string.Format(@"get { return base.{1}; }", column.DataTypeName, column.ColumnName) #>
            set
            {
<#=				string.Format(@"if (value != base.{0})", column.ColumnName) #>
                {
<#=					string.Format(@"base.{0} = value;", column.ColumnName) #>
<#=					string.Format(@"this.OnPropertyChanged({0});", column.ColumnName) #>
                }
            }
        }
<#		} #>

        #region Protected members...

        /// <summary>
        /// PropertyChanged イベントを発生させます。
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
	}
}

<##>
*/


using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NotifyPropertyChangedTemplate
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public NotifyPropertyChangedTemplate(EntitiesContext context)
        {
            this._context = context;
        }

        public EntitiesContext Context
        {
            get { return this._context; }
        }

        #region Private members...

        /// <summary></summary>
        private readonly EntitiesContext _context;

        #endregion

    }
}