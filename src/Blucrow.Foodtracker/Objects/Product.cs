namespace Blucrow.Foodtracker.Objects
{
    public class Product
    {
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public string? Barcode { get; set; }
        public Nutritions? Nutritions { get; set; }
        public List<Consumed?>? Consumed { get; set; }

        public List<NutritionData> GetNutrionsAsData()
        {
            var data = new List<NutritionData>();

            data.Add(new NutritionData
            {
                NutritionType = "Calories",
                OverallAmount = Nutritions!.EnergyKcal,
                Per100g = Nutritions!.EnergyKcal100g,
                PerServing = Nutritions!.EnergyKcalServing,
            });
            data.Add(new NutritionData
            {
                NutritionType = "Protein",
                OverallAmount = Nutritions!.Proteins,
                Per100g = Nutritions!.Proteins100g,
                PerServing = Nutritions!.ProteinsServing,
            });
            data.Add(new NutritionData
            {
                NutritionType = "Carbohydrates",
                OverallAmount = Nutritions!.Carbohydrates,
                Per100g = Nutritions!.Carbohydrates100g,
                PerServing = Nutritions!.CarbohydratesServing,
            });
            data.Add(new NutritionData
            {
                NutritionType = "Fat",
                OverallAmount = Nutritions!.Fat,
                Per100g = Nutritions!.Fat100g,
                PerServing = Nutritions!.FatServing,
            });
            data.Add(new NutritionData
            {
                NutritionType = "Sugar",
                OverallAmount = Nutritions!.Sugars,
                Per100g = Nutritions!.Sugars100g,
                PerServing = Nutritions!.SugarsServing,
            });

            return data;
        }

    }

    public class NutritionData
    {
        public string? NutritionType { get; set; }
        public float? OverallAmount { get; set; }
        public float? Per100g { get; set; }
        public float? PerServing { get; set; }
    }
}
