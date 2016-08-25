using System.CodeDom;
using System.Diagnostics;
using System.Reflection;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class T4Context
    {
        public virtual string OutputPath { get; set; }

        public virtual string Namespace { get; set; }

        public virtual string[] Imports { get; set; }

        public virtual TypeAttributes TypeAttributes { get; set; }
        
        public virtual string TypeName { get; set; }

        public virtual string TypeNameSuffix { get; set; }

        public virtual MemberAttributes MemberAttributes { get; set; }

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
