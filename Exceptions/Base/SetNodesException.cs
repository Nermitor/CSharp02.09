using System;

namespace CSharp02._09.Exceptions.Base
{
    public class SetNodesException : InvalidOperationException
    {
        public SetNodesException(string message) : base(message){}
    }
}