namespace The_Fountain_of_Objects {
    public class GameObject {
        public Vector2 Position { get; private set; }

        public GameObject(Vector2 position) { 
            Position = position;
        }

        public void Translate(Vector2 displacement) { 
            Position += displacement;
        }
    }

    public class Fountain : GameObject {
        public bool IsActivated { get; private set; }

        public Fountain(Vector2 position, bool initialState) : base(position) {
            IsActivated = initialState;
        }

        public void Activate() => IsActivated = true;
        public void Deactivate() => IsActivated = false;
    }

    public class Player : GameObject {
        public Player(Vector2 position) : base(position) { }
    }
}