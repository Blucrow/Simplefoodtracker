namespace Blucrow.Foodtracker.Services
{
    public static class CalorieCalculator
    {
        public enum ActivityLevel
        {
            Sedentary,
            LightlyActive,
            ModeratelyActive,
            VeryActive,
            ExtraActive
        }

        // Method to calculate BMR using Mifflin-St Jeor equation
        public static double CalculateBMR(double weightKg, double heightCm, int age, bool male)
        {
            double bmr = 0;

            if (male)
            {
                bmr = (10 * weightKg) + (6.25 * heightCm) - (5 * age) + 5;
            }
            else if (!male)
            {
                bmr = (10 * weightKg) + (6.25 * heightCm) - (5 * age) - 161;
            }
            else
            {
                throw new ArgumentException("Invalid gender. Please enter 'male' or 'female'.");
            }

            return bmr;
        }

        // Method to calculate TDEE based on BMR and activity level
        public static double CalculateTDEE(double bmr, ActivityLevel activityLevel)
        {
            double activityFactor = 0;

            switch (activityLevel)
            {
                case ActivityLevel.Sedentary:
                    activityFactor = 1.2;
                    break;
                case ActivityLevel.LightlyActive:
                    activityFactor = 1.375;
                    break;
                case ActivityLevel.ModeratelyActive:
                    activityFactor = 1.55;
                    break;
                case ActivityLevel.VeryActive:
                    activityFactor = 1.725;
                    break;
                case ActivityLevel.ExtraActive:
                    activityFactor = 1.9;
                    break;
                default:
                    throw new ArgumentException("Invalid activity level.");
            }

            return bmr * activityFactor;
        }

        // Method to calculate maximum daily calories for a given weight goal and timeframe
        public static int CalculateMaxDailyCalories(double weightKg, double heightCm, int age, bool male, ActivityLevel activityLevel, double goalWeightKg, int weeksToReachGoal)
        {
            // Calculate BMR and TDEE
            double bmr = CalculateBMR(weightKg, heightCm, age, male);
            double tdee = CalculateTDEE(bmr, activityLevel);

            // Calculate weight difference
            double weightDifferenceKg = weightKg - goalWeightKg;
            // Ensure the weight difference is not zero to avoid division by zero.


            // Calculate total calories to lose/gain
            double totalCaloriesToChange = weightDifferenceKg * 7700; // 1 kg of fat is approximately 7700 calories

            // Calculate daily calorie deficit/surplus
            double dailyCalorieDeficitSurplus = totalCaloriesToChange / (weeksToReachGoal * 7);

            // Calculate maximum daily calories
            double maxDailyCalories = Math.Ceiling(tdee - dailyCalorieDeficitSurplus);
            if (maxDailyCalories <= 0)
            {
                return 1200;
            }
            return (int)maxDailyCalories;
        }
    }
}
