using System;
using System.CodeDom;
using System.Reflection;
using System.Windows;
using kkkkkkaaaaaa.Reactive.Windows;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace TextTemplating.Windows
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            // 規定値
            this._vm.Namespace = new Namespace(@"kkkkkkaaaaaa.VisualStudio.TextTemplating", @"");
            this._vm.Imports = new []{ @"System", };
            this._vm.TypeAttributes = TypeAttributes.Public;
            this._vm.TypeNameSuffix = "Entity";
            this._vm.Inherits = @"";
            this._vm.MemberAttributes = MemberAttributes.Assembly;


            // [Transform] クリック
            var click = this.ButtonTransform.ClickAsObservable()
                 .Subscribe(_ => this._vm.TransformText());

            // データバインド
            this.Entities.DataContext = this._vm;
        }

        #region Private members...
        
        #endregion
    }
}
