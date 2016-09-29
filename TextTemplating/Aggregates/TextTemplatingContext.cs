using System.CodeDom;
using System.Diagnostics;
using System.Reflection;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary></summary>
    public class TextTemplatingContext : ITextTemplatingAggregate
    {
        /// <summary></summary>
        public virtual Namespace Namespace { get; set; }

        /// <summary></summary>
        public virtual TypeName TypeName { get; set; }

        /// <summary></summary>
        public virtual string[] Imports { get; set; }

        /// <summary></summary>
        public virtual TypeAttributes TypeAttributes { get; set; }

        /// <summary>
        /// 型宣言が完全か部分的かを示す値を取得または設定します。
        /// </summary>
        public virtual bool IsPartial { get; set; }

        /// <summary></summary>
        public virtual string Inherits { get; set; }

        /// <summary></summary>
        public virtual string[] Implements { get; set; }

        /// <summary></summary>
        public virtual MemberAttributes MemberAttribute { get; set; }

        /// <summary>
        /// ファイル名を取得または設定します。
        /// </summary>
        public virtual FileName FileName { get; set; }
            
        /// <summary>
        /// ファイルを出力するパスを取得または設定します。
        /// </summary>
        public virtual string OutputPath { get; set; }

        #region Protected members...

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        protected void DoNothing()
        {
            // 何もしない
        }

        #endregion
    }
}
