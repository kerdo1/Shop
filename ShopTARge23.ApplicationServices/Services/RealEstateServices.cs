using ShopTARge23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Core.Domain;
using Microsoft.EntityFrameworkCore;

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
    }
}
