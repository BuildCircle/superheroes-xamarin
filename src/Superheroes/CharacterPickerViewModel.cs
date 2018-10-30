using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace Superheroes
{
    public class CharacterPickerViewModel : UIPickerViewModel
    {
        private Character _selectedCharacter;

        public IList<Character> Characters { get; set; }

        public Character SelectedCharacter => _selectedCharacter ?? Characters?.FirstOrDefault();

        public override string GetTitle(UIPickerView pickerView, nint row, nint component) => Characters[(int)row].Name;

        public override nint GetComponentCount(UIPickerView pickerView) => 1;

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component) => Characters?.Count ?? 0;

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            _selectedCharacter = Characters[(int)row];
        }
    }
}
