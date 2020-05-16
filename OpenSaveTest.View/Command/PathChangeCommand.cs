using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSave.Wpf
{

    using System;
    using System.Net.Mime;
    using System.Windows;
    using System.Windows.Input;
    using Contracts;
    public class PathChangeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Application.Current.Dispatcher.InvokeAsync(() => this.pathcontrol.Path = (string)parameter);
        }

        private IPath pathcontrol;

        public PathChangeCommand(IPath pathcontrol)
        {
            this.pathcontrol = pathcontrol;
            //pathChangeCommand.Path= .Execute(pathChangeCommand);

        }
    }
}
