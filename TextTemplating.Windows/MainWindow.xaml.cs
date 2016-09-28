using System;
using System.CodeDom;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using kkkkkkaaaaaa.Reactive.Windows;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Diagnostics;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Windows.ComponentModel;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Windows
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

            const string PARENT_NS = @"Redmine";

            this._vm.OutputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            if (!Directory.Exists(this._vm.OutputPath)) { Directory.CreateDirectory(this._vm.OutputPath); }

            // 規定値
            this._vm.Entities = new EntitiesViewModel
            {
                Namespace = new Namespace(PARENT_NS, @"Aggregats.Entities"),
                Imports = new[] {@"System",},
                TypeAttributes = TypeAttributes.Public,
                TypeName = new TypeName(@"", @"", @"Entity"),
                Inherits = @"",
                MemberAttribute = MemberAttributes.Assembly,
            };
            this._vm.Entities.OutputPath = Path.Combine(this._vm.OutputPath, this._vm.Entities.Namespace.Child);

            this._vm.Gateways = new TableDataGatewaysViewModel
            {
                Namespace = new Namespace(PARENT_NS, @"Data.TableDataGateways"),
                Imports = new[] { @"System", },
                TypeAttributes = TypeAttributes.Public,
                TypeName = new TypeName(@"", @"", @"Gateways"),
                Inherits = @"",
                MemberAttribute = MemberAttributes.Assembly,
            };
            this._vm.Gateways.OutputPath = Path.Combine(this._vm.OutputPath, this._vm.Gateways.Namespace.Child);

            var click = this.ButtonTransform.ClickAsObservable()
                .Subscribe(async _ =>
                {
                    await Task.WhenAll(
                        Task.Run(() =>
                        {
                            this._vm.Entities.TransformTextAsync();
                            //this._vm.Gateways.TransformTextAsync();
                        })
                    );

                    TextTemplatingProcess.StartExplorer(this._vm.OutputPath);
                });

            // データバインド
            this.Entities.DataContext = this._vm.Entities;
        }

        #region Private members...
        
        #endregion
    }
}
