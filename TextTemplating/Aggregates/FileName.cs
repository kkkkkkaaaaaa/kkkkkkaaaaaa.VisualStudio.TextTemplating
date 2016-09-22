using System.Diagnostics;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates
{
    /// <summary>
    /// ファイル名を表します。
    /// </summary>
    public struct FileName
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="suffix"></param>
        /// <param name="extension"></param>
        public FileName(string name, string suffix, string extension)
        {
            this.Name = name;
            this.Suffix = suffix;
            this.Extension = extension;
        }
        
        /// <summary></summary>
        public FileName(string suffix, string extension) : this(null, suffix, extension)
        {
            this.DoNothing();
        }

        /// <summary></summary>
        public FileName(string name) : this(name, null, null)
        {
            this.DoNothing();
        }

        /// <summary>
        /// ファイル名を取得します。
        /// </summary>ｒ
        public string Name { get; }
        
        /// <summary>
        /// ファイル名の接尾辞を取得します。
        /// </summary>
        public string Suffix { get; }


        /// <summary>
        /// ファイル名の拡張子を取得します。
        /// </summary>
        public string Extension { get; set; }


        /// <summary>
        /// 接尾辞を利用してファイル名を取得して返します。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileName GetFileName(string fileName)
        {
            return new FileName(fileName, this.Suffix, this.Extension);
        }
        
        /// <summary>
        /// 型の名前と接尾辞を利用してファイル名を取得して返します。
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public FileName GetFileName(TypeName typeName)
        {
            return this.GetFileName(typeName.ToString());
        }

        /// <summary>
        /// このインスタンスの文字列表現を取得して返します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var suffix = string.IsNullOrWhiteSpace(this.Suffix) ? @"" : string.Format(@".{0}", this.Suffix);
            var extension = (this.Extension == null)
                ? @""
                : this.Extension.StartsWith(@".")
                    ? this.Extension
                    : string.Format(@".{0}", this.Extension);

            // 例：TableEntity.partial.cs
            var s = string.Format(@"{0}{1}{2}", this.Name, suffix, extension);

            return s;
        }
        

        #region Private members...

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        private void DoNothing()
        {
            // 何もしない
        }

        #endregion
    }
}