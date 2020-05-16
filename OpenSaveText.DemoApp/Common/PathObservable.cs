
namespace OpenSaveText.DemoWpf
{
    using System;
    using System.Reactive.Linq;
    using System.Windows;
    using ReactiveUI;

    static class PathObservable
    {
        public static IObservable<string> PathChanges { get; }

        static PathObservable()
        {
            PathChanges = ((DemoApp.App)Application.Current)
                .WhenAnyValue(a => a.Path);
          
        }
    }
}
