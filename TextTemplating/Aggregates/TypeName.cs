using System.Diagnostics;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary>
    /// 型の名前を表す Value Object です。
    /// </summary>
    public struct TypeName
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="prefix">プレフィックス。</param>
        /// <param name="name">名前。</param>
        /// <param name="suffix">サフィックス。</param>
        public TypeName(string prefix, string name, string suffix)
        {
            this.Prefix = prefix;
            this.Suffix = suffix;
            this.Name = name;
        }

        /// <summary></summary>
        [DebuggerStepThrough()]
        public TypeName(string prefix, string suffix) : this(prefix, null, suffix)
        {
            this.doNothing();
        }

        /// <summary></summary>
        [DebuggerStepThrough()]
        public TypeName(string typeName) : this(null, typeName, null)
        {
            this.doNothing();
        }


        public string Prefix { get; }

        public string Name { get; }

        public string Suffix { get; }

        /// <summary>
        /// プレフィクスとサフィックスを使用して型の名前を生成して返します。
        /// </summary>
        /// <param name="name">型の名前。</param>
        /// <returns></returns>
        public TypeName GetTypeName(string name)
        {
            return new TypeName(this.Prefix, name, this.Suffix);
        }

        public TypeName GetTypeName(string name, LetterCases letterCase)
        {
            if (letterCase == LetterCases.PascalCase)
            {
                var temp = @"";
                var i = 0;
                foreach (var c in name)
                {
                    if (i == 0) { temp += char.ToUpper(c); }
                    else if (c == '_') { temp += char.ToUpper(name[i + 1]); }
                    else if (name[i - 1] == '_') { this.doNothing(); }
                    else { temp += c; }
                    i++;
                }
                return new TypeName(this.Prefix, temp, this.Suffix);
            }
            else { return this.GetTypeName(name); }
        }

        public override string ToString()
        {
            var s = string.Format(@"{0}{1}{2}", this.Prefix, this.Name, this.Suffix);

            return s;
        }
        
        #region Private members...

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        private void doNothing()
        {
            // 何もしない
        }

        #endregion
    }


}