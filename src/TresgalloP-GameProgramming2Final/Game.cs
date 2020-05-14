using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using TresgalloP_GameProgramming2Final.GameLib;
using TresgalloP_GameProgramming2Final.CommandPattern;
using TresgalloP_GameProgramming2Final.CommandPattern.Commands;
using TresgalloP_GameProgramming2Final.CharacterInfo;
using TresgalloP_GameProgramming2Final.Weapons;

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
        public Guard[] enemies;
        public static Random random;

        public Game()
        {
            Console.Title = "Watered Down Roguelike!";
            Turn = 0;

            random = new Random();
            world = new World();
            player = new Player();
            enemies = new Guard[30];
            world.AddPlayer(ref player);
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Guard();
                world.AddEnemy(enemies[i]);
            }
            M1911 startingSidearm = new M1911();
            AK47 startingPrimary = new AK47();
            //RPG startingHeavy = new RPG();

            //player.PickUpWeapon(startingHeavy);
            player.PickUpWeapon(startingPrimary);
            player.PickUpWeapon(startingSidearm);

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
            world.DisplayRoom();// ref player);
            player.ShowStats();

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
                    case ConsoleKey.M:
                        {
                            Console.Clear();
                            world.DisplayAllRooms();
                            break;
                        }
                }

                if (command != null && isPlaying)
                {
                    command.Execute(player);
                    if(command is FireCommand && player.landHit)
                    {
                        world.CheckShotTrajectory(player, player.direction);
                    }
                    WorldUpdate();
                    Console.WriteLine(player.ShowStats());
                    player.ResetForNextTurn();

                    Turn++;
                    //Test();
                }

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
                        break;
                    }
                //case ConsoleKey.NumPad1:
                case ConsoleKey.NumPad2:
                //case ConsoleKey.NumPad3:
                case ConsoleKey.NumPad4:
                case ConsoleKey.NumPad6:
                //case ConsoleKey.NumPad7:
                case ConsoleKey.NumPad8:
                //case ConsoleKey.NumPad9:
                    {
                        int fireDir = (int)ki.KeyChar;//(Char.GetNumericValue(ki.KeyChar));
                        command = new FireCommand((ushort)(fireDir - 48));
                        break;
                    }
                case ConsoleKey.R:
                    {
                        command = new ReloadCommand();
                        break;
                    }
                case ConsoleKey.U:
                    {
                        command = new SwitchWeaponLCommand();
                        break;
                    }
                case ConsoleKey.I:
                    {
                        command = new SwitchWeaponRCommand();
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
                "numpad2, numpad4, numpad6, numpad8 to fire weapon\n" +
                "R to reload weapon\n" +
                "U or I to switch weapons\n" +
                //"K to melee attack\n" +
                "M to open World Map\n" +
                //"N to Shift Movement Type Down (See movement details below)\n" +
                //"M to Shift Movement Type Up (See movement details below)\n" +
                "H to show this help text again\n" +
                "ESC to leave the game\n\n" +
                "The objective of the game is to make it to the GOAL (Green 'G' in the map)\n" +
                "There are enemies along the way! Thanks to modern *cough* *cough* technology: ammo is universal!\n\n" +
                "What do symbols mean? I'm glad you totally asked!\n" +
                "The player appears as '@'\n" +
                "Enemies appear as numbers (0-9) based on how much health they have\n" +
                "Terrain has a variety of symbols:\n" +
                "'.' = Floor\n" +
                "'X' = Wall\n" +
                "'C' = Full cover\n" +
                "'c' = Light cover\n" +
                "'B' = Door (Continue walking in the direction of the door to \"Go through\" to the next room)\n" +
                "'G' = Goal\n" +
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
