

namespace OpenSaveText.DemoWpf
{

    public class DirectoryService : OpenSaveText.DirectoryService
    {
        public DirectoryService() : base(PathObservable.PathChanges)
        {
        }
    }


 
}
