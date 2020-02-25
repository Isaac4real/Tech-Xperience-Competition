using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ML;
using ML_App.Datastructures;
using System.IO;
using System.Collections;

namespace ML_App.ModelScorer
{
    class MLModelScorer
    {
        private readonly string imagesFolder;
        private readonly List<string> allowedExt = new List<string>() { ".jpg", ".jpeg", ".png", ".gif", ".tiff", ".bmp", ".svg" };
        private readonly string outputPath;
        private readonly string modelLocation;
        private readonly MLContext mlContext;
        private readonly ITransformer mlModel;
        private readonly PredictionEngine<ImageData, ImagePrediction> predEngine;
        private string OutputTxt;

        public MLModelScorer(string modelLocation, string imagesFolder, string outputPath)
        {
            this.imagesFolder = imagesFolder;
            this.modelLocation = modelLocation;
            this.outputPath = outputPath + "ScoredOutput.txt";
            mlContext = new MLContext();
            mlModel = mlContext.Model.Load(modelLocation, out var modelInputSchema);
            predEngine = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(mlModel);
        }


        public void Predict()
        {
            ConsoleHelpers.ConsoleWriteHeader("Classificate Images: \n it might take some seconds :) ");
            if (File.Exists(imagesFolder))
            {
                // This path is a file
                ProcessFile(imagesFolder);
            }
            else if (Directory.Exists(imagesFolder))
            {
                // This path is a directory
                ProcessDirectory(imagesFolder);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", imagesFolder);
            }

            // write output
            WriteOutput(OutputTxt, outputPath);
        }


        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)

                if (allowedExt.Contains(Path.GetExtension(fileName).ToLower())) ProcessFile(fileName);
                else if (Path.GetExtension(fileName).ToLower() != ".md") ConsoleHelpers.ConsoleWriteException("Cannot process this file extension: ", Path.GetExtension(fileName));


            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }


        public void ProcessFile(string path)
        {

            var input = new ImageData();
            var result = new ImagePrediction();
            var finalresult = new ImageDataProbability();
            input.ImageSource = path;
            // Use model to make prediction on input data
            result = predEngine.Predict(input);
            finalresult.ImageSource = Path.GetFileNameWithoutExtension(input.ImageSource);
            finalresult.PredictedLabel = result.Prediction;
            finalresult.Probability = result.Score.Max()*100;
            finalresult.ConsoleWrite();

            // Save output
            OutputTxt +=( finalresult.ImageSource + " - " + finalresult.PredictedLabel + "\n");
        }

        public void WriteOutput(string OutputTxt, string outputPath)
        {
            File.WriteAllText(outputPath, OutputTxt);
        }
    }
}
