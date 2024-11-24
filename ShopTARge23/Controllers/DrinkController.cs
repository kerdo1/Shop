using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto.Drink;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.Drinks;

namespace ShopTARge23.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkServices _drinkServices;

        public DrinkController(IDrinkServices drinkServices)
        {
            _drinkServices = drinkServices;
        }

        public IActionResult Index()
        {
            var model = new DrinkIndexViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DrinkIndexViewModel model)
        {
            
                DrinkResultDto drinkDto = await _drinkServices.DrinkResult(new DrinkResultDto
                {
                    strDrink = model.DrinkName
                });

                if (string.IsNullOrEmpty(drinkDto.strDrink))
                {
                    ViewData["Error"] = "Drink not found!";
                    return View(model);  
                }

                model.Name = drinkDto.strDrink;
                model.ImageUrl = drinkDto.strDrinkThumb;
                model.Category = drinkDto.strCategory;
                model.Alcoholic = drinkDto.strAlcoholic;
                model.Glass = drinkDto.strGlass;
                model.Instructions = drinkDto.strInstructions;
                model.Ingredients = new List<string>();

                for (int i = 1; i <= 15; i++)
                {
                    var ingredient = typeof(DrinkResultDto).GetProperty($"strIngredient{i}")?.GetValue(drinkDto)?.ToString();
                    if (!string.IsNullOrEmpty(ingredient))
                    {
                        model.Ingredients.Add(ingredient);
                    }
                }

                return View(model);  
            }

           
        }

    }

