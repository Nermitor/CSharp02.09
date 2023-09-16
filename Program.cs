using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp02._09
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamReader input = new StreamReader(@"C:\\Users\\dmaty\\RiderProjects\\CSharp02.09\\test3.txt");
            List<SetNodes<int>> setNodesList = ReadSetNodesList(ref input);
            input.Close();

            StreamWriter output = new StreamWriter(@"C:\\Users\\dmaty\\RiderProjects\\CSharp02.09\\out.txt");
            WriteSetNodesList(ref output, ref setNodesList);
            output.Close();
        }

        public static void FillSetNodes(SetNodes<int> setNodes)
        {
            int[] a = { 1, 2, 3 };
            foreach (int item in a)
            {
                setNodes.Push(item);
            }
        }

        public static List<SetNodes<int>> ReadSetNodesList(ref StreamReader input)
        {
            List<SetNodes<int>> setNodesList = new List<SetNodes<int>>();

            foreach (char number in input.ReadLine())
            {
                var setNodes = (Convert.ToInt32(number) == '1' ? new SetNodesWithCount<int>() : new SetNodes<int>());
                FillSetNodes(setNodes);
                setNodesList.Add(setNodes);
            }

            return setNodesList;
        }

        public static void WriteSetNodesList(ref StreamWriter output, ref List<SetNodes<int>> setNodesList)
        {
            foreach (var setNodes in setNodesList)
                if (setNodes is SetNodesWithCount<int>)
                    output.WriteLine($"Count: {(setNodes as SetNodesWithCount<int>).Count}");
                else
                    output.WriteLine("Count: Method not available");
        }
    }
}