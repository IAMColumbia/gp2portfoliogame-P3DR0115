using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.GameLib
{
    public class RoomLocation
    {
        public int xRoom, yRoom;

        public RoomLocation(int xRoomCurrent = 0, int yRoomCurrent = 0)
        {
            this.xRoom = xRoomCurrent;
            this.yRoom = yRoomCurrent;
        }
    }
}
