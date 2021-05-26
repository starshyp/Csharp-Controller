using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Door
    {
        //auto-properties
        public char ID { get; set; }
        public string Status { get; set; }

        //constructor
        public Door(char _id)
        {
            this.ID = _id;
            this.Status = "closed";
        }
    }
}
