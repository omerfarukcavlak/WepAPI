namespace Entities.Exceptions
{
    public abstract class NotFoundExceptions : Exception
    {
        protected NotFoundExceptions(string message) : base(message)
        {

        }
    }
}
