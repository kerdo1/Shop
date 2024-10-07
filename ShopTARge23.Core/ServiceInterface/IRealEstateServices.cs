using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IRealEstateServices
    {
        
        Task<IEnumerable<RealEstate>> GetAllRealEstates();
        Task<RealEstate> Create(RealEstateDto dto);
        Task<RealEstate> GetAsync(Guid id);
    }
}
