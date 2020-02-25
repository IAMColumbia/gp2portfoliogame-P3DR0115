using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.GameMapComponents
{
    public class Tile
    {
        Location location;
        TileType tileType;

        public Tile(Location Coordinates, TileType tileTerrain = TileType.Floor)
        {
            location = Coordinates;
            tileType = tileTerrain;
        }
    }
}
