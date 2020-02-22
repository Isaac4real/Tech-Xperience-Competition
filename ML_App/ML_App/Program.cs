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
            Console.WriteLine("Hello World!");

            // Add input data
            var input = new ImageData();
            string assetsRelativePath = @"../../../../Input/imagetest.png";
            string assetsPath = GetAbsolutePath(assetsRelativePath);
            input.ImageSource = assetsPath;

            string modelRelativePath = @"../../../../Model/MLModel.zip";
            string modelPath = GetAbsolutePath(modelRelativePath);

            // Load model and predict output of sample data
            ImagePrediction result = MLModelScorer.Predict(modelPath, input);
            Console.WriteLine($"img: {input.ImageSource} Is : {result.Prediction} with a Score of: {result.Score}");

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
