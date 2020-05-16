using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSave.Command
{
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Windows.Input;

    using OpenSave.Wpf;

    public class SetKeyCommand : ICommand
    {
        private ISubject<string> textSubject = new Subject<string>();

        public SetKeyCommand(System.Windows.Controls.Control control)
        {
            //this.Control = control;
            if (control is OpenSaveControl openSaveControl)
            {
                this.textSubject.ObserveOnDispatcher().Subscribe(_ => openSaveControl.Key = _);
            }
        }

        //private System.Windows.Controls.Control Control;


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            textSubject.OnNext((string)parameter);
        }
    }
}