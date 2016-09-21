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
        public FileName(string name, string suffix)
        {
            this.Name = name;
            this.Suffix = suffix;
        }

        /// <param name="name"></param>
        public FileName(string name) : this(name, @"")
        {
            this.Name = name;
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
        /// 接尾辞を利用してファイル名を取得して返します。ｒ
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileName GetFileName(string fileName)
        {
            return new FileName(fileName, this.Suffix);
        }

        /// <summary>
        /// このインスタンスの文字列表現を取得して返します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var suffix = string.IsNullOrWhiteSpace(this.Suffix) ? @"" : string.Format(@".{0}", this.Suffix);

            var s = string.Format(@"{0}{1}", this.Name, suffix);

            return s;
        }
    }
}