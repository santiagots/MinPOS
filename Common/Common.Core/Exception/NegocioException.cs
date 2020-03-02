namespace Common.Core.Exception
{
    public class NegocioException : System.Exception
    {
        public NegocioException()
        {
        }

        public NegocioException(string message) : base(message)
        {
        }

        public NegocioException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
