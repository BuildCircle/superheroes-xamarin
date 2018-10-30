using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Superheroes
{
    internal class CharacterService : ICharacterService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        async Task<IEnumerable<Character>> ICharacterService.GetCharacters()
        {
            const string url = "https://s3.eu-west-2.amazonaws.com/build-circle/characters.json";

            string response = await _httpClient.GetStringAsync(url);
            CharacterResponse characterResponse = JsonConvert.DeserializeObject<CharacterResponse>(response);

            return characterResponse.Items;
        }
    }
}