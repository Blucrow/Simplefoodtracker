using System.Text.Json.Serialization;

namespace Blucrow.Foodtracker.Objects
{
    public class Nutritions
    {
        [JsonPropertyName("carbohydrates")]
        public float? Carbohydrates { get; set; }

        [JsonPropertyName("carbohydrates_100g")]
        public float? Carbohydrates100g { get; set; }

        [JsonPropertyName("carbohydrates_serving")]
        public float? CarbohydratesServing { get; set; }

        [JsonPropertyName("carbohydrates_unit")]
        public string? CarbohydratesUnit { get; set; }

        [JsonPropertyName("carbohydrates_value")]
        public float? CarbohydratesValue { get; set; }

        [JsonPropertyName("energy")]
        public float? Energy { get; set; }

        [JsonPropertyName("energy-kcal")]
        public float? EnergyKcal { get; set; }

        [JsonPropertyName("energy-kcal_100g")]
        public float? EnergyKcal100g { get; set; }

        [JsonPropertyName("energy-kcal_serving")]
        public float? EnergyKcalServing { get; set; }

        [JsonPropertyName("energy-kcal_unit")]
        public string? EnergyKcalUnit { get; set; }

        [JsonPropertyName("energy-kcal_value")]
        public float? EnergyKcalValue { get; set; }

        [JsonPropertyName("energy-kcal_value_computed")]
        public float? EnergyKcalValueComputed { get; set; }

        [JsonPropertyName("energy_100g")]
        public float? Energy100g { get; set; }

        [JsonPropertyName("energy_serving")]
        public float? EnergyServing { get; set; }

        [JsonPropertyName("energy_unit")]
        public string? EnergyUnit { get; set; }

        [JsonPropertyName("energy_value")]
        public float? EnergyValue { get; set; }

        [JsonPropertyName("fat")]
        public float? Fat { get; set; }

        [JsonPropertyName("fat_100g")]
        public float? Fat100g { get; set; }

        [JsonPropertyName("fat_serving")]
        public float? FatServing { get; set; }

        [JsonPropertyName("fat_unit")]
        public string? FatUnit { get; set; }

        [JsonPropertyName("fat_value")]
        public float? FatValue { get; set; }

        [JsonPropertyName("fruits-vegetables-legumes-estimate-from-ingredients_100g")]
        public float? FruitsVegetablesLegumesEstimateFromIngredients100g { get; set; }

        [JsonPropertyName("fruits-vegetables-legumes-estimate-from-ingredients_serving")]
        public float? FruitsVegetablesLegumesEstimateFromIngredientsServing { get; set; }

        [JsonPropertyName("fruits-vegetables-nuts-estimate-from-ingredients_100g")]
        public float? FruitsVegetablesNutsEstimateFromIngredients100g { get; set; }

        [JsonPropertyName("fruits-vegetables-nuts-estimate-from-ingredients_serving")]
        public float? FruitsVegetablesNutsEstimateFromIngredientsServing { get; set; }

        [JsonPropertyName("nova-group")]
        public float? NovaGroup { get; set; }

        [JsonPropertyName("nova-group_100g")]
        public float? NovaGroup100g { get; set; }

        [JsonPropertyName("nova-group_serving")]
        public float? NovaGroupServing { get; set; }

        [JsonPropertyName("nutrition-score-fr")]
        public float? NutritionScoreFr { get; set; }

        [JsonPropertyName("nutrition-score-fr_100g")]
        public float? NutritionScoreFr100g { get; set; }

        [JsonPropertyName("proteins")]
        public float? Proteins { get; set; }

        [JsonPropertyName("proteins_100g")]
        public float? Proteins100g { get; set; }

        [JsonPropertyName("proteins_serving")]
        public float? ProteinsServing { get; set; }

        [JsonPropertyName("proteins_unit")]
        public string? ProteinsUnit { get; set; }

        [JsonPropertyName("proteins_value")]
        public float? ProteinsValue { get; set; }

        [JsonPropertyName("salt")]
        public float? Salt { get; set; }

        [JsonPropertyName("salt_100g")]
        public float? Salt100g { get; set; }

        [JsonPropertyName("salt_serving")]
        public float? SaltServing { get; set; }

        [JsonPropertyName("salt_unit")]
        public string? SaltUnit { get; set; }

        [JsonPropertyName("salt_value")]
        public float? SaltValue { get; set; }

        [JsonPropertyName("saturated-fat")]
        public float? SaturatedFat { get; set; }

        [JsonPropertyName("saturated-fat_100g")]
        public float? SaturatedFat100g { get; set; }

        [JsonPropertyName("saturated-fat_serving")]
        public float? SaturatedFatServing { get; set; }

        [JsonPropertyName("saturated-fat_unit")]
        public string? SaturatedFatUnit { get; set; }

        [JsonPropertyName("saturated-fat_value")]
        public float? SaturatedFatValue { get; set; }

        [JsonPropertyName("sodium")]
        public float? Sodium { get; set; }

        [JsonPropertyName("sodium_100g")]
        public float? Sodium100g { get; set; }

        [JsonPropertyName("sodium_serving")]
        public float? SodiumServing { get; set; }

        [JsonPropertyName("sodium_unit")]
        public string? SodiumUnit { get; set; }

        [JsonPropertyName("sodium_value")]
        public float? SodiumValue { get; set; }

        [JsonPropertyName("sugars")]
        public float? Sugars { get; set; }

        [JsonPropertyName("sugars_100g")]
        public float? Sugars100g { get; set; }

        [JsonPropertyName("sugars_serving")]
        public float? SugarsServing { get; set; }

        [JsonPropertyName("sugars_unit")]
        public string? SugarsUnit { get; set; }

        [JsonPropertyName("sugars_value")]
        public float? SugarsValue { get; set; }
    }
}
