using System;
namespace DesignPatternsInCSharp.Adapter.ResultWrapper
{
    public class CharacterToPersonAdapter : Person
    {
        private readonly Character _character;

        public CharacterToPersonAdapter(Character character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public override string Name
        {
            get => _character.FullName;
            set => _character.FullName = value;
        }

        public override string HairColor
        {
            get => _character.Hair;
            set => _character.Hair = value;
        }
    }
}
