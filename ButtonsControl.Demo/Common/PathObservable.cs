
namespace OpenSaveText.DemoWpf
{
    using System;
    using System.Reactive.Linq;
    using System.Windows;
    //using ReactiveUI;
    //using ReactiveUI.WPF;

    static class PathObservable
    {
        public static IObservable<string> PathChanges { get; }

        static PathObservable()
        {
            //PathChanges = ((App)Application.Current)
            //    .WhenAnyValue(a=>)
            //    .Where(_ => _.Item1 == nameof(App.Path))
            //    .Select(_ => _.Item2.Path);
        }
    }
}
