using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class FloorRequestButton
    {
        //defined properties
        public int ID { get; set; }
        public string status { get; set; }
        public int floor { get; set; }
        public string direction { get; set; }

        //constructor
        public FloorRequestButton(int _id, int _floor, string _direction)
        {
            this.ID = _id;
            this.status = "online";
            this.floor = _floor;
            this.direction = _direction;
        }
    }
}
