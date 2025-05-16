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

        public static int CalculateDailyCalories(int age, bool isMale, double heightCm, double weightKg, ActivityLevel activityLevel)
        {
            double bmr;

            // Mifflin-St Jeor Equation for BMR
            if (isMale)
            {
                bmr = (10 * weightKg) + (6.25 * heightCm) - (5 * age) + 5;
            }
            else // Female
            {
                bmr = (10 * weightKg) + (6.25 * heightCm) - (5 * age) - 161;
            }

            double activityFactor;

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
                    activityFactor = 1.2; // Default to sedentary for any unhandled case
                    break;
            }

            double dailyCalories = bmr * activityFactor;
            return (int)Math.Ceiling(dailyCalories);
        }
    }
}
