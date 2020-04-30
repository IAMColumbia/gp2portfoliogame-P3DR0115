using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.GameLib;
using TresgalloP_GameProgramming2Final.CommandPattern;
using TresgalloP_GameProgramming2Final.CommandPattern.Commands;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final
{
    public class Game
    {
        public static bool isPlaying = true;
        public static bool winCondition = false;
        public static CommandWUndo command = null;
        ConsoleKeyInfo keyInput;
        string consoleInput;


        private int Turn;
        public World world;
        public static Player player;
        //public BasicGuard Enemy;

        public Game()
        {
            Console.Title = "Watered Down Roguelike!";
            Turn = 0;

            world = new World();
            player = new Player();
            world.AddPlayer(ref player);

            //world.DisplayAllRooms();
            //Enemy = new BasicGuard(this, Player.);
            Run();
        }

        public void Run()
        {
            ShowHelp();
            world.DisplayAllRooms();
            InputLoop();
        }

        private void InputLoop()
        {
            world.DisplayRoom();// ref player);

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
                    command.Execute(player);
                    WorldUpdate();
                    Console.WriteLine(player.ShowStats());
                    //Test();
                }

                Turn++;
            }

            if(winCondition)
            {
                Console.WriteLine("YOU WIN! You reached the goal!");
            }
        }

        public void WorldUpdate()
        {
            Console.Clear();
            world.UpdateEntityTiles();
            world.DisplayRoom();// ref player);
            //world.DisplayAllRooms();
        }

        private static ICommand GetCommandFromKey(ConsoleKeyInfo ki)
        {
            command = null;
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
                //"N to Shift Movement Type Down (See movement details below)\n" +
                //"M to Shift Movement Type Up (See movement details below)\n" +
                "H to show this help text again\n" +
                "ESC to leave the game\n\n" +
                //"Movement Details: " +
                "Press [Enter] to dismiss this message and continue.");
            Console.ReadLine();
            Console.Clear();
        }

        private void Test()
        {
            Console.WriteLine($"Player Location: {player.locationInfo.location.ToTestString()}");
            Console.WriteLine($"Player's Last L: {player.locationInfo.lastLocation.ToTestString()}");
        }
    }
}
