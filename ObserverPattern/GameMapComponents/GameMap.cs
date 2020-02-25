using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ObserverPattern.GameMapComponents
{
    public class GameMap
    {
        private string Savelocation = AppDomain.CurrentDomain.BaseDirectory + "GameMap.txt";
        private string[] tempTiles;
        private char[] tempXTiles;

        public List<Tile> tiles;

        public GameMap()
        {
            Load();
        }

        private void Load()
        {
            try
            {
                tempTiles = System.IO.File.ReadAllLines(Savelocation);
                for(int i = 0; i < tempTiles.Length; i++) // Y
                {
                    tempXTiles = tempTiles[i].ToCharArray();
                    for(int j = 0; j < tempXTiles.Length; j++) // X
                    {
                        Location loc = new Location(j, i);
                        tiles.Add(AssignTile(j, loc));

                    }
                }

            } catch(Exception e)
            {
                // FUUUUUUQ
            }

        }

        private Tile AssignTile(int j, Location loc)
        {
            Tile readTile;

            switch (tempXTiles[j])
            {
                case '.': // Floor
                    {
                        readTile = new Tile(loc, TileType.Floor);
                        break;
                    }
                case 'X': // Wall
                    {
                        readTile = new Tile(loc, TileType.Wall);
                        break;
                    }
                case 'D': // Door
                    {
                        readTile = new Tile(loc, TileType.Door);
                        break;
                    }
                case '^': // UpStairs
                    {
                        readTile = new Tile(loc, TileType.UpStairs);
                        break;
                    }
                case 'v': // DownStairs
                    {
                        readTile = new Tile(loc, TileType.DownStairs);
                        break;
                    }
                case '-': // LightCover
                    {
                        readTile = new Tile(loc, TileType.LightCover);
                        break;
                    }
                case '=': // FullCover
                    {
                        readTile = new Tile(loc, TileType.FullCover);
                        break;
                    }
                default: // Wall
                    {
                        readTile = new Tile(loc, TileType.Wall);
                        break;
                    }
            }

            return readTile;
        }
    }
}
