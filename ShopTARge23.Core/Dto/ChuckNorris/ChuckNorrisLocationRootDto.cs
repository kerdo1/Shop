using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge23.Core.Dto.ChuckNorris
{
    public class ChuckNorrisLocationRootDto
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Root
        {
            [JsonPropertyName("categories")]
            public List<object> categories { get; set; }

            [JsonPropertyName("created_at")]
            public string created_at { get; set; }

            [JsonPropertyName("icon_url")]
            public string icon_url { get; set; }

            [JsonPropertyName("id")]
            public string id { get; set; }

            [JsonPropertyName("updated_at")]
            public string updated_at { get; set; }

            [JsonPropertyName("url")]
            public string url { get; set; }

            [JsonPropertyName("value")]
            public string value { get; set; }
        }
    }
}
