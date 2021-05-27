using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class FloorRequestButton
    {
        //auto-properties
        public int FLRB_ID { get; set; }
        public string Status { get; set; }
        public int Floor { get; set; }
        public string Direction { get; set; }

        //constructors
        //public FloorRequestButton()
        //{

        //}
        public FloorRequestButton(int _id, int _floor, string _direction)
        {
            this.FLRB_ID = _id;
            this.Status = "online";
            this.Floor = _floor;
            this.Direction = _direction;
        }
    }
}
