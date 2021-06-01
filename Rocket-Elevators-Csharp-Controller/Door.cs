using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Door
    {
        //auto-properties
        public int ID { get; set; }
        public string Status { get; set; }

        //constructor
        public Door(int _id)
        {
            this.ID = _id;
            this.Status = "closed";
        }

        //public static implicit operator string(Door v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
