using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ObserverPattern.GameMapComponents
{
    public class World
    {
        public int xDimension;// { get { return this.xDimension; } private set { this.xDimension = value; } }
        public int yDimension;// { get { return this.yDimension; } private set { this.yDimension = value; } }
        public int zDimension;// { get { return this.zDimension; } private set { this.zDimension = value; } }

        public static int xCurrentGen, yCurrentGen, zCurrentGen;

        public Room[,] rooms;
        public int xRooms;
        public int yRooms;

        public static int xCurrentRoom, yCurrentRoom;
        private List<GameComponent> Entities;

        public World(int xDimension = 50, int yDimension = 50, int zDimension = 1)
        {
            this.xDimension = xDimension;
            this.yDimension = yDimension;
            this.zDimension = zDimension;

            xCurrentGen = yCurrentGen = zCurrentGen = xCurrentRoom = yCurrentRoom = 0;
            xRooms = yRooms = 5;
            rooms = new Room[xRooms, yRooms];
            AddGeneratedRooms();

            Entities = new List<GameComponent>();
        }

        private void AddGeneratedRooms(int roomXDim = 10, int roomYDim = 10)
        {
            //Room tempRoom = new Room();
            for (int ver = 0; ver < yRooms; ver++)
            {
                for (int hor = 0; hor < xRooms; hor++)
                {
                    rooms[hor, ver] = new Room();
                    //tempRoom = new Room();
                    xCurrentRoom++;
                }
                yCurrentRoom++;
            }
        }

        public void DisplayAllRooms()
        {
            bool end;
            int verR = 0, horR = 0, row = 0;

            for (verR = 0; verR < rooms.GetLength(1); verR++)//for (row = 0; row < rooms[horR, verR].yDimension; row++)
            {

                for (row = 0; row < rooms[horR, verR].yDimension; row++)//for (verR = 0; verR < rooms.GetLength(1); verR++)
                {
                    for (horR = 0; horR < rooms.GetLength(0); horR++)
                    {

                        if (horR == rooms.GetLength(0) - 1)
                            end = true;
                        else
                            end = false;

                        // Gotta find a way to keep displaying only a certain row in each room that is connected horizontally.
                        rooms[horR, verR].DisplayRoomRow(row, end);
                        if (end)
                            break;
                        
                    }
                }
            }
        }

        public void DisplayRoom(GameComponent focusPoint)
        {
            Location locale = focusPoint.location;

            int roomX, roomY, tileX, tileY;
            roomX = 0;// (int)(locale.X / rooms.GetLength(0));
            tileX = locale.X;

            for (int x = 0; x < rooms.GetLength(0); x++)
            {
                if (tileX > rooms[x, 0].xDimension)
                {
                    roomX++;
                }
                else
                    break;
            }

            roomY = 0; // (int)(locale.Y / rooms.GetLength(1));
            tileY = locale.Y;
            for (int y = 0; y < rooms.GetLength(0); y++)
            {
                if (tileY > rooms[y, 0].yDimension)
                {
                    roomY++;
                }
                else
                    break;
            }


            rooms[roomX, roomY].DisplayRoom(true);
        }

        public void AddEntity(GameComponent entity)
        {
            Entities.Add(entity);
            UpdateTileEntity(entity);//, true);
        }

        public void UpdateTileEntity(GameComponent entity, bool occupied = true)
        {
            Location locale;

            if (occupied)
            {
                locale = entity.location;
            }
            else
            {
                locale = entity.lastLocation;
            }


            //Location lastLocale = entity.lastLocation;

            int roomX, roomY, tileX, tileY, target;
            //int roomXLast, roomYLast, tileXLast, tileYLast;

            roomX = target = 0;// (int)(locale.X / rooms.GetLength(0));
            tileX = locale.X;
            
            for (int x = 0; x < rooms.GetLength(0); x++)
            {
                for(int l = 0; l < rooms[x, 0].xDimension; l++)
                {
                    target += rooms[x, 0].xDimension;
                    if (tileX >= target)
                    {
                        roomX++;
                    }
                    else
                        break;
                }
                
            }

            roomY = target = 0; // (int)(locale.Y / rooms.GetLength(1));
            tileY = locale.Y;
            for (int y = 0; y < rooms.GetLength(0); y++)
            {
                for (int l = 0; l < rooms[0, y].yDimension; l++)
                {
                    target += rooms[0, y].yDimension;
                    if (tileY >= target)
                    {
                        roomY++;
                    }
                    else
                        break;
                }

                //if (tileY >= rooms[y, 0].yDimension)
                //{
                //    roomY++;
                //}
                //else
                //    break;
            }

            tileX = locale.X;
            for (int x = 0; x < roomX; x++)
            {
                tileX -= rooms[x, roomY].xDimension;
            }

            tileY = locale.Y;
            for (int y = 0; y < roomY; y++)
            {
                tileY -= rooms[roomX, y].yDimension;
            }

            //roomXLast = 0;// (int)(lastLocale.X / rooms.GetLength(0));
            //tileXLast = lastLocale.X;
            //for (int x = 0; x < rooms.GetLength(0); x++)
            //{
            //    if (tileXLast > rooms[x, 0].xDimension)
            //    {
            //        roomXLast++;
            //    }
            //    else
            //        break;
            //}
            //roomYLast = (int)(lastLocale.Y / rooms.GetLength(1));

            //tileXLast = lastLocale.X;
            //for (int x = 0; x < roomXLast; x++)
            //{
            //    tileXLast -= rooms[x, roomYLast].xDimension;
            //}

            //tileYLast = lastLocale.Y;
            //for (int y = 0; y < roomYLast; y++)
            //{
            //    tileYLast -= rooms[roomXLast, y].yDimension;
            //}

            rooms[roomX, roomY].tiles[tileX, tileY].occupied = occupied;
            rooms[roomX, roomY].tiles[tileX, tileY].entity = entity;

            if(!occupied)
                rooms[roomX, roomY].DisplayRoom(true);
            //rooms[roomXLast, roomYLast].tiles[tileXLast, tileYLast].occupied = false;
        }

        public void UpdateEntityTiles()
        {
            foreach(GameComponent cg in Entities)
            {
                UpdateTileEntity(cg);
                UpdateTileEntity(cg, false);
            }
        }

        public Tile CheckLocation(Location locale)
        {
            int roomX, roomY, tileX, tileY;
            roomX = (int)(locale.X / rooms.GetLength(0));
            roomY = (int)(locale.Y / rooms.GetLength(1));

            tileX = locale.X;
            for(int x = 0; x < roomX; x++)
            {
                tileX -= rooms[x, roomY].xDimension;
            }

            tileY = locale.Y;
            for(int y = 0; y < roomY; y++)
            {
                tileY -= rooms[roomX, y].yDimension;
            }

            return rooms[roomX, roomY].tiles[tileX, tileY];
        }
    }
}
