using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IKindergartenServices
    {
        Task<KindergartenDto> Create(KindergartenDto dto);
        Task<IEnumerable<Kindergarten>> GetAllKinderGartens();
        Task<KindergartenDto> DetailAsync(Guid id);
    }
}
