﻿namespace AdventOfCode._2024
{
    internal class Day7
    {
        public List<string> ReadFile()
        {
            bool example = true;
            string input = File.ReadAllText(example
                ? "C:\\Users\\jespe\\Source\\Repos\\Hellstrmer\\AdventOfCode2024\\2024\\Day8\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day7\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }
        public void FirstStar()
        {
            List<string> Inputs = ReadFile();
            ulong CheckNumb = 0;
            ulong EndNumb = 0;
            string AddUp = "";

            foreach (string Input in Inputs)
            {
                CheckNumb =  ulong.Parse(Input.Substring(0, Input.IndexOf(":")));
                AddUp = Input.Substring(Input.IndexOf(":") +1).Trim();
                List<ulong> Path = FindNumbs(AddUp);
                if (ControlNumbs(CheckNumb, Path, 0))
                {
                    EndNumb += CheckNumb;
                }
            }
            Console.WriteLine("Numbers: " + EndNumb);            
        }

        public List<ulong> FindNumbs(string AddUp)
        {
            string t = "";
            List <string> Inputs = new List<string>();
            List <ulong> num = new List<ulong>();
            for(int i = 0; i < AddUp.Length; i++)
            {
                if (AddUp[i].ToString() != " " || i == AddUp.Length -1)
                {
                    t += AddUp[i].ToString();
                } 
                else
                {
                    num.Add(ulong.Parse(t));
                    t = "";
                } 
                if (i == AddUp.Length - 1)
                {
                    num.Add(ulong.Parse(t));
                    t = "";
                }
            }            
            return num;
        }

        public bool ControlNumbs(ulong CheckNumb, List<ulong> Path, int MathVersion)
        {
            var comb = Combinations(Path);
            foreach(var ops in comb)
            {
                    ulong test = Evaluate(ops, Path, CheckNumb);
                    if (Evaluate(ops, Path, CheckNumb) == CheckNumb)
                    {
                        return true;
                    }          
            }
            return false;
        }

        private ulong Evaluate(List<MathMethod> ops, List<ulong> Path, ulong CheckNumb)
        {
            var result = Path[0];
            for (int i = 0; i < ops.Count; i++) 
            {
                result = ops[i] switch
                {
                    MathMethod.Add => result + Path[i + 1],
                    MathMethod.Multiply => result * Path[i + 1]
                };
            }
            return result;
        }
        private IEnumerable <List<MathMethod>> Combinations(List<ulong> Path)
        {
            var OPCount = Path.Count - 1;
            var States = 2;
            var CombinationCount = (int)Math.Pow(States, OPCount);

            for (int i = 0; i < CombinationCount; i++)
            {
                var combination = new List<MathMethod>();
                var Value = i;

                for (int pos = 0; pos < OPCount; pos++)
                {
                    var op = (Value % States) switch
                    {
                        0 => MathMethod.Add,
                        1 => MathMethod.Multiply
                    };
                    combination.Add(op);
                    Value /= States;
                }
                yield return combination;
            }
        }

        private enum MathMethod
        {
            Add,
            Multiply
        }        
    }
}

