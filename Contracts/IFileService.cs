namespace Contracts
{
    public interface IFileService
    {
        object Load(string key);
        void Save(object fileObject);
    }
}