using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.GameLib
{
    public class Room
    {
        public int xDimension;
        public int yDimension;
        public Tile[,] tiles;// { get { return this.tiles; } private set { this.tiles = value; } }

        public Room(int xDimension = 10, int yDimension = 10)
        {
            this.xDimension = xDimension;
            this.yDimension = yDimension;

            GenerateRoom();
        }

        private void GenerateRoom()
        {
            tiles = new Tile[xDimension, yDimension];
            // Get edges
            Location loc = new Location(World.xCurrentGen, World.yCurrentGen, World.zCurrentGen);
            Location worldRef = new Location(World.xCurrentGen, World.yCurrentGen, World.zCurrentGen); ; // Save the "corner" coordinates.
            for (int i = 0; i < yDimension; i++)
            {

                loc.X = worldRef.X;
                //if(worldRef.X == 0)

                //if(loc.X != 0 && i != (int)(xDimension/2))
                tiles[0, i] = new Tile(loc, TileType.Wall);

                //if (
                //        (hor == (int)(xDimension / 2) && (ver == yDimension - 1)) ||
                //        (ver == (int)(yDimension / 2) && (hor == xDimension - 1))
                //        )
                //    tiles[hor, ver] = new Tile(loc, TileType.Door);

                //if(i == (int)(yDimension / 2) )
                //{
                //    tiles[0, i] = new Tile(loc, TileType.Door);
                //}

                //if (i == (int)(xDimension / 2) && (loc.Y == yDimension - 1))
                //    tiles[0, i] = new Tile(loc, TileType.Door);
                
                //else
                //    tiles[0, i] = new Tile(loc, TileType.Door);

                //if ((worldRef.X != 0 || (worldRef.X == 0 && loc.X != 0)) && (i != 5 || i != 6))
                //    tiles[0, i] = new Tile(loc, TileType.Wall);
                //else
                //    tiles[0, i] = new Tile(loc, TileType.Door);

                loc.X = worldRef.X + xDimension - 1;
                tiles[xDimension - 1, i] = new Tile(loc, TileType.Wall);

                if (i == (int)(yDimension / 2) && (worldRef.X != 0 || worldRef.X != 50))
                {
                    tiles[0, i] = new Tile(loc, TileType.Door);
                    tiles[xDimension - 1, i] = new Tile(loc, TileType.Door);
                }

                loc.Y++;
            }

            for (int i = 0; i < xDimension; i++)
            {
                loc.Y = worldRef.Y;
                //tiles[i, 0] = new Tile(loc, TileType.Wall);

                //if (loc.Y != 0 && i != (int)(yDimension / 2))
                tiles[i, 0] = new Tile(loc, TileType.Wall);
                //else
                //    tiles[i, 0] = new Tile(loc, TileType.Door);

                //if ((worldRef.Y != 0 || (worldRef.Y == 0 && loc.Y != 0)) && (i != 5 || i != 6))
                //    tiles[i, 0] = new Tile(loc, TileType.Wall);
                //else
                //    tiles[i, 0] = new Tile(loc, TileType.Door);

                loc.Y = worldRef.Y + yDimension - 1;
                tiles[i, yDimension - 1] = new Tile(loc, TileType.Wall);


                if (i == (int)(xDimension / 2))
                {
                    tiles[i, 0] = new Tile(loc, TileType.Door);
                    tiles[i, yDimension - 1] = new Tile(loc, TileType.Door);
                }

                loc.X++;
            }

            loc.X = worldRef.X + 1;
            loc.Y = worldRef.Y + 1;
            // Dimension-1 becauase the edges are already assigned.
            for (int ver = 1; ver < (yDimension - 1); ver++)
            {
                for (int hor = 1; hor < (xDimension - 1); hor++)
                {
                    tiles[hor, ver] = new Tile(loc, GetRandomTileType());

                    //if (
                    //        (hor == (int)(xDimension / 2) && (ver == yDimension - 1)) ||
                    //        (ver == (int)(yDimension / 2) && (hor == xDimension - 1))
                    //        )
                    //    tiles[hor, ver].tileType = TileType.Door;

                    loc.X++;
                }
                loc.Y++;
            }
        }

        private TileType GetRandomTileType()
        {
            TileType type = TileType.Floor;
            Random r = new Random();
            int n = r.Next(100);

            if (n < 70)
                type = TileType.Floor;
            else if (n < 85)
                type = TileType.LightCover;
            else if (n < 95)
                type = TileType.FullCover;
            else //if (n < 98)
                type = TileType.Wall;
            //else
            //    type = TileType.UpStairs;

            return type;
        }

        public void DisplayRoom(bool endline = false)
        {
            for (int ver = 0; ver < yDimension; ver++)
            {
                for (int hor = 0; hor < xDimension; hor++)
                {
                    ChooseColor(tiles[hor, ver].tileType);
                    Console.Write(tiles[hor, ver].ToChar());
                }

                if (endline)
                    Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayRoomRow(int ver, bool end = false)
        {
            for (int hor = 0; hor < xDimension; hor++)
            {
                ChooseColor(tiles[hor, ver].tileType);

                Console.Write(tiles[hor, ver].ToChar());
            }

            if (end)
                Console.WriteLine();
        }

        private void ChooseColor(TileType type)
        {
            switch (type)
            {
                case TileType.Floor:
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    }
                case TileType.Wall:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }
                case TileType.Door:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case TileType.UpStairs:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    }
                case TileType.DownStairs:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    }
                case TileType.LightCover:
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    }
                case TileType.FullCover:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    }
                case TileType.Occupied:
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                case TileType.Goal:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    }

            }
        }
    }
}
