using Extensions;
using System.Dynamic;

namespace The_Robot_Factory {
    internal class Program {
        static void Main() {
            List<dynamic> robots = new();

            while (true) {
                ConsoleExtensions.WriteLineColor($"You are producing robot #{robots.Count+1}:", ConsoleColor.Green);
                dynamic robot = new ExpandoObject();
                robot.ID = Guid.NewGuid();

                Console.WriteLine($"ID: {robot.ID}");

                if (ConsoleExtensions.AskForConfirmation("Do you want to name this robot?")) {
                    Console.Write("What's the name?: ");

                    robot.Name = Console.ReadLine();
                }

                if (ConsoleExtensions.AskForConfirmation("Does this robot have a specific size?")) {
                    robot.Height = ConsoleExtensions.GetInt("What is its height?: ");
                    robot.Width = ConsoleExtensions.GetInt("What is its width?: ");
                }

                if (ConsoleExtensions.AskForConfirmation("Does this robot need to be a specific color?")) {
                    Console.Write("What's the color?: ");
                    robot.Color = Console.ReadLine();
                }

                robots.Add(robot);

                Console.WriteLine("\n=====\nResult:");
                foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
                    Console.WriteLine($"{property.Key}: {property.Value}");

                Console.WriteLine("=====\n");
            }
        }
    }
}