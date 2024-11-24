using ShopTARge23.Core.Dto.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IGameService
    {
        Task<List<GameRootDto>> GetGamesAsync();
    }
}
