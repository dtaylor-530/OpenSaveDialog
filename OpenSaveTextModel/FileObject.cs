

namespace OpenSaveText.Model
{
    using Contracts;

    public class FileObject : IPath/*,IFileName*/
    {
        public FileObject(string path)
        {
            this.Path = path;
        }

        public string Path { get; set; }

        public object Contents { get; set; }

        public static class Helper
        {
            public static string GetFileName(IPath path) => System.IO.Path.GetFileName(path.Path);

        }
        //public string FileName => System.IO.Path.GetFileName(Path);
    }


}
