namespace The_Fountain_of_Objects {
    public enum Size { Small, Medium, Large }

    public class FountainOfObjectsGame {
        private enum RoundState { None, Win, Pikes }


        private readonly Vector2 worldSize;


        private readonly Player player;
        private readonly GameObject entrance;
        private readonly Fountain fountain;
        private readonly GameObject[] spikes;


        private readonly ConsoleColor senseColor = ConsoleColor.Yellow;
        private readonly ConsoleColor warningColor = ConsoleColor.Red;


        private readonly DateTime startingTime;

        public FountainOfObjectsGame(Size worldSize, Vector2 entrancePosition, Vector2 fountainPosition, Vector2[] spikesPositions) {
            //change??
            Dictionary<Size, Vector2> worldSizeMapping_SizeSpikes = new() { //X - size, Y - spikes amount
                [Size.Small] = new(4,1),
                [Size.Medium] = new(6,2),
                [Size.Large] = new(8,3)
            };
            this.worldSize = new(worldSizeMapping_SizeSpikes[worldSize].X, worldSizeMapping_SizeSpikes[worldSize].X);
            spikes = new GameObject[worldSizeMapping_SizeSpikes[worldSize].Y];
            //

            if (PositionIsWithinWorldSize(entrancePosition)) {
                entrance = new(entrancePosition);
                player = new(entrancePosition);
            } else throw new Exception("entrance position was out of world's borders on create");
            if (PositionIsWithinWorldSize(fountainPosition)) fountain = new(fountainPosition, false);
            else throw new Exception("fountain position was out of world's borders on create");

            if (spikes.Length > spikesPositions.Distinct().Count()) throw new Exception("Not enough unique spike positions were provided!");
            for (int i = 0; i < spikes.Length; i++) {
                Vector2 position = spikesPositions[i];
                if (PositionIsWithinWorldSize(position)) {
                    if (position == player.Position || position == entrance.Position || position == fountain.Position) 
                        throw new Exception("spike was created at position of another object");
                    else spikes[i] = new GameObject(position);
                } else throw new Exception("spike position was out of world's borders on create");
            }

            WriteLineColor("Game's started!", ConsoleColor.Green);
            startingTime = DateTime.Now;

            RoundState roundState; 
            while(!RunGameLoop(out roundState));

            if (roundState == RoundState.Win) 
                WriteLineColor("The Fountain of Objects has been reactivated, and you have escaped with your life!", ConsoleColor.Green);
            else if (roundState == RoundState.Pikes) WriteLineColor("You have fallen into the pit! Hahaha", ConsoleColor.Red);

            DateTime finishedTime = DateTime.Now;
            TimeSpan timeSpent = finishedTime - startingTime;
            Console.WriteLine("Time spent: "+timeSpent);
        }

        private bool PositionIsWithinWorldSize(Vector2 position) => position.X < worldSize.X && position.X >= 0 && 
            position.Y < worldSize.Y && position.Y >= 0;

        /// <summary>
        /// Returns true if the game is finished (escaped/died)
        /// </summary>
        /// <returns></returns>
        private bool RunGameLoop(out RoundState roundState) {
            roundState = RoundState.None;

            Console.WriteLine($"----------------------------------------------------------------------------------\nYou are in the room at {player.Position}.");
            if (player.Position == entrance.Position) {
                if (!fountain.IsActivated) WriteLineColor("You see light coming from the cavern entrance.", senseColor);
                else {
                    roundState = RoundState.Win;
                    return true;
                }
            } else if (player.Position == fountain.Position) {
                if (!fountain.IsActivated) WriteLineColor("You hear water dripping in this room. The Fountain of Objects is here!", senseColor);
                else WriteLineColor("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", senseColor);
            }

            foreach (var spike in spikes) {
                if (player.Position == spike.Position) {
                    roundState = RoundState.Pikes;
                    return true;
                }

                if (player.Position.IsAdjacentTo(spike.Position)) WriteLineColor("You feel a draft. There is a pit in a nearby room.", warningColor);
            }

            Console.Write("What do you want to do? ");

            string? response = Console.ReadLine();

            bool couldntMove = false;
            switch (response) {
                case "move east":
                    couldntMove = !MovePlayer(new(1, 0));
                    break;
                case "move west":
                    couldntMove = !MovePlayer(new(-1, 0));
                    break;
                case "move north":
                    couldntMove = !MovePlayer(new(0, 1));
                    break;
                case "move south":
                    couldntMove = !MovePlayer(new(0, -1));
                    break;
                case "activate fountain":
                    if (!TryChangeFountainState(true)) WriteLineColor("There is no Fountain in this room!", warningColor);
                    break;
                case "deactivate fountain":
                    if (!TryChangeFountainState(false)) WriteLineColor("There is no Fountain in this room!", warningColor);
                    break;
            }

            if (couldntMove) WriteLineColor("A wall prevented the move.", warningColor);


            return false;
        }

        private bool MovePlayer(Vector2 delta) {
            if (PositionIsWithinWorldSize(player.Position + delta)) {
                player.Translate(delta);
                return true;
            } else return false;
        }

        private bool TryChangeFountainState(bool state) {
            if (player.Position == fountain.Position) {
                if (state) fountain.Activate();
                else fountain.Deactivate();

                return true;
            } else return false;
        }

        private static void WriteLineColor(string text, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}