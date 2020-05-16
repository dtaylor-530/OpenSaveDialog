namespace Contracts
{
    public interface IObjectChangeEvent
    {
        System.Action<object, object> ObjectChange { get; set; }
    }
}