using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace RocketElevatorsCsharpController
{
    public class Elevator
    {
        //auto-properties
        public int ID { get; set; }
        public string Status { get; set; }
        public int CurrentFloor { get; set; }
        public string Direction { get; set; }
        public Door Door { get; set; }
        public List<int> FloorRequestsList { get; set; }
        public List<int> CompletedRequestsList { get; set; }

        public Elevator(int _id)
        {
            this.ID = _id;
            this.Status = "active";
            this.CurrentFloor = 1;
            this.Direction = null;
            this.Door = new Door(_id);
            this.FloorRequestsList = new List<int> {};
            this.CompletedRequestsList = new List<int> {};
        }

        // private void PushToFloorRequestsList(int _amountOfFloors)
        // {
        //     int buttonFloor = 1;
        //     string direction = null;
        //     for (int i = 0; i < _amountOfFloors; i++)
        //     {
        //         FloorRequestButton floorRequestButton = new FloorRequestButton(ID, buttonFloor, direction); //id, floor
        //         this.FloorRequestsList.Add(i);
        //         buttonFloor++;
        //         ID++;
        //     }
        // }

        public void RequestFloor(int floor)
        {
            this.FloorRequestsList.Add(floor);
            // this.SortFloorList();
            this.Go();
            this.SwingDoors();
        }

        public void SwingDoors()
        {
            this.Door.Status = "open";
            Console.WriteLine("<< Opening Doors >>");
            Thread.Sleep(1000);
            this.Door.Status = "closed";
            Console.WriteLine(">> Closing Doors <<");
        }

        public void Go()
        {
            while (this.FloorRequestsList.Count != 0)
            {
                int destination = this.FloorRequestsList[0];
                this.Status = "active";
                if (this.CurrentFloor < destination)
                {
                    this.Direction = "up";
                    while (this.CurrentFloor < destination)
                    {
                        Console.WriteLine("Elevator #" + this.ID + " is now at floor " + this.CurrentFloor);
                        this.CurrentFloor++;
                    }
                }
                else if (this.CurrentFloor > destination)
                {
                    this.Direction = "down";
                    while (this.CurrentFloor > destination)
                    {
                        Console.WriteLine("Elevator #" + this.ID + " is now at floor " + this.CurrentFloor);
                        this.CurrentFloor--;
                    }
                }
                this.Status = "stopped";
                this.FloorRequestsList.RemoveAt(0);
                Console.WriteLine("Elevator #" + this.ID + " is stopped on " + this.CurrentFloor);
                this.SwingDoors();
            }
            this.Status = "idle";
        }

        //public void GoToLobby()
        //{

        //}

        public void SortFloorList()
        {
            if (this.Direction == "up")
            {
                this.FloorRequestsList.Sort();
            }
            else
            {
                this.FloorRequestsList.Sort();
                this.FloorRequestsList.Reverse();
            }
        }
    }
}
