using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenSave.Command
{


    using Contracts;

    using OpenSave.Wpf;

    public interface ISave
    {
        void Save();
    }

    public class SaveCommand : ICommand
    {
        private ICanSave canSave;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => this.canSave.CanSave();

        public SaveCommand(ICanSave openSaveControl,IObservable<System.Reactive.Unit> unitObservable)
        {
            this.canSave = openSaveControl;
            unitObservable.Subscribe(
                _ =>
                    {
                        this.CanExecuteChanged?.Invoke(this,EventArgs.Empty);
                    });
        }

        public void Execute(object parameter) => 
            this.canSave.Save();


    }
}
