


namespace OpenSaveText
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;

    using Contracts;

    using OpenSaveText.Model;


    public class DirectoryService:IDirectoryService,IObserver<string>
    {
        private DirectoryInfo directoryInfo;




        public DirectoryService(IObservable<string> directory)
        {
            directory.Subscribe(this);

        }

        public DirectoryService()
        {
        }

        public IEnumerable Collection { get; } = new ObservableCollection<object>();




        public void Refresh()
        {
            if(this.Collection.Cast<object>().Any())
            (this.Collection as ObservableCollection<object>).Clear();
            foreach (var item in this.GetCollection(this.directoryInfo))
            {
                (this.Collection as ObservableCollection<object>).Add(item);
            }
        }

        private IEnumerable<FileObject> GetCollection(DirectoryInfo directoryInfo) =>
            directoryInfo.GetFiles().Select(
                _ => new FileObject(_.FullName));

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
            this.directoryInfo = new System.IO.DirectoryInfo(value);
            this.directoryInfo.Create();
            this.Refresh();
        }
    }
}
