using TheUncodedOneBattle.Characters.Items;
using TheUncodedOneBattle.Characters;

namespace TheUncodedOneBattle.Players
{
    internal class Player {
        public Game? AttachedGame { get; private set; }

        public virtual void PickAction(Character character) {
            throw new NotSupportedException();
        }

        public virtual Character PickAttackTarget() { 
            throw new NotSupportedException();
        }

        public virtual Item PickItem() { 
            throw new NotSupportedException();
        }

        public void AttachToGame(Game game) => AttachedGame = game;
    }
}
