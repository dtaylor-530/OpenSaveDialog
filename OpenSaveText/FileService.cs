

namespace OpenSaveText
{
    using System;
    using System.IO;

    using Contracts;

    using OpenSaveText.Model;


    public class FileService : IFileService, IObserver<string>
    {
        private string path;


        public FileService(IObservable<string> files)
        {

            files.Subscribe(this);
        }

        /// <inheritdoc cref="Load"/>
        public object Load(string fileName)
        {
            return new TextObject { Text = File.ReadAllText(System.IO.Path.Combine(this.path, fileName)), FileName = fileName /*"c:\\temp\test.txt"*/ };
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            this.path = value;
        }

        /// <inheritdoc cref="Save"/>
        public void Save(object t)
        {
            if (this.path != null)
            {
                File.WriteAllText(System.IO.Path.Combine(this.path, (t as TextObject).FileName), (t as TextObject)?.Text ?? string.Empty);
            }
            else
            {
                
          
            //throw new NullReferenceException();
            }
        }
    }


 
}
