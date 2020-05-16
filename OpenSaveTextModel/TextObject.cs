
using Contracts;

namespace OpenSaveText.Model
{
    public class TextObject : IText/*, ITitle*/ //: FileObject
    {
        public string FileName { get; set; }

        public string Text { get; set; }

    }



}
