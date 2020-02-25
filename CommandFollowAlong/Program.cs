using System;
using CommandFollowAlong.Commands;
using CommandFollowAlong.CommandPattern;

namespace CommandFollowAlong
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;

            GameComponent fakeComponentReceiver = new GameComponent();
            while(isPlaying)
            {
                // our game
                Console.Write("Please enter a key: ");
                ConsoleKeyInfo keyI = Console.ReadKey();//AskForCommand();
                ICommand command = GetCommandFromKey(keyI);

                if(command != null)
                {
                    command.Execute(fakeComponentReceiver);
                }
                else
                {
                    Console.WriteLine("Sorry, I don't know that command");
                }

                switch(keyI.Key)
                {
                    case ConsoleKey.Escape:
                    case ConsoleKey.Q:
                        {
                            isPlaying = false;
                            break;
                        }
                }
                //Movement(fakeComponentReceiver, keyI);
                Console.WriteLine($"(x: {fakeComponentReceiver.X}, y: {fakeComponentReceiver.Y}, z: {fakeComponentReceiver.Z}), Crouched: {fakeComponentReceiver.Crouching}");

            }

            Console.ReadLine();
        }
        private static ICommand GetCommandFromKey(ConsoleKeyInfo ki)
        {
            Command command = null;

            switch (ki.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        command = new MoveUpCommand();
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        command = new MoveDownCommand();
                        break;
                    }
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        command = new MoveRightCommand();
                        break;
                    }
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        command = new MoveLeftCommand();
                        // 
                        break;
                    }
                case ConsoleKey.Z:
                    {
                        command = new MoveDownstairsCommand();
                        break;
                    }
                case ConsoleKey.X:
                    {
                        command = new MoveUpstairsCommand();
                        break;
                    }
                case ConsoleKey.C:
                    {
                        command = new MoveToggleCrouchCommand();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Sorry I don't know that key!");
                        break;
                    }

            }

            return command;
        }
        private static void Movement(GameComponent fakeComponentReceiver, ConsoleKeyInfo keyI)
        {
            switch (keyI.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        fakeComponentReceiver.MoveUp();
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        fakeComponentReceiver.MoveDown();
                        break;
                    }
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        fakeComponentReceiver.MoveRight();
                        break;
                    }
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        fakeComponentReceiver.MoveLeft();
                        // 
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Sorry I don't know that key!");
                        break;
                    }
            }
        }
    }
}
