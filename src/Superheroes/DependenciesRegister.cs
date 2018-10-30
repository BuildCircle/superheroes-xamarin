using TinyIoC;

namespace Superheroes
{
    public static class DependenciesRegister
    {
        public static void Initialise()
        {
            TinyIoCContainer container = TinyIoCContainer.Current;
            container.Register<ICharacterService, CharacterService>();
        }
    }
}