using ShopTARge23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Core.Domain;
using Microsoft.EntityFrameworkCore;
using ShopTARge23.Core.Dto;

namespace ShopTARge23.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly ShopTARge23Context _context;

        public RealEstateServices(ShopTARge23Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RealEstate>> GetAllRealEstates()
        {
            return await _context.RealEstates.ToListAsync();
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new();

            realEstate.Id = Guid.NewGuid();
            realEstate.Size = dto.Size;
            realEstate.Location = dto.Location;
            realEstate.RoomNumber    = dto.RoomNumber;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }

        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
