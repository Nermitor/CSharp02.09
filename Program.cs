using System;
using System.IO;

namespace CSharp02._09
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SetNodes<Int32> s = new SetNodes<int>();
            StreamReader input = new StreamReader(@"your_path");
            StreamWriter output = new StreamWriter(@"your_path");
            
            Test(ref s, ref input, ref output);
            
            input.Close();
            output.Close();
        }

        private static void WriteStack(ref SetNodes<Int32> s, ref StreamWriter outFile)
        {
            outFile.WriteLine($"Current State - {s.ToString()}");
        }

        public static void Test(ref SetNodes<Int32> s,ref StreamReader inputFile, ref StreamWriter outFile)
        {
            int lines = Convert.ToInt32(inputFile.ReadLine());

            while (lines-- > 0)
            {
                String[] curCommands = inputFile.ReadLine()?.Split();
                switch (curCommands[0])
                {
                    case "Push":
                        s.Push(Convert.ToInt32(curCommands[1]));
                        outFile.WriteLine($"Push: {curCommands[1]}");
                        WriteStack(ref s, ref outFile);
                        break;
                    case "Empty":
                        outFile.WriteLine($"Empty - {s.Empty()}");
                        break;
                    case "Pop":
                        if (s.Empty())
                            outFile.WriteLine("Not Pop - Empty");
                        else
                            outFile.WriteLine($"Pop({s.Pop()})");
                        WriteStack(ref s, ref outFile);
                        break;
                    case "Peek":
                        if (s.Empty())
                            outFile.WriteLine("Not Peek - Empty");
                        else
                        {
                            outFile.WriteLine($"Peek({s.Peek()})");
                            WriteStack(ref s, ref outFile);
                        }
                        break;
                    case "Clear":
                        s.Clear();
                        outFile.WriteLine($"Clear");
                        WriteStack(ref s, ref outFile);
                        break;
                }
            }
        }
    }
}