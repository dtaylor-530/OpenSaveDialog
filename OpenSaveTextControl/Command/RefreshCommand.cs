using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSave.Wpf
{

    using System.Windows.Input;

    using ButtonsControl;

    using Contracts;

    public class RefreshCommand :  ICommand
    {
        private IRefresh ldControl;


        public RefreshCommand(IRefresh control)
        {
            this.ldControl = control;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ldControl.Refresh(parameter);
        }

    }
}
