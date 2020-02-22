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

            // Input's Images Folder
            string ImageSourceRelativePath = @"../../../../Input";
            string ImageSource = GetAbsolutePath(ImageSourceRelativePath);

            // ML Model Path
            string modelRelativePath = @"../../../../Model/MLModel.zip";
            string modelPath = GetAbsolutePath(modelRelativePath);

            // Load model and predict output of sample data
            //ImagePrediction result = MLModelScorer.Predict(modelPath, ImageSource);

            try
            {
                var modelScorer = new MLModelScorer(modelPath, ImageSource);
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
