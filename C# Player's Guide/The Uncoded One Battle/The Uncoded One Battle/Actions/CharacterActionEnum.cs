namespace TheUncodedOneBattle.Actions {
    enum CharacterActionEnum { DoNothing, Attack, UseItem }

    public class CharacterActionHelper { 
        public static int ActionAmount { get; } = Enum.GetValues(typeof(CharacterActionEnum)).Length;
    }
}
