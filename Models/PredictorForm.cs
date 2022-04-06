using System;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace INTEX_II.Models
{
    public class PredictorForm
    {
        // These are the fields that the preditor model is expecting
        public float PEDESTRIAN_INVOLVED { get; set; }
        public float BICYCLIST_INVOLVED { get; set; }
        public float MOTORCYCLE_INVOLVED { get; set; }
        public float IMPROPER_RESTRAINT { get; set; }
        public float DUI { get; set; }
        public float INTERSECTION_RELATED { get; set; }
        public float OVERTURN_ROLLOVER { get; set; }
        public float OLDER_DRIVER_INVOLVED { get; set; }
        public float CRASH_MONTH { get; set; }
        public float CRASH_YEAR { get; set; }

        public PredictorForm(RawForm raw)
        {
            PEDESTRIAN_INVOLVED = BoolToFloat(raw.PEDESTRIAN_INVOLVED);
            BICYCLIST_INVOLVED = BoolToFloat(raw.BICYCLIST_INVOLVED);
            MOTORCYCLE_INVOLVED = BoolToFloat(raw.MOTORCYCLE_INVOLVED);
            IMPROPER_RESTRAINT = BoolToFloat(raw.IMPROPER_RESTRAINT);
            DUI = BoolToFloat(raw.DUI);
            INTERSECTION_RELATED = BoolToFloat(raw.INTERSECTION_RELATED);
            OVERTURN_ROLLOVER = BoolToFloat(raw.OVERTURN_ROLLOVER);
            OLDER_DRIVER_INVOLVED = BoolToFloat(raw.OLDER_DRIVER_INVOLVED);
            CRASH_MONTH = raw.CRASH_MONTH;
            CRASH_YEAR = raw.CRASH_YEAR;
        }

        private float BoolToFloat(bool input)
        {
            if (input)
            {
                return 1.0F;
            }
            else
            {
                return 0.0F;
            }
        }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            PEDESTRIAN_INVOLVED, BICYCLIST_INVOLVED, MOTORCYCLE_INVOLVED, IMPROPER_RESTRAINT,
            DUI, INTERSECTION_RELATED, OVERTURN_ROLLOVER, OLDER_DRIVER_INVOLVED
            };
            int[] dimensions = new int[] { 1, 10 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
