namespace The_Old_Robot {
    internal class Program {
        static void Main() {
            List<IRobotCommand> commands = new();

            Console.WriteLine(@"Available commands:
1. Turn on
2. Turn off
3. Move north
4. Move south
5. Move west
6. Move east
7. Run
");


            string? response = string.Empty;
            while (!response.Equals("7")) {
                Console.Write($"Enter your choice for the {commands.Count + 1} command: ");
                response = Console.ReadLine() ?? string.Empty;
                if (response.Equals("7")) break;

                IRobotCommand? command = response switch {
                    "1" => new OnCommand(),
                    "2" => new OffCommand(),
                    "3" => new NorthCommand(),
                    "4" => new SouthCommand(),
                    "5" => new WestCommand(),
                    "6" => new EastCommand(),
                    _ => null
                };

                if (command != null) commands.Add(command);
                else { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong command!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Vector2 position = new(0, 0);
            Robot robot = new(position, false, commands.ToArray());
        }
    }

    public class Robot {
        public Vector2 Position { get; private set; }
        public bool IsPowered { get; private set; }

        public Robot(Vector2 position, bool isPowered, IRobotCommand[]? startingCommands = null) {
            Position = position;
            IsPowered = isPowered;

            if (startingCommands != null) Run(startingCommands);
        }

        public void Run(IRobotCommand[] commands) {

            for (int i = 0; i < commands.Length; i++) {
                if (!commands[i].Run(this)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Command {i + 1} was unsuccesful (robot not powered)");
                }

                Console.WriteLine($"[{Position.X} {Position.Y} {IsPowered}]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Activate() => IsPowered = true;
        public void Deactivate() => IsPowered = false;

        public void Move(Vector2 delta) => Position += delta;
    }

    public record Vector2(int X, int Y) {
        public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X+b.X, a.Y+b.Y);
    }

    public interface IRobotCommand {
        bool Run(Robot robot);
    }

    public class OnCommand : IRobotCommand {
        public bool Run(Robot robot) {
            robot.Activate();
            return true;
        }
    }

    public class OffCommand : IRobotCommand {
        public bool Run(Robot robot) {
            robot.Deactivate();
            return true;
        }
    }

    public class NorthCommand : IRobotCommand {
        public bool Run(Robot robot) {
            if (!robot.IsPowered) return false;

            robot.Move(new(0, 1));
            return true;
        }
    }

    public class SouthCommand : IRobotCommand {
        public bool Run(Robot robot) {
            if (!robot.IsPowered) return false;

            robot.Move(new(0, -1));
            return true;
        }
    }

    public class WestCommand : IRobotCommand {
        public bool Run(Robot robot) {
            if (!robot.IsPowered) return false;

            robot.Move(new(-1, 0));
            return true;
        }
    }

    public class EastCommand : IRobotCommand {
        public bool Run(Robot robot) {
            if (!robot.IsPowered) return false;

            robot.Move(new(1, 0));
            return true;
        }
    }
}