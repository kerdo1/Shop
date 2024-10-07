using ShopTARge23.Core.Domain;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace ShopTARge23.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopTARge23Context _context;

        public KindergartenServices
            (
                ShopTARge23Context context
            )
        {
            _context = context;
        }
        public async Task<IEnumerable<Kindergarten>> GetAllKinderGartens()
        {
            return await _context.Kindergartens.ToListAsync();
        }
    }
}
