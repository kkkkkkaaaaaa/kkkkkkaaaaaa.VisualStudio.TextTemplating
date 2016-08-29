using System;
using System.CodeDom;
using System.Reflection;
using System.Windows;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.ComponentModel;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Reactive;

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
            InitializeComponent();

            // 規定値
            var vm = new EntitiesViewModel
            {
                Namespace = @"kkkkkkaaaaaa.VisualStudio.TextTemplating",
                Imports = new []{ @"System", },
                TypeAttributes = TypeAttributes.Public,
                TypeNameSuffix = "Entity",
                Inherits = @"",
                Implements = @"",
                MemberAttributes = MemberAttributes.Assembly,
            };

            // [Transform] クリック
            var click = this.ButtonTransform.ClickAsObservable()
                .Subscribe(_ => vm.TransformText());

            // データバインド
            this.Entities.DataContext = vm;
        }
    }
}
