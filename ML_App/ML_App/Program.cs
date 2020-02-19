using System;
using ML_AppML.Model;

namespace ML_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Add input data
            var input = new ModelInput();
            input.ImageSource = "../../../../Dataset/shaver/image10.jpg";

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            Console.WriteLine($"img: {input.ImageSource}\n Is : {result.Prediction}");
        }
    }
}
