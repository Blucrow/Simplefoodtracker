using Blucrow.Foodtracker.Services;
using static Blucrow.Foodtracker.Services.CalorieCalculator;

namespace Blucrow.Foodtracker.Objects
{
    public class PersonalInfo
    {
        public string? Username { get; set; }
        public double MaxCalories { get; set; }
        public double WeightKg { get; set; }
        public double GoalKg { get; set; }
        public double HeightCm { get; set; }
        public bool Male { get; set; } = true;
        public int Age { get; set; }
        public ActivityLevel Activity { get; set; }
        public int NumOfWeeksToAchieveGoal { get; set; }

        public void CalucalteDailyKcal()
        {
            MaxCalories = MathF.Round(CalorieCalculator.CalculateMaxDailyCalories(WeightKg, HeightCm, Age, Male, Activity, GoalKg, NumOfWeeksToAchieveGoal), MidpointRounding.AwayFromZero);
        }

    }

    


}
