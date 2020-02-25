using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.GameMapComponents
{
    public enum TileType : byte
    {
        Floor,
        Wall,
        Door,
        UpStairs,
        DownStairs,
        LightCover,
        FullCover
    }
}
