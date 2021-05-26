using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Elevator
    {
        //auto-properties
        public char ID { get; set; }
        public string Status { get; set; }
        public int CurrentFloor { get; set; }
        public string Direction { get; set; }
        public string Door { get; set; }
        public Array FloorRequestsList { get; set; }
        public Array CompletedRequestsList { get; set; }

        //constructor
        public Elevator(char _id)
        {
            this.ID = _id;
            this.Status = "idle";
            this.CurrentFloor = 1;
            this.Direction = null;
            this.Door = new Door(_id);
            this.FloorRequestsList = new int[] {};
            this.CompletedRequestsList = new int[] {};
        }

        public static void createFloorRequestButtons(int _amountOfFloors)
        {
            let buttonFloor = 1
        for (let i = 0; i < _amountOfFloors; i++)
            {
                int floorRequestButton = new FloorRequestButton(floorRequestButtonID, buttonFloor) //id, floor
            this.floorRequestButtonsList.push(floorRequestButton)
            buttonFloor++
            floorRequestButtonID++
        }
        }

        requestFloor(floor)
        {
            this.floorRequestList.Add(floor)
            this.sortFloorList()
            this.move()
            this.operateDoors()
        }

        Go()
        {
            while (this.floorRequestList.length != 0)
            {
                let destination = this.floorRequestList[0]
                this.status = 'moving'
                if (this.currentFloor < destination)
                {
                    this.direction = 'up'
                while (this.currentFloor < destination)
                    {
                        console.log("Elevator #" + this.ID + " is now at floor " + this.currentFloor)
                    this.currentFloor++
                }
                }
                else if (this.currentFloor > destination)
                {
                    this.direction = 'down'
                  while (this.currentFloor > destination)
                    {
                        this.currentFloor--
                }
                }
                this.status = 'stopped'
                this.floorRequestList.shift()
            }
            this.status = 'idle'
        }

        sortFloorList()
        {
            if (this.direction == 'up')
            {
                this.floorRequestList.sort(function(a, b){ return a - b});
            }
            else
            {
                this.floorRequestList.sort(function(a, b){ return b - a});

            }
        }

        operateDoors()
        {
            this.doorStatus = 'opened'
            // WAIT 5 seconds
        if (!this.overweight)
            {
                this.door.status = 'closing'
            if (!this.door.obstruction)
                {
                    this.door.status = 'closed'
            }
                else
                {
                    //Wait for the person to clear the way
                    this.door.obstruction = false
                  this.operateDoors()
              }
            }
            else
            {
                while (this.overweight)
                {
                    // Activate overweight alarm, and wait for someone to get out
                    this.overweight = false
                }
                this.operateDoors()
          }
        }

        public static implicit operator List<object>(Elevator v)
        {
            throw new NotImplementedException();
        }
    }
}
