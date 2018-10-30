using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Superheroes
{
    public class Character
    {
        public string Name { get; set; }

        public decimal Score { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CharacterType Type { get; set; }
    }
}
