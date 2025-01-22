using final_project;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

public class ProductManager
{
    public List<Product> Products { get; private set; }

    public ProductManager()
    {
        Products = new List<Product>();
    }

    public void LoadProductsFromJson(string filePath)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException("JSON file not found!");

        string json = File.ReadAllText(filePath);
        var jsonObject = JObject.Parse(json);
        var productsArray = jsonObject["Products"];

        foreach (var productJson in productsArray)
        {
            string category = productJson["Category"]?.ToString();
            switch (category)
            {
                case "Digital":
                    Products.Add(productJson.ToObject<EBook>());
                    break;
                case "Physical":
                    if (productJson["Name"]?.ToString() == "Laptop")
                        Products.Add(productJson.ToObject<Laptop>());
                    else if (productJson["Name"]?.ToString() == "Headphones")
                        Products.Add(productJson.ToObject<Headphones>());
                    break;
                default:
                    Products.Add(productJson.ToObject<Product>());
                    break;
            }
        }
    }
}
