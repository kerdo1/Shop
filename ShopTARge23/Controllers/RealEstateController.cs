using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Models.RealEstates;
using ShopTARge23.Core.Dto;
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

        public IActionResult Create()
        {
            RealEstatesCreateUpdateViewModel realEstates = new();
            {
                return View("CreateUpdate", realEstates);


            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(RealEstatesCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Size = vm.Size,
                Location = vm.Location,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };

            var result = await _realEstateServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDetailsViewModel();
            
            vm.Id = realEstate.Id;
            vm.Size = realEstate.Size;
            vm.Location = realEstate.Location;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.BuildingType = realEstate.BuildingType;
            vm.CreatedAt = realEstate.CreatedAt;

            return View(vm);
        }
    }
}