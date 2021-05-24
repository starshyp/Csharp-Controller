using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Battery
    {
        //auto-properties
        public int ID { get; set; }
        public string status { get; set; }
        public List<Column> columnsList = new List<Column>();
        public Array floorRequestButtonsList { get; set; }

        //constructor
        public Battery(int _id, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            //properties
            this.ID = _id;
            this.status = "online";
            this.columnsList = new Column(_id, _amountOfElevators, _servedFloors, _isBasement);
            this.floorRequestButtonsList = [];
        }

        //method 1
        public void AssignElevator(int _requestedFloor, string _direction)
        {
            Column column = new Column();
            Elevator elevator = new Elevator(_id);
            var result = ();
            return result;

            int first = firstColumn.Range(B1, B6)
            int secondColumn.Range(2, 20);
            int thirdColumn.Range(21, 40);
            int fourthColumn.Range(41, 60);

            if (currentFloor == 1 && _requestedFloor == firstColumn)
            {
                int elevator = new Elevator(_id, _amountOfFloors);
                this.elevatorsList.push(elevator)
                _id++;
            }
            else if (currentFloor == 1 && _requestedFloor == secondColumn)
            {
                int elevator = new Elevator(_id, _amountOfFloors);
                this.elevatorsList.push(elevator)
                _id++;
            }
            else if (currentFloor == 1 && _requestedFloor == thirdColumn)
            {
                int elevator = new Elevator(_id, _amountOfFloors);
                this.elevatorsList.push(elevator)
                _id++;
            }
            else if (currentFloor == 1 && _requestedFloor == fourthColumn)
            {
                int elevator = new Elevator(_id, _amountOfFloors);
                this.elevatorsList.push(elevator)
                _id++;
            }

            
        }
        //method 2
        public void findBestColumn(int _requestedFloor)
        {
            Column column = new Column();
        }
    }
}

//OLD CODE
//defined fields
//public int ID;
//public string status;
//public List<Column> columnsList = new List<Column>();
//public Array floorRequestButtonsList;