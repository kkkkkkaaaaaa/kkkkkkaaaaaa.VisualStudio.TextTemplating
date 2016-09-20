using System.CodeDom;
using System.Diagnostics;
using System.Reflection;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary></summary>
    public class TextTemplatingContext
    {
        /// <summary></summary>
        public virtual string OutputPath { get; set; }

        /// <summary></summary>
        public virtual Namespace Namespace { get; set; }

        /// <summary></summary>
        public virtual string[] Imports { get; set; }

        /// <summary></summary>
        public virtual TypeAttributes TypeAttributes { get; set; }

        /// <summary></summary>
        public virtual string TypeName { get; set; }

        /// <summary></summary>
        public virtual string TypeNameSuffix { get; set; }

        /// <summary></summary>
        public virtual string Inherits { get; set; }

        /// <summary></summary>
        public virtual MemberAttributes MemberAttribute { get; set; }

        /// <summary>
        /// ファイルの接尾辞を取得または設定します。
        /// </summary>
        public virtual string FileNameSuffix { get; set; }

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
