using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class CallButton
    {
        //auto-properties
        public char ID { get; set; }
        public string Status { get; set; }
        public int Floor { get; set; }
        public string Direction { get; set; }

        //constructor
        public CallButton(int _id, int _floor, string _direction)
        {
            this.ID = _id;
            this.Status = "off";
            this.Floor = _floor;
            this.Direction = _direction;
        }

        public static implicit operator List<object>(CallButton v)
        {
            throw new NotImplementedException();
        }
    }
}
