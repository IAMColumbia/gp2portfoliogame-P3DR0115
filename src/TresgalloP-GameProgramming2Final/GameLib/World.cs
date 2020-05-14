using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.GameLib
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

        public static int xCurrentRoomDraw, yCurrentRoomDraw;
        public int xCurrentPlayerRoom, yCurrentPlayerRoom;
        private Player player;
        private List<Character> Entities;
        private bool InvalidMove;

        public World(int xDimension = 50, int yDimension = 50, int zDimension = 1)
        {
            this.xDimension = xDimension;
            this.yDimension = yDimension;
            this.zDimension = zDimension;

            xCurrentGen = yCurrentGen = zCurrentGen = xCurrentRoomDraw = yCurrentRoomDraw = 0;
            xRooms = yRooms = 5;
            rooms = new Room[xRooms, yRooms];
            AddGeneratedRooms();

            Entities = new List<Character>();
            InvalidMove = false;
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
                    xCurrentRoomDraw++;
                }
                yCurrentRoomDraw++;
            }

            SetRandomGoalLocation();

        }

        private void SetRandomGoalLocation()
        {
            Random r = new Random();
            int x, y, a, b;
            x = r.Next(rooms.GetLength(0));
            y = r.Next(rooms.GetLength(1));

            do
            {
                a = r.Next(rooms[x, y].xDimension - 2);
            } while (a == 0);

            do
            {
                b = r.Next(rooms[x, y].yDimension - 2);
            } while (b == 0);

            rooms[x, y].tiles[a, b].tileType = TileType.Goal;
            rooms[x, y].tiles[a, b].UpdateTileRepresentation(TileType.Goal);
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

        public void DisplayRoom()//ref Player focusEntity)
        {
            rooms[player.locationInfo.roomLocation.xRoom, player.locationInfo.roomLocation.yRoom].DisplayRoom(true);
        }

        private void CalculateRoomCoordinates(ref int roomX, ref int roomY, ref int tileX, ref int tileY)
        {
            int xCheck, yCheck;
            for (yCheck = 0; yCheck < rooms.GetLength(1); yCheck++)
            {
                for (xCheck = 0; xCheck < rooms.GetLength(0); xCheck++)
                {
                    if (tileX > (rooms[xCheck, yCheck].xDimension - 1))
                    {
                        roomX++;
                        tileX -= (rooms[xCheck, yCheck].xDimension);
                    }

                    if (xCheck == (rooms.GetLength(0) - 1))
                        break;
                }

                if (tileY > (rooms[xCheck, yCheck].yDimension - 1))
                {
                    roomY++;
                    tileY -= (rooms[xCheck, yCheck].yDimension);
                }
                else
                    break;

                if (yCheck == (rooms.GetLength(1) - 1))
                    break;

            }
            //Tile target = rooms[roomX, roomY].tiles[tileX, tileY];

            //if (target.occupied || target.tileType == TileType.Wall)
            //    return false;
            //else
            //    return true;
        }

        private static void UpdateRoomCoordinates(Character focusEntity, RoomLocation roomLocale, int roomX, int roomY)
        {
            if (roomX != roomLocale.xRoom)
            {
                focusEntity.locationInfo.roomLastLocation.xRoom = focusEntity.locationInfo.roomLocation.xRoom;
                focusEntity.locationInfo.roomLocation.xRoom = roomX;
            }

            if (roomY != roomLocale.yRoom)
            {
                focusEntity.locationInfo.roomLastLocation.yRoom = focusEntity.locationInfo.roomLocation.yRoom;
                focusEntity.locationInfo.roomLocation.yRoom = roomY;
            }
        }

        public void AddEnemy(Character entity)
        {
            Entities.Add(entity);
            SetRandomLocation();
            UpdateTileEntity(entity, true, false, true);//, true);
        }

        public void AddPlayer(ref Player player)
        {
            this.player = player;
            UpdateTileEntity(player);
        }

        public void SetRandomLocation()
        {
            int x, y, a, b;
            x = Game.random.Next(rooms.GetLength(0));
            y = Game.random.Next(rooms.GetLength(1));

            TileType targetType;

            do
            {
                do
                {
                    a = Game.random.Next(rooms[x, y].xDimension - 2);
                } while (a == 0);

                do
                {
                    b = Game.random.Next(rooms[x, y].yDimension - 2);
                } while (b == 0);


                targetType = rooms[x, y].tiles[a, b].tileType;
            } while (targetType == TileType.Wall || targetType == TileType.Occupied || targetType == TileType.Goal);

            Entities.Last().locationInfo.location = Entities.Last().locationInfo.lastLocation = new Location((10 * x) + a, (10 * y) + b);
        }

        public void UpdateTileEntity(Character entity, bool occupied = true, bool last = false, bool force = false)
        {
            Location locale;
            RoomLocation roomLocale;

            if (occupied)
            {
                locale = entity.locationInfo.location;
                roomLocale = entity.locationInfo.roomLocation;
            }
            else
            {
                locale = entity.locationInfo.lastLocation;
                roomLocale = entity.locationInfo.roomLastLocation;
            }

            int roomX, roomY, tileX, tileY;
            tileX = locale.X;
            tileY = locale.Y;
            roomX = 0;
            roomY = 0;

            CalculateRoomCoordinates(ref roomX, ref roomY, ref tileX, ref tileY);
            //UpdateRoomCoordinates(entity, roomLocale, roomX, roomY);

            Tile target = rooms[roomX, roomY].tiles[tileX, tileY];
            if (target.tileType == TileType.Wall || (target.occupied && !last))
            {
                // Can't go to a wall
                InvalidMove = true;
                Console.WriteLine("Invalid Tile");
                try
                {
                    Game.command.UnExecute(player);
                } catch(Exception e)
                {
                    // Uninitialized, first-run error
                }
            }
            else
            {
                UpdateRoomCoordinates(entity, roomLocale, roomX, roomY);

                if(!last)
                    entity.locationInfo.UpdateTerrain(target);
                
                if(rooms[roomX, roomY].tiles[tileX, tileY].tileType == TileType.Goal)
                {
                    Game.isPlaying = false;
                    Game.winCondition = true;
                }

                rooms[roomX, roomY].tiles[tileX, tileY].occupied = occupied;
                rooms[roomX, roomY].tiles[tileX, tileY].entity = entity;
            }


            //rooms[roomXLast, roomYLast].tiles[tileXLast, tileYLast].occupied = false;
        }

        public void CheckShotTrajectory(Character c, ushort direction)
        {
            int roomX, roomY, tileX, tileY;
            tileX = c.locationInfo.location.X;
            tileY = c.locationInfo.location.Y;
            roomX = 0;
            roomY = 0;

            CalculateRoomCoordinates(ref roomX, ref roomY, ref tileX, ref tileY);

            int x, y, xStep = 0, yStep = 0;
            bool hitDone = false;
            
            switch(direction)
            {
                case 1:
                    {
                        xStep = -1;
                        yStep = 1;
                        break;
                    }
                case 2:
                    {
                        yStep = 1;
                        break;
                    }
                case 4:
                    {
                        xStep = -1;
                        break;
                    }
                case 6:
                    {
                        xStep = 1;
                        break;
                    }
                case 8:
                    {
                        yStep = -1;
                        break;
                    }
            }

            for(y = (tileY + yStep); y < rooms[roomX, roomY].yDimension; y += yStep)
            {
                if (y < 0)//|| rooms[roomX, roomY].tiles[x, y].tileType == TileType.Wall)
                    break; // actually checking backwards or bullet hit a wall.

                for (x = (tileX + xStep); x < rooms[roomX, roomY].xDimension; x += xStep)
                {
                    if (x < 0 || rooms[roomX, roomY].tiles[x, y].tileType == TileType.Wall)
                    {
                        if(!hitDone)
                            c.message += " Shot hit a wall...!";
                        
                        break; // actually checking backwards or bullet hit a wall.
                    }
                    
                    if(rooms[roomX, roomY].tiles[x, y].tileType == TileType.Occupied || rooms[roomX, roomY].tiles[x, y].occupied)
                    {
                        if(rooms[roomX, roomY].tiles[x, y].tileType == TileType.LightCover)
                        {
                            if((c.shotAccuracy + Tile.lightCoverBonus) < c.weapons[c.equippedWeapon].accuracy)
                            {
                                TargetTakesDamage(c, roomX, roomY, x, y, ref hitDone);
                            }
                            else
                            {
                                // Cover protected target
                                c.message += "\nShot missed, hit the cover!";
                            }
                        }
                        else if (rooms[roomX, roomY].tiles[x, y].tileType == TileType.FullCover)
                        {
                            if ((c.shotAccuracy + Tile.fullCoverBonus) < c.weapons[c.equippedWeapon].accuracy)
                            {
                                TargetTakesDamage(c, roomX, roomY, x, y, ref hitDone);
                            }
                            else
                            {
                                // Cover protected target
                                c.message += "\nShot missed, hit the cover!";
                            }
                        }
                        else
                        {
                            TargetTakesDamage(c, roomX, roomY, x, y, ref hitDone);
                        }
                    }

                    if (xStep == 0) // in case of "straight" horizontal shot
                        break;
                }
                //if (y < 0 )//|| rooms[roomX, roomY].tiles[x, y].tileType == TileType.Wall)
                //    break; // actually checking backwards or bullet hit a wall.
                if (yStep == 0) // in case of "straight" vertical shot
                    break;
            }
        }

        private void TargetTakesDamage(Character c, int roomX, int roomY, int x, int y, ref bool hitDone)
        {
            rooms[roomX, roomY].tiles[x, y].entity.TakeDamage(c.weapons[c.equippedWeapon].damage);
            c.message += $"Shot Hit! Target took {c.weapons[c.equippedWeapon].damage} damage!";
            if(rooms[roomX, roomY].tiles[x, y].entity.HealthPoints <= 0)
            {
                //target died
                c.message += " Target was killed!";
                rooms[roomX, roomY].tiles[x, y].occupied = false;
                foreach(Guard cr in Entities)
                {
                    if(cr.ID == rooms[roomX, roomY].tiles[x, y].entity.ID)
                    {
                        Entities.Remove(cr);
                        break;
                    }    
                }
                rooms[roomX, roomY].tiles[x, y].entity = null;
            }
            hitDone = true;
        }

        public void UpdateEntityTiles()
        {
            InvalidMove = false;
            if(player.movedTile)
            {
                UpdateTileEntity(player, true);
                if (!InvalidMove)
                    UpdateTileEntity(player, false, true);
            }
            player.movedTile = false;


            foreach (Character cr in Entities)
            {
                InvalidMove = false;
                if(cr.movedTile)
                {
                    UpdateTileEntity(cr);
                    if (!InvalidMove)
                        UpdateTileEntity(cr, false, true);
                }
                if(player.landHit && cr is Guard)
                {
                    cr.representation = cr.SetRepresentation();
                }
                cr.movedTile = false;
            }
        }

        public Tile CheckLocation(Location locale)
        {
            int roomX, roomY, tileX, tileY;
            roomX = (int)(locale.X / rooms.GetLength(0));
            roomY = (int)(locale.Y / rooms.GetLength(1));

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

            return rooms[roomX, roomY].tiles[tileX, tileY];
        }
    }
}
