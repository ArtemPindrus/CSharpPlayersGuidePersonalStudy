namespace PlayersGuide {
    internal class Program {
        static void Main() {
            GameOfFifteen game = new(4);
            game.StartGame();
        }
    }

    public class GameOfFifteen {
        private int moves = 0;
        private readonly string[,] gameGrid;

        private bool GameGridIsCompleted { 
            get {
                int previous = 0;

                foreach (var number in gameGrid) {
                    if (number == "X") continue;
                    if (int.Parse(number)-1 != previous) return false;
                    previous = int.Parse(number);
                }
                return true;
            } 
        }

        private enum MovementDirection { Left, Right, Up, Down }

        public GameOfFifteen(int numberOfRows) { 
            gameGrid = new string[numberOfRows,numberOfRows];

            Random random = new();
            int emptyCellRow = random.Next(numberOfRows); //TODO: turn into tuple
            int emptyCellColumn = random.Next(numberOfRows);

            List<int> availableNumbers = CreateAListOfAvailableNumbersInAGrid();

            for (int r = 0; r < numberOfRows; r++) {
                for (int c = 0; c < numberOfRows; c++) {
                    if (r == emptyCellRow && c == emptyCellColumn) {
                        gameGrid[r, c] = "X";
                        continue;
                    }

                    //change the default
                    int randomIndex = random.Next(availableNumbers.Count);
                    gameGrid[r,c] = availableNumbers[randomIndex].ToString();
                    availableNumbers.RemoveAt(randomIndex);
                }
            }
        }

        public void StartGame() {
            while (!GameGridIsCompleted) {
                Console.WriteLine("Push W,A,S,D to move cells");
                OutputGrid();
                Console.WriteLine($"Moves performed: {moves}");
                char choice = Char.ToLower(Console.ReadKey(true).KeyChar);

                switch (choice) {
                    case 'a':
                        MoveCells(MovementDirection.Left);
                        break;
                    case 'w':
                        MoveCells(MovementDirection.Up);
                        break;
                    case 's':
                        MoveCells(MovementDirection.Down);
                        break;
                    case 'd':
                        MoveCells(MovementDirection.Right);
                        break;
                }

                Console.Clear();
            }

            Win();
        }

        private void Win() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Congrats, you have won on a {gameGrid.GetLength(0)}x{gameGrid.GetLength(1)} grid!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void MoveCells(MovementDirection movementDirection) {
            int rDelta = 0;
            int cDelta = 0;

            if (movementDirection == MovementDirection.Left) cDelta = 1;
            if (movementDirection == MovementDirection.Right) cDelta = -1;
            if (movementDirection == MovementDirection.Up) rDelta = 1;
            if (movementDirection == MovementDirection.Down) rDelta = -1;

            Tuple<int, int> emptyCellIndeces = FindIndecesOfEmptyCell();

            try {
                string cellToMoveContent = gameGrid[emptyCellIndeces.Item1+rDelta, emptyCellIndeces.Item2 + cDelta];

                gameGrid[emptyCellIndeces.Item1, emptyCellIndeces.Item2] = cellToMoveContent; //change current X to content
                gameGrid[emptyCellIndeces.Item1 + rDelta, emptyCellIndeces.Item2 + cDelta] = "X"; //change content cell to X
                moves++;
            } catch (IndexOutOfRangeException) { } //cannot move left
        }

        private Tuple<int, int> FindIndecesOfEmptyCell() {
            for (int r = 0; r < gameGrid.GetLength(0); r++) {
                for (int c = 0; c < gameGrid.GetLength(1); c++) {
                    if (gameGrid[r, c] == "X") return Tuple.Create(r, c);
                }
            }
            return Tuple.Create(-1,-1);
        }

        private List<int> CreateAListOfAvailableNumbersInAGrid() {
            int maxNumberInAGrid = gameGrid.Length - 1;

            List<int> availableNumbers = new();
            for (int number = 1; number <= maxNumberInAGrid; number++) availableNumbers.Add(number);
            return availableNumbers;
        }

        private void OutputGrid() {
            for (int r = 0; r < gameGrid.GetLength(0); r++) {
                for (int c = 0; c < gameGrid.GetLength(1); c++) {
                    Console.Write($"{gameGrid[r, c],2} ");
                }
                Console.WriteLine();
            }
        }
    }
}