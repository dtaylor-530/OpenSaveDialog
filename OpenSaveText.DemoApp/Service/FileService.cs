

namespace OpenSaveText.DemoWpf
{
    public class FileService : OpenSaveText.FileService
    {
        public FileService() : base(PathObservable.PathChanges)
        {
        }
    }

}
