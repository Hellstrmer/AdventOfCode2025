﻿
namespace AdventOfCode._2024
{
    internal class Day6
    {
        public List<string> ReadFile()
        {
            bool example = true;
            string input = File.ReadAllText(example
                ? "C:\\Users\\clj608\\Source\\Repos\\Hellstrmer\\AdventOfCode2025\\2024\\Day6\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day6\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }
        public void FirstStar()
        {
            List<string> Inputs = ReadFile();
            List<int> First = new List<int>();
            List<int> Second = new List<int>();
            List<List<string>> Path = new List<List<string>>();
            int ResultInt = 0;

            for (int x = 0; x < Inputs.Count; x++)
            {
                for (int y = 0; y < Inputs[x].Length; y++) 
                {
                 if (Inputs[x][y].ToString() == "^")
                    {
                        FindStop(x, y, -1, 0);
                    }
                }
            }
        }

        public void FindStop(int x, int y, int Xdirection, int YDirection)
        {

        }



        public void SecondStar()
        {
            /*//Inte alls färdig, tänkte helt fel.
            List<string> Inputs = ReadFile();
            List<int> First = new List<int>();
            List<int> Second = new List<int>();
            List<List<string>> Path = new List<List<string>>();
            int ResultInt = 0;

            foreach (string d in Inputs)
            {
                if (d.IndexOf('|') != -1)
                {
                    string f = d.Substring(0, d.IndexOf('|')).Trim();
                    string l = d.Substring(d.IndexOf('|') + 1).Trim();
                    First.Add(Int32.Parse(f));
                    Second.Add(Int32.Parse(l));
                }
                else if (d.IndexOf(",") != -1)
                {
                    List<string> tPath = d.Split(',').ToList();
                    tPath.Select(int.Parse).ToList();
                    ResultInt += sortList(true, tPath, First, Second);
                }
            }
            Console.WriteLine("Result: " + ResultInt);
            */
        }
    }
}
