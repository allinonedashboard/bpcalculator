using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    /// <summary>
    ///  Blood Pressure Category enumeration
    ///  Additional categories added based on the UK NHS breakdown
    /// </summary>
    public enum BPCategory
    {
        [Display(Name = "No BP Calculated")] None,
        [Display(Name = "Low BP")] Low,
        [Display(Name = "Ideal BP")] Ideal,
        [Display(Name = "PreHigh Bp")] PreHigh,
        [Display(Name = "High BP")] High,
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 130;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value provided")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value provided")]
        public int Diastolic { get; set; }                      // mmHG


        /// <summary>
        /// Returns the blood pressure category based on the 
        /// Systolic Value and Diastolic Value provided
        /// </summary>
        public BPCategory Category
        {
            get
            {
                BPCategory rtnValue = BPCategory.None;

                if (this.IsLowPressure()) { return BPCategory.Low; }
                if (this.IsIdealPressure()) { return BPCategory.Ideal; }
                if (this.IsPreHighPressure()) { return BPCategory.PreHigh; }
                if (this.IsHighPressure()) { return BPCategory.High; }

                return rtnValue;
            }
        }

        private bool IsLowPressure()
        {
            return (this.Diastolic < 60 || this.Systolic < 90);
        }


        private bool IsIdealPressure()
        {
            bool v = (this.Systolic > 80 && this.Systolic < 120);
            return v && (this.Diastolic >= 40 && this.Diastolic < 80);
        }


        private bool IsPreHighPressure()
        {
            if ((this.Systolic >= 120 && this.Systolic <= 139) && (Diastolic <= 80) || (Systolic >= 81 && Systolic <= 139) && (Diastolic >= 80 && Diastolic <= 89))
            {
                return true;
            }
            return (this.Diastolic >= 80 && this.Diastolic < 90);

        }

        private bool IsHighPressure()
        {

            if (this.Systolic >= 140 && this.Systolic <= 190)
            {
                return true;
            }
            return (this.Diastolic >= 90 && this.Diastolic <= 100);
        }

    }
}

