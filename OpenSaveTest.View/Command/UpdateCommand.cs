
namespace OpenSave.Wpf
{
    using System;
    using System.Linq;
    using System.Net.Mime;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;

    using ButtonsControl;


    public class UpdateCommand : ICommand
    {
        private ISubject<object> textSubject = new Subject<object>();

        public UpdateCommand(System.Windows.Controls.Control control)
        {
            //this.Control = control;
            if (control is OpenSaveControl openSaveControl)
            {
                this.textSubject.Buffer(TimeSpan.FromSeconds(1))
                    .Where(Enumerable.Any)
                    .ObserveOnDispatcher()
                    .Select(Enumerable.LastOrDefault)
                    .Where(_ => _ != null)
                    .Subscribe(_ =>
                        {
                            //TextObject textObject = openSaveControl.FileObject as TextObject ?? new TextObject();

                            //typeof(TextObject).GetProperty(_.Property).SetValue(textObject, _.Value);

                            //if (openSaveControl.FileObject == null)
                            //{
                            openSaveControl.FileObject = _; //textObject;
                            //}
                        });
            }
        }

        //private System.Windows.Controls.Control Control;


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            textSubject.OnNext((object)parameter);
        }

    }

    //public class UpdateCommand : ICommand
    //{
    //    private ISubject<ObjectChangeEventArgs> textSubject = new Subject<ObjectChangeEventArgs>();

    //    public UpdateCommand(System.Windows.Controls.Control control)
    //    {
    //        //this.Control = control;
    //        if (control is OpenSaveControl openSaveControl)
    //        {
    //            this.textSubject.Buffer(TimeSpan.FromSeconds(1))
    //                .Where(Enumerable.Any)
    //                .ObserveOnDispatcher()
    //                .Select(Enumerable.LastOrDefault)
    //                .Where(_ => _ != null)
    //                .Subscribe(_ =>
    //                    {
    //                        TextObject textObject = openSaveControl.FileObject as TextObject ?? new TextObject();

    //                        typeof(TextObject).GetProperty(_.Property).SetValue(textObject, _.Value);

    //                        if (openSaveControl.FileObject == null)
    //                        {
    //                            openSaveControl.FileObject = textObject;
    //                        }
    //                    });
    //        }
    //    }

    //    //private System.Windows.Controls.Control Control;


    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter) => true;

    //    public void Execute(object parameter)
    //    {
    //        textSubject.OnNext((ObjectChangeEventArgs)parameter);
    //    }

    //}
}
