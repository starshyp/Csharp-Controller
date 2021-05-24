using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Column
    {
        //defined properties
        public int ID { get; set; }
        public string status { get; set; }
        public int servedFloors { get; set; }
        public int isBasement { get; set; }
        public List<Elevator> elevatorsList = new List<Elevator>();
        public List<CallButton> callButtonsList = new List<CallButton>();

        //constructor
        public Column(int _id, int _amountOfElevators, int _servedFloors, bool _isBasement)
        {
            this.ID = _id;
            this.status = "online";
            this.servedFloors = [];
            this.isBasement = _isBasement;
            this.elevatorsList = new Elevator(_id);
            this.callButtonsList = new CallButton(_id);
        }

        //method
        public void requestElevator(int _requestedFloor, string _direction)
        {
            Elevator elevator = new Elevator(_id);
        }
    }
}
