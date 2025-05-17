using System.Text.Json;
using System.Web;
using Blucrow.Foodtracker.Objects;

namespace Blucrow.Foodtracker.Services
{
    public static class Foodservice
    {
        public static async Task<List<Product>?> SearchProductAsync(string searchTerm)
        {
            // Base URL for the Open Food Facts search API.
            const string baseApiUrl = "https://world.openfoodfacts.org/cgi/search.pl";

            // Construct the full URL, encoding the search term to handle spaces and special characters.
            string encodedSearchTerm = HttpUtility.UrlEncode(searchTerm);
            string fullUrl = $"{baseApiUrl}?search_terms={encodedSearchTerm}&search_simple=1&action=process&json=1";

            // Create an HttpClient instance.  It's good practice to use 'using' to ensure proper disposal.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send an asynchronous GET request to the constructed URL.
                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    // Ensure the HTTP response was successful (status code 200-299).
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string.  This is the JSON data.
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    return ExtractProducts(jsonResult); // Return the JSON string.
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request errors (e.g., network issues, server errors).
                    Console.WriteLine($"Error: HTTP request failed.  Details: {ex.Message}");
                    return null; // Return null to indicate failure.  Consider logging the error.
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., invalid URL, JSON parsing issues - though ReadAsStringAsync shouldn't throw).
                    Console.WriteLine($"Error: An unexpected error occurred. Details: {ex.Message}");
                    return null; // Return null to indicate failure.  Consider logging the error.
                }
            }
        }

        public static async Task<Product?> GetProductByBarcode(string barcode)
        {
            // Base URL for the Open Food Facts search API.
            const string baseApiUrl = "https://world.openfoodfacts.net/api/v2/product";

            // Construct the full URL, encoding the search term to handle spaces and special characters.
            string fullUrl = $"{baseApiUrl}/{barcode}";

            // Create an HttpClient instance.  It's good practice to use 'using' to ensure proper disposal.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send an asynchronous GET request to the constructed URL.
                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    // Ensure the HTTP response was successful (status code 200-299).
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string.  This is the JSON data.
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    return ExtractProduct(jsonResult); // Return the JSON string.
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request errors (e.g., network issues, server errors).
                    Console.WriteLine($"Error: HTTP request failed.  Details: {ex.Message}");
                    return null; // Return null to indicate failure.  Consider logging the error.
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., invalid URL, JSON parsing issues - though ReadAsStringAsync shouldn't throw).
                    Console.WriteLine($"Error: An unexpected error occurred. Details: {ex.Message}");
                    return null; // Return null to indicate failure.  Consider logging the error.
                }
            }
        }

        public static Product? ExtractProduct(string jsonString)
        {
            try
            {
                using (JsonDocument document = JsonDocument.Parse(jsonString))
                {
                    if (document.RootElement.TryGetProperty("product", out JsonElement productElement) && productElement.ValueKind == JsonValueKind.Object)
                    {
                        var product = new Product
                        {
                            Brand = productElement.TryGetProperty("brands", out JsonElement brandElement) ? brandElement.GetString() : null,
                            Name = productElement.TryGetProperty("product_name", out JsonElement nameElement) ? nameElement.GetString() : null
                        };

                        if (productElement.TryGetProperty("nutriments", out JsonElement nutrimentsElement) && nutrimentsElement.ValueKind == JsonValueKind.Object)
                        {
                            var nutritions = new Nutritions();
                            var nutristring = nutrimentsElement.ToString();
                            product.Nutritions = JsonSerializer.Deserialize<Nutritions>(nutristring);
                        }

                        return product;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }
        public static List<Product>? ExtractProducts(string jsonString)
        {
            var productsList = new List<Product>();

            try
            {
                using (JsonDocument document = JsonDocument.Parse(jsonString))
                {
                    if (document.RootElement.TryGetProperty("products", out JsonElement productsElement) && productsElement.ValueKind == JsonValueKind.Array)
                    {
                        foreach (JsonElement productElement in productsElement.EnumerateArray())
                        {
                            var product = new Product
                            {
                                Brand = productElement.TryGetProperty("brands", out JsonElement brandElement) ? brandElement.GetString() : null,
                                Name = productElement.TryGetProperty("product_name", out JsonElement nameElement) ? nameElement.GetString() : null
                            };

                            if (productElement.TryGetProperty("nutriments", out JsonElement nutrimentsElement) && nutrimentsElement.ValueKind == JsonValueKind.Object)
                            {
                                var nutritions = new Nutritions();
                                var nutristring = nutrimentsElement.ToString();
                                product.Nutritions = JsonSerializer.Deserialize<Nutritions>(nutristring);
                            }

                            productsList.Add(product);
                        }
                    }
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
                // Handle the exception as needed
                return null;
            }

            return productsList;
        }
    }
}
