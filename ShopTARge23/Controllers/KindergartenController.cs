using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Data;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.Kindergartens;
using ShopTARge23.Core.Dto;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Models.Spaceships;
using Microsoft.EntityFrameworkCore;
namespace ShopTARge23.Controllers
{
    public class KindergartenController : Controller
    {
        private readonly ShopTARge23Context _context;
        private readonly IKindergartenServices _kindergartenServices;

        public KindergartenController
            (
                ShopTARge23Context context,
                IKindergartenServices kindergartenServices
            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
        }

        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .Select(x => new KindergartenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    Teacher = x.Teacher,

                }).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            KindergartenCreateUpdateViewModel realEstates = new();
            {
                return View("CreateUpdate", realEstates);


            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _kindergartenServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return View("Error");
            }



            var vm = new KindergartenDetailsViewModel
            {
                Id = kindergarten.Id,
                GroupName = kindergarten.GroupName,
                ChildrenCount = kindergarten.ChildrenCount,
                KindergartenName = kindergarten.KindergartenName,
                Teacher = kindergarten.Teacher,
                CreatedAt = kindergarten.CreatedAt,
                UpdatedAt = kindergarten.UpdatedAt
            };

            return View(vm);
        }


        /* [HttpGet]
         public async Task<IActionResult> Update(Guid id)
         {
             var kindergarten = await _kindergartenServices.DetailAsync(id);
             if (kindergarten == null)
             {
                 return NotFound();
             }

             var vm = new KindergartenCreateUpdateViewModel
             {
                 Id = kindergarten.Id,
                 GroupName = kindergarten.GroupName,
                 ChildrenCount = kindergarten.ChildrenCount,
                 KindergartenName = kindergarten.KindergartenName,
                 Teacher = kindergarten.Teacher,
                 CreatedAt = kindergarten.CreatedAt,
                 UpdatedAt = kindergarten.UpdatedAt
             };

             return View("CreateUpdate", vm);
         }*/
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KindergartenCreateUpdateViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,

            };

            var result = await _kindergartenServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
    }
}
