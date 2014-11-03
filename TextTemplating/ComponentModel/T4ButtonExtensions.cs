using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.ComponentModel
{
    public static class T4ButtonBaseExtensions
    {
        public static IObservable<EventPattern<RoutedEventArgs>> ClickAsObservable(this ButtonBase button)
        {
            return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
                handler => (sender, e) => handler.Invoke(button, e)
                , handler => button.Click += handler
                , handler => button.Click += handler
                );
        }
    }
}