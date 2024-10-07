using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Models.RealEstates;
namespace ShopTARge23.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopTARge23Context _context;
        private readonly IRealEstateServices _realEstateServices;

        public RealEstateController
            (
                ShopTARge23Context context,
                IRealEstateServices realEstateServices
            )
        {
            _context = context;
            _realEstateServices = realEstateServices;
        }

        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Size = x.Size,
                    Location = x.Location,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,

                });
            return View(result);
        }
    }
}
