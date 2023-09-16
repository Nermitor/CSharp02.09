using CSharp02._09.Exceptions.Base;

namespace CSharp02._09.Exceptions
{
    public class SetNodesPopException : SetNodesException
    {
        public SetNodesPopException(string message): base(message){}
    }
}