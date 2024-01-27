namespace PlayersGuide {
    internal class Program {
        static void Main() {
            Console.Write("Enter the starting numeric code for the door: ");
            int startingPassword = GetIntValueFromUser("Wrong numeric code, use only numbers: ");

            Console.Write(@"Choose the starting state of the door:
1. Locked
2. Closed
3. Opened
Enter corresponding number: ");
            int startingState = GetIntValueFromUserInRange(1,3,"Error. Enter the number corresponding to your choice: ");

            Door myDoor = new(startingPassword, (Door.State) startingState-1);

            Console.Clear();
            while (true) {
                Console.Write(@$"Current door's state: {myDoor.DoorState}
1. Lock
2. Unlock
3. Close
4. Open
5. Change the door's numeric code
Choose the action by the number:");

                int choice = GetIntValueFromUserInRange(1,5, "Error. Enter the number corresponding to your choice: ");

                switch (choice) {
                    case 1:
                        myDoor.Lock();
                        break;
                    case 2:
                        Console.Write("Enter door's numeric code: ");
                        int enteredPassword = GetIntValueFromUser();

                        myDoor.Unlock(enteredPassword);
                        break;
                    case 3:
                        myDoor.Close();
                        break;
                    case 4:
                        myDoor.Open();
                        break;
                    case 5:
                        Console.Write("To change the password please enter current password: ");
                        int currentPassword = GetIntValueFromUser();

                        Console.Write("Enter new password: ");
                        int newPassword = GetIntValueFromUser();

                        myDoor.ChangePassword(currentPassword, newPassword);
                        break;
                }

                Console.WriteLine();
            }
        }

        static private int GetIntValueFromUser(string errorPrompt = "Error. Enter only numbers: ") {
            int value ;
            while (!int.TryParse(Console.ReadLine(), out value)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(errorPrompt);
                Console.ForegroundColor = ConsoleColor.White;
            }

            return value;
        }

        static private int GetIntValueFromUserInRange(int min, int max, string errorPrompt) {
            int value;

            while (!int.TryParse(Console.ReadLine(), out value) || (value < min || value > max)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(errorPrompt);
                Console.ForegroundColor = ConsoleColor.White;
            }

            return value;
        }
    }

    internal class Door {
        private int numericCode;
        internal enum State { Locked, Closed, Opened }
        internal State DoorState { get; private set; }

        public Door(int numericCode, State initialDoorState) { 
            this.numericCode = numericCode;
            DoorState = initialDoorState;
        }

        public void Open() {
            if (DoorState == State.Closed) {
                DoorState = State.Opened;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Door is opened now!");
                Console.ForegroundColor = ConsoleColor.White;
            } else if (DoorState == State.Locked) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The door is locked! Unlock it first.");
                Console.ForegroundColor = ConsoleColor.White;
            } else if (DoorState == State.Opened) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The door is already opened.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Lock() {
            if (DoorState == State.Closed) {
                DoorState = State.Locked;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Door is locked now!");
                Console.ForegroundColor = ConsoleColor.White;
            } else if (DoorState == State.Locked) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The door is already locked!");
                Console.ForegroundColor = ConsoleColor.White;
            } else if (DoorState == State.Opened) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The door is opened! Close it first.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Close() {
            if (DoorState == State.Closed) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The door is already closed.");
                Console.ForegroundColor = ConsoleColor.White;
            } else if (DoorState == State.Locked) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The door is already closed and locked!");
                Console.ForegroundColor = ConsoleColor.White;
            } else if (DoorState == State.Opened) {
                DoorState = State.Closed;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The door is closed now!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Unlock(int numericCode) {
            if (DoorState == State.Closed) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The door is already unlocked but closed.");
                Console.ForegroundColor = ConsoleColor.White;
            } else if (DoorState == State.Locked) {
                if (numericCode == this.numericCode) {
                    DoorState = State.Closed;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The door is unlocked now but closed.");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The numeric code is wrong!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } else if (DoorState == State.Opened) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The door isn't locked!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ChangePassword(int currentNumericCode, int newNumericCode) {
            if (currentNumericCode == numericCode) {
                numericCode = newNumericCode;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Password has been changed");
                Console.ForegroundColor = ConsoleColor.White;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong current numeric code has been entered!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}