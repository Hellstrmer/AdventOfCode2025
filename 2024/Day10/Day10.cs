﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    internal class Day10
    {
        public List<string> ReadFile()
        {
            bool example = true;
            string input = File.ReadAllText(example
                ? "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day10\\Example.txt".Trim()
                : "C:\\Users\\jespe\\source\\repos\\AdventOfCode\\2024\\Day7\\Input.txt").Trim();
            List<string> Inputs = input.Split("\r\n").ToList();
            return Inputs;
        }
        public void FirstStar()
        {

            List<string> Inputs = ReadFile();
            List<int> Matches = new List<int>();
            int SlopeCounter = 0;
            int ResultInt = 0;
            int res = 0;
            bool ResultDone = false;

            for (int x = 0; x < Inputs.Count; x++)
            {
                Console.WriteLine("Inputs! " + Inputs[x]);
                for (int y = 0; y < Inputs[x].Length; y++)
                {
                    int InputPos = Int32.Parse(Inputs[x][y].ToString());
                    //Console.WriteLine("Inputs!" + Inputs[x]);
                    
                    if (InputPos == 0)
                    {;
                        Matches = CheckPath(Inputs, x, y, 0);
                        foreach(int match in Matches)
                        {
                            
                            ResultDone = CheckPos(Inputs, match, x, y, 0);
                            if (ResultDone)
                            {
                                res++;
                                ResultDone = false;
                            }
                        }
                        

                        if (!ResultDone)
                        {
                            ResultInt = 0;
                            return;                            
                        }
                    }
                }
            }

            Console.WriteLine("Numbers: " + ResultInt);
        }
        private List<int> CheckPath(List<string> Inputs, int XFind, int YFind, int Direction)
        {
            int result = 0;

            List <int> Match = new List<int>();
            if (XFind < Inputs.Count() - 1)
            {
                Match.Add(Int32.Parse(Inputs[XFind + 1][YFind].ToString()));
            }
            if (XFind > 0)
            {
                Match.Add(Int32.Parse(Inputs[XFind - 1][YFind].ToString()));
            }
            if (YFind < Inputs[XFind].Count() - 1)
            {
                Match.Add(Int32.Parse(Inputs[XFind][YFind + 1].ToString()));
            }
            if (YFind > 0)
            {
                Match.Add(Int32.Parse(Inputs[XFind][YFind - 1].ToString()));
            }
            return Match;
        }
        

        private bool CheckPos(List<string> Inputs, int ResultInt, int XFind, int YFind, int Direction)
        {
            bool ResultOK = false;
            /*int XFind = 0;
            int YFind = 0;*/
            if (ResultInt == 9)
            {
                ResultOK = true;
                Console.WriteLine($"Found full stack! X: " + XFind + " Y: " + YFind);
            }
            if (!ResultOK)
            {
                if (Direction == 0 && YFind < Inputs[XFind].Count() -1)
                {
                    XFind = XFind;
                    YFind = YFind + 1;
                    Console.WriteLine("Y: " + YFind + " Inputs: " + (Inputs[XFind].Count() - 2));
                    int InputPos = Int32.Parse(Inputs[XFind][YFind].ToString());
                    if (InputPos == ResultInt)
                    {
                        ResultInt++;
                        CheckPos(Inputs, ResultInt, XFind, YFind, 0);
                    } 
                    else
                    {
                        CheckPos(Inputs, ResultInt -1, XFind, YFind, 1);
                    }
                } 
                else if(Direction == 0 && YFind >= Inputs[XFind].Count() - 1)
                {
                    Console.WriteLine("Numbers In Rec0: " + ResultInt);
                    CheckPos(Inputs, ResultInt - 1, XFind, YFind, 1);
                }
                    
                if (Direction == 1 && XFind < Inputs.Count() -1)
                {
                    XFind = XFind + 1;
                    YFind = YFind;
                    int InputPos = Int32.Parse(Inputs[XFind][YFind].ToString());
                    if (InputPos == ResultInt + 1)
                    {
                        ResultInt++;
                        CheckPos(Inputs, ResultInt, XFind, YFind, 1);
                    }
                    else
                    {
                        CheckPos(Inputs, ResultInt - 1, XFind, YFind, 2);
                    }
                }
                else if (Direction == 1 && XFind >= Inputs.Count() - 1)
                {
                    Console.WriteLine("Numbers In Rec1: " + ResultInt);
                    CheckPos(Inputs, ResultInt - 1, XFind, YFind, 2);
                }
                if (Direction == 2 && YFind > 0)
                {
                    XFind = XFind;
                    YFind = YFind - 1;
                    int InputPos = Int32.Parse(Inputs[XFind][YFind].ToString());
                    if (InputPos == ResultInt + 1)
                    {
                        ResultInt++;
                        CheckPos(Inputs, ResultInt, XFind, YFind, 2);
                    }
                    else
                    {
                        CheckPos(Inputs, ResultInt - 1, XFind, YFind, 3);
                    }
                }
                else if (Direction == 2 && YFind == 0)
                {
                    Console.WriteLine("Numbers In Rec2: " + ResultInt);
                    CheckPos(Inputs, ResultInt - 1, XFind, YFind, 3);
                }

                if (Direction == 3 && XFind > 0)
                {
                    XFind = XFind - 1;
                    YFind = YFind;
                    int InputPos = Int32.Parse(Inputs[XFind][YFind].ToString());
                    if (InputPos == ResultInt + 1)
                    {
                        ResultInt++;
                        CheckPos(Inputs, ResultInt, XFind, YFind, 3);
                    }
                    else
                    {
                        CheckPos(Inputs, ResultInt - 1, XFind, YFind, 0);
                    }
                }
                else if (Direction == 3 && YFind == 0)
                {
                    Console.WriteLine("Numbers In Rec3: " + ResultInt);
                    CheckPos(Inputs, ResultInt - 1, XFind, YFind, 0);
                }
            }        
            return ResultOK;
        }
        private enum Pathern
        {
            X1,
            X2,
            Y1,
            Y2
        }
    }
}

