using ShopTARge23.Core.Dto.Drink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IDrinkServices
    {
        Task<DrinkResultDto> DrinkResult(DrinkResultDto drinkName);
    }
}
