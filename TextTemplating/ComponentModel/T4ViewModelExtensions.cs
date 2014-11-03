using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.ComponentModel
{
    public static class T4ViewModelExtensions
    {
        public static IObservable<EventPattern<PropertyChangedEventArgs>> PropertyChangedAsObservable(this INotifyPropertyChanged vm)
        {
            return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                (handler) => { return (sender, e) => handler.Invoke(sender, e); }
                , (handler) => { vm.PropertyChanged += handler; }
                , (handler) => { vm.PropertyChanged -= handler; } );
        }
    }
}
