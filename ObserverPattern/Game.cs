using System;
using System.Collections.Generic;
using System.Text;
using ObserverPattern.CommandPattern;
using ObserverPattern.Commands;
using ObserverPattern.GameMapComponents;

namespace ObserverPattern
{
    public class Game
    {
        bool isPlaying = true;
        ConsoleKeyInfo keyInput;
        string consoleInput;


        private int Turn;
        public World world;
        public static Snake Player;
        public BasicGuard Enemy;

        public Game()
        {
            Console.Title = "Watered Down Roguelike!";
            Turn = 0;

            world = new World();
            Player = new Snake();
            world.AddEntity(Player);

            //world.DisplayAllRooms();
            //Enemy = new BasicGuard(this, Player.);
            Run();
        }

        public void Run()
        {
            ShowHelp();
            InputLoop();
        }

        private void InputLoop()
        {
            world.DisplayRoom(Player);

            while (isPlaying)
            {
                Console.Write("Please enter a key: ");
                keyInput = Console.ReadKey();
                ICommand command = GetCommandFromKey(keyInput);

                switch (keyInput.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            isPlaying = false;
                            break;
                        }
                    case ConsoleKey.H:
                        {
                            ShowHelp();
                            break;
                        }
                }

                if (command != null && isPlaying)
                {
                    command.Execute(Player);
                    WorldUpdate();
                    Test();
                }

                Turn++;
            }
        }

        public void WorldUpdate()
        {
            Console.Clear();
            world.UpdateEntityTiles();
            //world.DisplayRoom(Player);
            //world.DisplayAllRooms();
        }

        private static ICommand GetCommandFromKey(ConsoleKeyInfo ki)
        {
            Command command = null;

            switch (ki.Key)
            {
                case ConsoleKey.W:
                    {
                        command = new MoveUpCommand();
                        break;
                    }
                case ConsoleKey.S:
                    {
                        command = new MoveDownCommand();
                        break;
                    }
                case ConsoleKey.D:
                    {
                        command = new MoveRightCommand();
                        break;
                    }
                case ConsoleKey.A:
                    {
                        command = new MoveLeftCommand();
                        // 
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Sorry I don't know that key! Press H for help");
                        break;
                    }

            }

            return command;
        }

        private void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to {Console.Title}! The controls are...\n" +
                "WASD to move\n" +
                "J to fire weapon\n" +
                "R to reload weapon\n" +
                "K to melee attack\n" +
                "N to Shift Movement Type Down (See movement details below)\n" +
                "M to Shift Movement Type Up (See movement details below)\n" +
                "H to show this help text again\n" +
                "ESC to leave the game\n\n" +
                "Movement Details: " +
                "Press [Enter] to dismiss this message and continue.");
            Console.ReadLine();
            Console.Clear();
        }

        private void Test()
        {
            Console.WriteLine($"Player Location: {Player.location.ToTestString()}");
            Console.WriteLine($"Player's Last L:{Player.lastLocation.ToTestString()}");
        }
    }
}
