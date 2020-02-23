using System;
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
            string ImageSourceRelativePath = @"../../../../Input";
            string ImageSource = GetAbsolutePath(ImageSourceRelativePath);

            // ML Model Path
            string modelRelativePath = @"../../../../Model/MLModel.zip";
            string modelPath = GetAbsolutePath(modelRelativePath);

            // Where the .txt file will be written
            string OutputTxtSourceRelativePath = @"../../../../Output/ScoredOutput.txt";
            string OutputTxtSource = GetAbsolutePath(OutputTxtSourceRelativePath);

            // Load model and predict output of sample data
            //ImagePrediction result = MLModelScorer.Predict(modelPath, ImageSource);

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


        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
    }
}
