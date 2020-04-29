using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.GameLib
{
    public class Tile
    {
        Location location;
        public TileType tileType;
        char representation;
        public bool occupied;
        public Character entity;

        public Tile(Location Coordinates, TileType tileTerrain = TileType.Floor)
        {
            location = Coordinates;
            tileType = tileTerrain;

            switch (tileType)
            {
                case TileType.Floor:
                    {
                        representation = '.';
                        break;
                    }
                case TileType.Wall:
                    {
                        representation = 'X';
                        break;
                    }
                case TileType.Door:
                    {
                        representation = 'B';
                        break;
                    }
                case TileType.UpStairs:
                    {
                        representation = '^';
                        break;
                    }
                case TileType.DownStairs:
                    {
                        representation = 'v';
                        break;
                    }
                case TileType.LightCover:
                    {
                        representation = 'c';
                        break;
                    }
                case TileType.FullCover:
                    {
                        representation = 'C';
                        break;
                    }
            }
        }

        public char ToChar()
        {
            if (!occupied)
                return this.representation;
            else
                return this.entity.representation;
        }
    }
}
