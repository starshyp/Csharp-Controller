using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Elevator
    {
        //defined properties
        public int ID { get; set; }
        public string status { get; set; }
        public int currentFloor { get; set; }
        public string direction { get; set; }
        public Array floorRequestsList { get; set; }
        public Array completedRequestsList { get; set; }

        //constructor
        public Elevator(int _id)
        {
            this.ID = _id;
            this.status = "online";
            this.currentFloor = _currentFloor;
            this.direction = _direction;
            this.door = new Door(_id);
            this.floorRequestsList = [];
            this.completedRequestsList = [];
        }
    }
}
