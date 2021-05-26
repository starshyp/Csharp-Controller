using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class FloorRequestButton
    {
        //auto-properties
        public char ID { get; set; }
        public string Status { get; set; }
        public int Floor { get; set; }
        public string Direction { get; set; }

        //constructor
        public FloorRequestButton(char _id, int _floor, string _direction)
        {
            this.ID = _id;
            this.Status = "online";
            this.Floor = _floor;
            this.Direction = _direction;
        }
    }
}
