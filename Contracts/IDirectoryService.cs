using System.Collections;

namespace Contracts
{
    public interface IDirectoryService
    {
        IEnumerable Collection { get; }

        void Refresh();
    }
}