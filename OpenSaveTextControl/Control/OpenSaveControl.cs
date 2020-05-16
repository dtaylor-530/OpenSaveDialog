

namespace OpenSave.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using ButtonsControl;
    using Contracts;
    using OpenSave.Command;

    public interface ICanLoad : ILoad
    {
        bool CanLoad();
    }
    public interface ICanSave : ISave
    {
        bool CanSave();
    }



    public class OpenSaveControl : WPFUtility.ButtonsBase, IFileObject, ICanLoad, ICanSave, WPFUtility.Contracts.IObjectChangeEvent //, ISave
    {
        //public ICommand SetFileObjectCommand
        //{
        //    get { return (ICommand)GetValue(FileObjectCommandProperty); }
        //    set { SetValue(FileObjectCommandProperty, value); }
        //}

        //public static readonly DependencyProperty FileObjectCommandProperty = DependencyProperty.Register("SetFileObjectCommand", typeof(ICommand), typeof(OpenSaveControl), new PropertyMetadata(null));

        #region Commands
        public ICommand SetFileObjectCommand
        {
            get { return (ICommand)GetValue(SetFileObjectCommandProperty); }
            set { SetValue(SetFileObjectCommandProperty, value); }
        }

        public static readonly DependencyProperty SetFileObjectCommandProperty = DependencyProperty.Register("SetFileObjectCommand", typeof(ICommand), typeof(OpenSaveControl), new PropertyMetadata(null));


        public ICommand SetKeyCommand
        {
            get { return (ICommand)GetValue(SetKeyCommandProperty); }
            set { SetValue(SetKeyCommandProperty, value); }
        }

        public static readonly DependencyProperty SetKeyCommandProperty = DependencyProperty.Register("SetKeyCommand", typeof(ICommand), typeof(OpenSaveControl), new PropertyMetadata(null));


        public ICommand LoadCommand
        {
            get { return (ICommand)GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value); }
        }

        public static readonly DependencyProperty LoadCommandProperty = DependencyProperty.Register("LoadCommand", typeof(ICommand), typeof(OpenSaveControl), new PropertyMetadata(null));


        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }

        public static readonly DependencyProperty SaveCommandProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(OpenSaveControl), new PropertyMetadata(null));


        #endregion Commands

        static OpenSaveControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OpenSaveControl), new FrameworkPropertyMetadata(typeof(OpenSaveControl)));
        }

        public OpenSaveControl()
        {
            //this.SetFileObjectCommand = this.MakeSetFileObjectCommand();
            this.SetFileObjectCommand = new SetFileObjectCommand(this);
            this.LoadCommand = new LoadCommand(this, Observable.Empty<Unit>() );
            this.SaveCommand = new SaveCommand(this, FileObjectChanges.Select(_ => System.Reactive.Unit.Default));
            this.SetKeyCommand = new SetKeyCommand(this);
        }


        #region Properties

        public object FileObject
        {
            get { return (object)GetValue(FileObjectProperty); }
            set { SetValue(FileObjectProperty, value); }
        }

        public static readonly DependencyProperty FileObjectProperty = DependencyProperty.Register("FileObject", typeof(object), typeof(OpenSaveControl), new PropertyMetadata(null, FileObjectChanged0));


        public string Key
        {
            get { return (string)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }


        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(string), typeof(OpenSaveControl), new PropertyMetadata(null));

        #endregion Properties




        //protected virtual ICommand MakeSetFileObjectCommand() => new UpdateCommand(this);

        ISubject<object> FileObjectChanges = new Subject<object>();

        private static void FileObjectChanged0(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as OpenSaveControl).RaiseFileObjectChangedEvent();
            (d as OpenSaveControl).FileObjectChanges.OnNext(e.NewValue);
        }

        protected override void PropertyChange(object service, Dictionary<string, Button> dictionary)
        {
            IFileService fileService = service as IFileService;

            dictionary[Constants.Open].Command = this.LoadCommand;
            dictionary[Constants.Save].Command = this.SaveCommand;

            //TODO add logic
            dictionary[Constants.New].Click += (a, b) =>
                this.Dispatcher.InvokeAsync(() => { }, DispatcherPriority.Background);
        }



        public static readonly RoutedEvent ObjectChangeEvent = EventManager.RegisterRoutedEvent("ObjectChange", RoutingStrategy.Bubble, typeof(WPFUtility.RoutedObjectChangeEventHandler), typeof(OpenSaveControl));


        public event WPFUtility.RoutedObjectChangeEventHandler ObjectChange
        {
            add => this.AddHandler(ObjectChangeEvent, value);
            remove => this.RemoveHandler(ObjectChangeEvent, value);
        }

        void RaiseFileObjectChangedEvent()
        {
            RoutedEventArgs newEventArgs = new WPFUtility.ObjectChangeEventArgs(OpenSaveControl.ObjectChangeEvent, this.FileObject);
            this.RaiseEvent(newEventArgs);
        }


        // Create a custom routed event by first registering a RoutedEventID
        // This event uses the bubbling routing strategy
        public static readonly RoutedEvent SavedEvent = EventManager.RegisterRoutedEvent("Saved", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OpenSaveControl));

        // Provide CLR accessors for the event
        public event RoutedEventHandler Saved
        {
            add => this.AddHandler(SavedEvent, value);
            remove => this.RemoveHandler(SavedEvent, value);
        }

        // This method raises the Saved event
        void RaiseSavedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs();
            this.RaiseEvent(newEventArgs);
        }




        public void Load() => this.Dispatcher.InvokeAsync(() =>
                   {
                       this.FileObject = (this.Service as IFileService).Load(this.Key);
                       this.RaiseFileObjectChangedEvent();
                   }, DispatcherPriority.Background);

        public void Save() => this.Dispatcher.InvokeAsync(() =>
            {
                (this.Service as IFileService).Save(this.FileObject);
                this.RaiseSavedEvent();
            }, DispatcherPriority.Background);

        public bool CanLoad() => Key != null;

        public bool CanSave() => this.FileObject != null;
    }
}
