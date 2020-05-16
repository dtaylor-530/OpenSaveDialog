using System.Windows.Input;

namespace Contracts
{
    public interface IObjectChangeEventCommand
    {
        ICommand Command { get; }
    }
}