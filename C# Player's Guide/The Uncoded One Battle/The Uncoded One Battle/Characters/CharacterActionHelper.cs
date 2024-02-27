namespace TheUncodedOneBattle.Characters {
    internal class CharacterActionHelper {
        internal static int NumberOfValues;

        static CharacterActionHelper() { 
            NumberOfValues = Enum.GetValues(typeof(CharacterAction)).Length;
        }
    }
}