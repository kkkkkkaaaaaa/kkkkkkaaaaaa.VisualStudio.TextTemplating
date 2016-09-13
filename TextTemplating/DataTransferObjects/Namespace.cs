namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    /// <summary>
    /// 名前空間を表す Value Object。
    /// </summary>
    public struct Namespace
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="root"></param>
        /// <param name="ns"></param>
        public Namespace(string root, string ns)
        {
            this.Parent = root;
            this.Name = ns;
        }

        /// <summary>
        /// 親の名前空間を取得します。
        /// </summary>
        public string Parent { get; }

        /// <summary>
        /// 名前空間名を取得します。
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// このオブジェクトの文字列表現を返します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var ns = (string.IsNullOrWhiteSpace(this.Parent)
                ? this.Name
                : string.Format(@"{0}.{1}", this.Parent, this.Name));

            return ns;
        }

        public static bool operator ==(Namespace ns1, Namespace ns2)
        {
            if (object.ReferenceEquals(ns1, ns2)) { return true; }
            if ((object)ns1 == null || (object)ns2 == null) { return false;  }

            var equals = (ns1.Parent == ns2.Parent) && (ns1.Name == ns2.Name);

            return equals;
        }
        public static bool operator !=(Namespace ns1, Namespace ns2)
        {
                return !(ns1 == ns2);
        }

        public override bool Equals(object obj)
        {
            return (this == (Namespace)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}