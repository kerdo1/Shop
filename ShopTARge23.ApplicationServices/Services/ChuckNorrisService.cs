using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using ShopTARge23.Core.Dto.ChuckNorris;
using ShopTARge23.Core.ServiceInterface;

namespace ShopTARge23.ApplicationServices.Services
{
    public class ChuckNorrisService : IChuckNorrisServices
    {
        private const string ApiUrl = "https://api.chucknorris.io/jokes/random";

        public async Task<ChuckNorrisLocationResultDtos> GetRandomJoke()
        {
            using (var client = new HttpClient())
            {
                // Send the GET request to the Chuck Norris API
                var response = await client.GetStringAsync(ApiUrl);

                // Deserialize the response JSON into ChuckNorrisRootDto
                var jokeDto = JsonSerializer.Deserialize<ChuckNorrisRootDto>(response);

                // Map the relevant data from ChuckNorrisRootDto to ChuckNorrisLocationResultDtos
                var resultDto = new ChuckNorrisLocationResultDtos
                {
                    created_at = jokeDto.created_at,
                    icon_url = jokeDto.icon_url,
                    id = jokeDto.id,
                    updated_at = jokeDto.updated_at,
                    url = jokeDto.url,
                    value = jokeDto.value
                };

                // Return the resulting DTO
                return resultDto;
            }
        }
    }
}
