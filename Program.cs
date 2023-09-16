using System;
using System.IO;
using CSharp02._09.Exceptions;

namespace CSharp02._09
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamReader input = new StreamReader(@"C:\\Users\\dmaty\\RiderProjects\\CSharp02.09\\test5.txt");
            StreamWriter output = new StreamWriter(@"C:\\Users\\dmaty\\RiderProjects\\CSharp02.09\\out.txt");

            Test(ref input, ref output);

            input.Close();
            output.Close();
        }

        private static void WriteStack(ref SetNodes<Int32> s, ref StreamWriter outFile)
        {
            outFile.WriteLine($"Current State - {s.ToStr()}");
        }

        public static void Test(ref StreamReader inputFile, ref StreamWriter outFile)
        {
            int type = Convert.ToInt32(inputFile.ReadLine());
            SetNodes<int> setNodes = (type == 1 ? new SetNodesWithCount<int>() : new SetNodes<int>());

            int lines = Convert.ToInt32(inputFile.ReadLine());

            while (lines-- > 0)
            {
                String[] curCommands = inputFile.ReadLine()?.Split();
                switch (curCommands[0])
                {
                    case "Push":
                        setNodes.Push(Convert.ToInt32(curCommands[1]));
                        outFile.WriteLine($"Push: {curCommands[1]}");
                        WriteStack(ref setNodes, ref outFile);
                        break;
                    case "Empty":
                        outFile.WriteLine($"Empty - {setNodes.Empty()}");
                        break;
                    case "Pop":
                        try
                        {
                            outFile.WriteLine($"Pop({setNodes.Pop()})");
                            WriteStack(ref setNodes, ref outFile);
                            break;
                        }
                        catch (SetNodesPopException e)
                        {
                            outFile.WriteLine(e.Message);
                            return;
                        }

                    case "Peek":
                        try
                        {
                            outFile.WriteLine($"Peek({setNodes.Peek()})");
                            WriteStack(ref setNodes, ref outFile);
                            break;
                        }
                        catch (SetNodesPeekException e)
                        {
                            outFile.WriteLine(e.Message);
                            return;
                        }

                    case "Clear":
                        setNodes.Clear();
                        outFile.WriteLine($"Clear");
                        WriteStack(ref setNodes, ref outFile);
                        break;
                    case "Count":
                        if (setNodes is SetNodesWithCount<int>)
                            outFile.WriteLine($"Count: {(setNodes as SetNodesWithCount<int>).Count}");
                        else
                            outFile.WriteLine("Count: Method not available");
                        break;
                }
            }
        }
    }
}