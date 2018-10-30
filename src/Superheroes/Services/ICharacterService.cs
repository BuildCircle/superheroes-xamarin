using System.Collections.Generic;
using System.Threading.Tasks;

namespace Superheroes
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetCharacters();
    }
}