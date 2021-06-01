using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
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
            this.Status = "idle";
            this.CurrentFloor = 1;
            this.Direction = null;
            this.Door = new Door(_id);
            this.FloorRequestsList = new List<int> {};
            this.CompletedRequestsList = new List<int> {};
        }

        private void CreateFloorRequestButtons(int _amountOfFloors)
        {
            int buttonFloor = 1;
            string direction = null;
            for (int i = 0; i < _amountOfFloors; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton(ID, buttonFloor, direction); //id, floor
                this.FloorRequestsList.Add(i);
                buttonFloor++;
                ID++;
            }
        }

        public void RequestFloor(int floor)
        {
            this.FloorRequestsList.Add(floor);
            // this.SortFloorList();
            this.Go();
            this.SwingDoors();
        }

        public Door SwingDoors()
        {
            if (CurrentFloor == this.FloorRequestsList[0])
            {
                this.Door.Status = "open";
                Console.WriteLine("OPENING DOORS");
            }
            return this.SwingDoors();
        }

        public void Go()
        {
            while (this.FloorRequestsList.Count != 0)
            {
                int destination = this.FloorRequestsList[0];
                this.Status = "moving";
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
                        this.CurrentFloor--;
                    }
                }
                this.Status = "stopped";
                //this.FloorRequestsList.Next();
            }
            this.Status = "idle";
        }

        // public void SortFloorList()
        // {
        //     if (this.Direction == "up")
        //     {
        //         this.FloorRequestsList.Sort(var(a, b) { return a - b});
        //     }
        //     else
        //     {
        //         this.FloorRequestsList.Sort(var(a, b) { return b - a});
        //     }
        // }
    }
}
