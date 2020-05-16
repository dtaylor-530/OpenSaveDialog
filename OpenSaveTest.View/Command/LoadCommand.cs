using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenSave.Command
{
    using System.Reactive;

    using Contracts;

    using OpenSave.Wpf;

    public class LoadCommand : ICommand
    {
        private ICanLoad openSaveControl;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => this.openSaveControl.CanLoad();

        public LoadCommand(ICanLoad openSaveControl, IObservable<Unit> canExecuteObservable)
        {
            this.openSaveControl = openSaveControl;
            canExecuteObservable.Subscribe(
                _ =>
                    {
                        this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                    });
        } 

        public void Execute(object parameter) =>
            this.openSaveControl.Load();


    }
}
