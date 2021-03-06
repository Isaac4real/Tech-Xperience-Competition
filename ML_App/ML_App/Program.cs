﻿using System;
using ML_App.Datastructures;
using ML_App.ModelScorer;
using System.IO;

namespace ML_App
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelpers.ConsoleWriteHeader("Welcome to the A.I. Classifier, Philips!");

            // Input's Images Folder
            /* IF BUILDING NORMALLY */ string ImageSourceRelativePath = @"../../../../Input/";
            /* IF BUILDING DOCKER IMAGE USE THIS *///string ImageSourceRelativePath = @"Input/";
            string ImageSource = Path.GetFullPath(ImageSourceRelativePath);

            // ML Model Path
            /* IF BUILDING NORMALLY */ string modelRelativePath = @"../../../MLModel/MLModel.zip";
            /* IF BUILDING DOCKER IMAGE USE THIS *///string modelRelativePath = @"MLModel/MLModel.zip";
            string modelPath = Path.GetFullPath(modelRelativePath);

            // Where the .txt file will be written
            /* IF BUILDING NORMALLY */ string OutputTxtSourceRelativePath = @"../../../../Output/";
            /* IF BUILDING DOCKER IMAGE USE THIS *///string OutputTxtSourceRelativePath = @"Output/";
            string OutputTxtSource = Path.GetFullPath(OutputTxtSourceRelativePath);

            try
            {
                var modelScorer = new MLModelScorer(modelPath, ImageSource, OutputTxtSource);
                modelScorer.Predict();

            }
            catch (Exception ex)
            {
                ConsoleHelpers.ConsoleWriteException(ex.ToString());
            }

            ConsoleHelpers.ConsolePressAnyKey();
        }
    }
}
