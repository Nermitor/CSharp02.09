using CSharp02._09.Exceptions.Base;

namespace CSharp02._09.Exceptions
{
    public class SetNodesPeekException : SetNodesException
    {
        public SetNodesPeekException(string message): base(message){}
    }
}