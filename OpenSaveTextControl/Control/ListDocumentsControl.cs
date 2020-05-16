

namespace OpenSave.Wpf
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reactive.Subjects;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;

    using Contracts;




    public class ListDocumentsControl:ListBox,IRefresh
    {
        private ISubject<IDirectoryService> directorySubject = new Subject<IDirectoryService>();
        public object DirectoryService
        {
            get { return (object)GetValue(DirectoryServiceProperty); }
            set { SetValue(DirectoryServiceProperty, value); }
        }

        
        public static readonly DependencyProperty DirectoryServiceProperty =
            DependencyProperty.Register("DirectoryService", typeof(object), typeof(ListDocumentsControl), new PropertyMetadata(null, DirectoryServiceChanged));

        private static void DirectoryServiceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ListDocumentsControl).directorySubject.OnNext(e.NewValue as IDirectoryService);
        }

        public ICommand RefreshCommand
        {
            get { return (ICommand)GetValue(RefreshCommandProperty); }
            set { SetValue(RefreshCommandProperty, value); }
        }


        public static readonly DependencyProperty RefreshCommandProperty = DependencyProperty.Register("RefreshCommand", typeof(ICommand), typeof(ListDocumentsControl), new PropertyMetadata(null));

        public ListDocumentsControl()
        {
            directorySubject.Subscribe(_ => this.Dispatcher.InvokeAsync(()=>this.ItemsSource = _.Collection, DispatcherPriority.Background));
          
            //this.SelectionChanged += ListDocumentsControl_SelectionChanged;
            this.RefreshCommand = new RefreshCommand(this);
        }



        public void Refresh(object parameter)
        {
            //var textobj2 = new TextObject() { SavePath = "D:\\Data", Text = "Text", Title = "The TItle" };
             (this.DirectoryService as IDirectoryService).Refresh();
        }




        //public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RichTextEditor));

        //public event RoutedEventHandler SelectionChanged
        //{
        //    add => this.AddHandler(SelectionChangedEvent, value);
        //    remove => this.RemoveHandler(SelectionChangedEvent, value);
        //}

        //void RaiseSelectionChangedEvent(TextObject textObject)
        //{
        //    RoutedEventArgs newEventArgs = new SelectionChangedEventArgs(ListDocumentsControl.SelectionChangedEvent, textObject);
        //    this.RaiseEvent(newEventArgs);
        //}


        //public class SelectionChangedEventArgs : RoutedEventArgs
        //{
        //    public TextObject TextObject;


        //    public SelectionChangedEventArgs(RoutedEvent routedEvent,TextObject textObject) : base(routedEvent)
        //    {
        //        this.TextObject = textObject;

        //    }
        //}



        //private void ListDocumentsControl_SelectionChanged(object sender, RoutedEventArgs e)
        //{
        //     RaiseSelectionChangedEvent(e.Source as TextObject);
        //}
    }
}
