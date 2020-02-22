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
        private readonly string modelLocation;
        private readonly MLContext mlContext;
        private readonly ITransformer mlModel;
        private readonly PredictionEngine<ImageData, ImagePrediction> predEngine;

        public MLModelScorer(string modelLocation, string imagesFolder)
        {
            this.imagesFolder = imagesFolder;
            this.modelLocation = modelLocation;
            mlContext = new MLContext();
            mlModel = mlContext.Model.Load(modelLocation, out var modelInputSchema);
            predEngine = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(mlModel);
        }
        // For more info on consuming ML.NET models, visit https://aka.ms/model-builder-consume
        // Method for consuming model in your app
        public void Predict()
        {

            // Create new MLContext
            //MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            //string modelPath = AppDomain.CurrentDomain.BaseDirectory + "MLModel.zip";
            //ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            //var predEngine = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(mlModel);


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

            //var input = new ImageData();
            // Use model to make prediction on input data
            //magePrediction result = predEngine.Predict(input);
            
        }


        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        public void ProcessFile(string path)
        {
            //Console.WriteLine("Processed file '{0}'.", path);
            var input = new ImageData();
            var result = new ImagePrediction();
            var finalresult = new ImageDataProbability();
            input.ImageSource = path;
            // Use model to make prediction on input data
            result = predEngine.Predict(input);
            finalresult.ImageSource = input.ImageSource;
            finalresult.PredictedLabel = result.Prediction;
            finalresult.Probability = result.Score[0];
            finalresult.ConsoleWrite();
        }
    }
}
