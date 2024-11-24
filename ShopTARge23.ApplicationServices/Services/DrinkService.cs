using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Nancy.Json;
using Newtonsoft.Json;
using ShopTARge23.Core.Dto.Drink;
using ShopTARge23.Core.Dto.WeatherDtos.AccuWeatherDto;
using ShopTARge23.Core.Dto.WeatherDtos.AccuWeatherDtos;
using ShopTARge23.Core.ServiceInterface;

namespace ShopTARge23.ApplicationServices.Services
{
    public class DrinkService : IDrinkServices
    {
        public async Task<DrinkResultDto> DrinkResult(DrinkResultDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.strDrink))
            {
                return new DrinkResultDto
                {
                    strDrink = null,
                    strInstructions = "No drink name provided."
                };
            }

            string url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={dto.strDrink}";

            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(url);
                var drinkRoot = JsonConvert.DeserializeObject<DrinkRootDto>(json);

                if (drinkRoot == null || drinkRoot.Drinks == null || drinkRoot.Drinks.Count == 0)
                {
                    return new DrinkResultDto
                    {
                        strDrink = dto.strDrink,
                        strInstructions = "No drink found with this name."
                    };
                }

                var firstDrink = drinkRoot.Drinks[0];
                var drinkResult = new DrinkResultDto
                {
                    idDrink = firstDrink.idDrink,
                    strDrink = firstDrink.strDrink,
                    strCategory = firstDrink.strCategory,
                    strAlcoholic = firstDrink.strAlcoholic,
                    strGlass = firstDrink.strGlass,
                    strInstructions = firstDrink.strInstructions,
                    strDrinkThumb = firstDrink.strDrinkThumb
                };

                // Populate the Ingredients list
                var ingredients = new List<string>();

                if (!string.IsNullOrEmpty(firstDrink.strIngredient1)) ingredients.Add(firstDrink.strIngredient1);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient2)) ingredients.Add(firstDrink.strIngredient2);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient3)) ingredients.Add(firstDrink.strIngredient3);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient4)) ingredients.Add(firstDrink.strIngredient4);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient5)) ingredients.Add(firstDrink.strIngredient5);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient6)) ingredients.Add(firstDrink.strIngredient6);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient7)) ingredients.Add(firstDrink.strIngredient7);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient8)) ingredients.Add(firstDrink.strIngredient8);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient9)) ingredients.Add(firstDrink.strIngredient9);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient10)) ingredients.Add(firstDrink.strIngredient10);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient11)) ingredients.Add(firstDrink.strIngredient11);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient12)) ingredients.Add(firstDrink.strIngredient12);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient13)) ingredients.Add(firstDrink.strIngredient13);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient14)) ingredients.Add(firstDrink.strIngredient14);
                if (!string.IsNullOrEmpty(firstDrink.strIngredient15)) ingredients.Add(firstDrink.strIngredient15);

                // Assign the list to the Ingredients property
                drinkResult.Ingredients = ingredients;

                return drinkResult;
            }
        }
    }
}