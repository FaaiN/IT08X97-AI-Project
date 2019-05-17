using System;
using System.Collections.Generic;

namespace agent
{
    public class User
    {
        public string Id { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }
        public double GoalWeight { get; set; }

        public User() { }

        public User(string gender, double height, double weight)
        {
            Gender = gender;
            this.Height = height;
            this.Weight = weight;
        }

        // BMI Calculation to find out if under/nomral/overweght
        public double CalculateBMI()
        {
            if (Height > 0 && Weight > 0)
            {
                BMI = Weight / (Height/100 * Height/100);
            }
            return BMI;
        }

        // BMI result
        public string BmiResult()
        {
            if(BMI < 18.5) { return "You are underweight!"; }
            else if (BMI > 25) { return "You are overweight!"; }
            else { return "Your weight is normal"; }
        }

        // Calculation to find out how calorie needs in meal
        public double CaloricNeeds(string Gender)
        {
            double gMultiplier = 1.0; // gender == male
            double fMultiplier = 1.0; // bmi = normal weight

            if (Gender.Equals("female", StringComparison.OrdinalIgnoreCase)) { gMultiplier = 0.9; }
            if (BMI < 18.5) { fMultiplier = 1.2; } else if (BMI > 25.0) { fMultiplier = 0.8; }
      
            return Weight * gMultiplier * 24 * fMultiplier * 3;
        }
    }
}
