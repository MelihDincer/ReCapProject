
namespace Core.Utilities
{
    public interface IDataResult<T> : IResult
    {
        T Data {  get; }
    }
}