using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ML;
using ML_App.Datastructures;

namespace ML_App.ModelScorer
{
    class MLModelScorer
    {
        // For more info on consuming ML.NET models, visit https://aka.ms/model-builder-consume
        // Method for consuming model in your app
        public static ImagePrediction Predict(string modelPath, ImageData input)
        {

            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            //string modelPath = AppDomain.CurrentDomain.BaseDirectory + "MLModel.zip";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(mlModel);

            // Use model to make prediction on input data
            ImagePrediction result = predEngine.Predict(input);
            return result;
        }
    }
}
