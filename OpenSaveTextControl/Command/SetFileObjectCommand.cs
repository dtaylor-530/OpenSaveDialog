


namespace OpenSave.Wpf
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Documents;
    using System.Windows.Input;

    using ButtonsControl;

    using Contracts;

    public class SetFileObjectCommand : ICommand
    {
        private IFileObject openSaveControl;


        //public object Editor
        //{
        //    get { return (object)GetValue(EditorProperty); }
        //    set { SetValue(EditorProperty, value); }
        //}

        //public static readonly DependencyProperty EditorProperty = DependencyProperty.Register("Editor", typeof(object), typeof(SetFileObjectCommand), new PropertyMetadata(null));
        public SetFileObjectCommand(IFileObject openSaveControl)
        {
            this.openSaveControl = openSaveControl;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            this.openSaveControl.FileObject = (parameter);
        }


        //// Create a custom routed event by first registering a RoutedEventID
        //// This event uses the bubbling routing strategy
        //public static readonly RoutedEvent ChangeEvent = EventManager.RegisterRoutedEvent("Change", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OpenSaveControl));

        //// Provide CLR accessors for the event
        //public event RoutedEventHandler Change
        //{
        //    add => this.AddHandler(ChangeEvent, Value);
        //    remove => this.RemoveHandler(ChangeEvent, Value);
        //}

        //// This method raises the Change event
        //void RaiseFileObjectChangedEvent()
        //{

        //}
    }
}
