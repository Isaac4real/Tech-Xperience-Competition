using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ML_App.Datastructures
{
    public class ImageData
    {
        [ColumnName("Label"), LoadColumn(0)]
        public string Label { get; set; }


        [ColumnName("ImageSource"), LoadColumn(1)]
        public string ImageSource { get; set; }

    }

    public class ImageDataProbability : ImageData
    {
        public string PredictedLabel;
        public float Probability { get; set; }
    }
}
