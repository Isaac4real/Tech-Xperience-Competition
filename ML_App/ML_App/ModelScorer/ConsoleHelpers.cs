﻿using ML_App.Datastructures;
using System;
using System.IO;
using System.Linq;

namespace ML_App.ModelScorer
{
    public static class ConsoleHelpers
    {
        public static void ConsoleWriteHeader(params string[] lines)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            var maxLength = lines.Select(x => x.Length).Max();
            Console.WriteLine(new String('#', maxLength));
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("\n");
        }

        public static void ConsolePressAnyKey()
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ");
            Console.WriteLine("Please Press ENTER ");
            Console.ForegroundColor = defaultColor;
            Console.Read();
        }

        public static void ConsoleWriteException(params string[] lines)
        {
            var defaultColor = Console.ForegroundColor;
            const string exceptionTitle = "EXCEPTION";

            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exceptionTitle);
            Console.WriteLine(new String('#', exceptionTitle.Length));
            Console.ForegroundColor = defaultColor;
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public static void ConsoleWrite(this ImageDataProbability self)
        {
            var defaultForeground = Console.ForegroundColor;
            //var labelColor = ConsoleColor.Magenta;
            //var probColor = ConsoleColor.Blue;
            var exactLabel = ConsoleColor.Green;
            //var failLabel = ConsoleColor.Red;

            //Console.Write("ImagePath: ");
            Console.ForegroundColor = exactLabel;
            Console.Write($"{Path.GetFileName(self.ImageSource)}");
            Console.ForegroundColor = defaultForeground;
            Console.Write(" - ");
            Console.ForegroundColor = exactLabel;
            Console.Write(self.PredictedLabel);
            Console.ForegroundColor = defaultForeground;
            //Console.Write(" with probability ");
            //Console.ForegroundColor = probColor;
            //Console.Write(self.Probability);
            //Console.ForegroundColor = defaultForeground;
            Console.WriteLine("");
        }

    }

}
