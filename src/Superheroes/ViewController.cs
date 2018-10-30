using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyIoC;
using UIKit;

namespace Superheroes
{
    public partial class ViewController : UIViewController
    {
        private ICharacterService _characterService => TinyIoCContainer.Current.Resolve<ICharacterService>();

        private CharacterPickerViewModel _heroPickerViewModel;
        private CharacterPickerViewModel _villainPickerViewModel;

        protected ViewController(IntPtr handle) 
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _heroPickerViewModel = new CharacterPickerViewModel();
            HeroPicker.Model = _heroPickerViewModel;

            _villainPickerViewModel = new CharacterPickerViewModel();
            VillainPicker.Model = _villainPickerViewModel;

            Task.Run(PopulateCharacters);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            SubmitButton.TouchDown += OnSubmitButtonTapped;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            SubmitButton.TouchDown -= OnSubmitButtonTapped;
        }

        private void OnSubmitButtonTapped(object sender, EventArgs e)
        {
            Character selectedHero = _heroPickerViewModel.SelectedCharacter;
            Character selectedVillain = _villainPickerViewModel.SelectedCharacter;

            if (selectedHero == null || selectedVillain == null)
            {
                return;
            }

            decimal heroScore = selectedHero.Score;
            decimal villainScore = selectedVillain.Score;

            string resultString = heroScore == villainScore ? 
                "Draw" : 
                $"{(heroScore > villainScore ? selectedHero.Name : selectedVillain.Name)} wins";

            ResultLabel.Text = resultString;
        }

        private async Task PopulateCharacters() 
        {
            IEnumerable<Character> allCharacters = await _characterService.GetCharacters();

            _heroPickerViewModel.Characters = allCharacters.Where(character => character.Type == CharacterType.Hero).ToList();
            _villainPickerViewModel.Characters = allCharacters.Where(character => character.Type == CharacterType.Villain).ToList();

            InvokeOnMainThread(() =>
            {
                HeroPicker.ReloadAllComponents();
                VillainPicker.ReloadAllComponents();
            });
        }
    }
}