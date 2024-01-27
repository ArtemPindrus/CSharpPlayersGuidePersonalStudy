namespace PlayersGuide {
    internal class Program {
        static void Main() {
            TicTacToeGame game = new();
            game.StartRound();
            game.StartRound();
            game.StartRound();

            Console.Clear();
            Console.WriteLine($"Results:\nX wins: {game.XWins}\nO wins: {game.OWins}");
        }
    }

    class TicTacToeGame {
        public enum GameObject { Empty, X, O }
        public int XWins { get; private set; }
        public int OWins { get; private set; }

        private readonly Dictionary<char, (int, int)> inputPositionMapping = new() {
            ['7'] = (0, 0), ['8'] = (0,1), ['9'] = (0,2),
            ['4'] = (1, 0), ['5'] = (1, 1), ['6'] = (1, 2),
            ['1'] = (2, 0), ['2'] = (2, 1), ['3'] = (2, 2),
        };

        public void StartRound() { 
            GameObject[,] gameBoard = new GameObject[3,3];

            //player makes choice. X first then Y
            int i = 0;
            GameObject winner;
            while (!EvaluateTheWinner(out winner)) {
                if (BoardIsFull()) break; 

                GameObject currentTurnObj;
                if (i % 2 == 0) currentTurnObj = GameObject.X;
                else currentTurnObj = GameObject.O;

                Console.WriteLine($"It's {currentTurnObj}'s turn:");
                DisplayGameBoard();
                Console.Write($"Enter your position on a numpad:");
                MakeChoice(currentTurnObj);

                Console.Clear();
                i++;
            }
            if (winner != GameObject.Empty) {
                Console.WriteLine($"Congrats, {winner}, you have won!\nThe final board:");
                DisplayGameBoard();
                if (winner == GameObject.X) XWins++;
                else if (winner == GameObject.O) OWins++;
            } else {
                Console.WriteLine("Tie!");
            }


            //funcs
            void MakeChoice(GameObject objectToPlace) {
                while (true) {
                    char inputPosition = Console.ReadKey(true).KeyChar;
                    if (inputPositionMapping.ContainsKey(inputPosition)) {
                        (int, int) position = inputPositionMapping[inputPosition];
                        if (gameBoard[position.Item1, position.Item2] == GameObject.Empty) {
                            gameBoard[position.Item1, position.Item2] = objectToPlace;
                            break;
                        }
                    }
                }               
            }
            void DisplayGameBoard() {
                for (int r = 0; r < gameBoard.GetLength(0); r++) {
                    for (int c = 0; c < gameBoard.GetLength(1); c++) {
                        string gameObject = gameBoard[r, c].ToString();
                        if (gameObject.Equals("Empty")) gameObject = " ";

                        string line = $" {gameObject}";
                        if (c == 2) line += "\n";
                        else line += " |";

                        Console.Write(line);
                    }
                    if (r != gameBoard.GetLength(0)-1)Console.WriteLine("---+---+---");
                }
            }
            bool EvaluateTheWinner(out GameObject winner) {
                if (CheckForThreeInARow(GameObject.X)) {
                    winner = GameObject.X;
                    return true;
                } else if (CheckForThreeInARow(GameObject.O)) {
                    winner = GameObject.O;
                    return true;
                } else {
                    winner = GameObject.Empty;
                    return false;
                }


                //funcs
                bool CheckForThreeInARow(GameObject value) {
                    return CheckRightDirection() || CheckDownDirection() || CheckDiagonal((0, 0), (1, 1)) || CheckDiagonal((2,0), (-1,1));


                    //funcs
                    bool CheckRightDirection() {
                        for (int r = 0; r < gameBoard.GetLength(0); r++) {
                            int times = 0;
                            for (int c = 0; c < gameBoard.GetLength(1); c++) {
                                if (gameBoard[r, c] == value) times++;
                            }
                            if (times == 3) return true;
                        }
                        return false;
                    }
                    bool CheckDownDirection() {
                        for (int c = 0; c < gameBoard.GetLength(1); c++) {
                            int times = 0;
                            for (int r = 0; r < gameBoard.GetLength(0); r++) {
                                if (gameBoard[r, c] == value) times++;
                            }
                            if (times == 3) return true;
                        }
                        return false;
                    }
                    bool CheckDiagonal((int, int) startingPointRC, (int, int) deltaRC) {
                        int times = 0;
                        while (startingPointRC.Item2 < gameBoard.GetLength(1)) {
                            if (gameBoard[startingPointRC.Item1, startingPointRC.Item2] == value) times++;
                            else return false;
                            startingPointRC.Item1 += deltaRC.Item1;
                            startingPointRC.Item2 += deltaRC.Item2;
                        }
                        return times == 3;
                    }
                }
            }
            bool BoardIsFull() {
                int filled = 0;
                foreach (GameObject gameObject in gameBoard) {
                    if (gameObject != GameObject.Empty) filled++;
                    else return false;
                }
                return filled == 9;
            }
        }
    }
}