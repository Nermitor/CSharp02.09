using System;

namespace CSharp02._09
{
    public class SetNodesWithCount <T>: SetNodes<T>
    {
        private Int32 cnt;

        public Int32 Count { get; }

        public override T Pop()
        {
            cnt--;
            return base.Pop();
        }

        public override void Clear()
        {
            base.Clear();
            cnt = 0;
        }

        public override void Push(T value)
        {
            base.Push(value);
            cnt++;
        }

        public new String ToString()
        {
            return base.ToString() + $"[{cnt}]";
        }
    }
}