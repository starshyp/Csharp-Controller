using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Battery
    {
        //auto-properties
        public int ID { get; set; }
        public string Status { get; set; }
        public List<Column> ColumnsList = new List<Column>();
        public Array FloorRequestButtonsList { get; set; }

        //constructor
        public Battery(int _id, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            //properties
            this.ID = _id;
            this.Status = "online";
            this.ColumnsList = new Column(_id, _amountOfElevators, _servedFloors, _isBasement);
            this.FloorRequestButtonsList = new int[] { };
            //FloorRequestButtonsList++;

            this.AssignElevator(_requestedFloor, _direction)
            this.FindBestColumn(_requestedFloor)

            //pushcolumnslist
            List<Column> ColumnsList = new List<Column>();
            char ID = 'A';
            for (int i = 0; i < columns; i++, ID++)
            {
                Column column = new Column(ID, 66, 5, false);
                column.ID = ID;
                ColumnsList.Add(column);
            }
            char ID = 'B';
            for (int i = 0; i < columns; i++, ID++)
            {
                Column column = new Column(ID, 66, 5, true);
                column.ID = ID;
                ColumnsList.Add(column);
            }
            char ID = 'C';
            for (int i = 0; i < columns; i++, ID++)
            {
                Column column = new Column(ID, 66, 5, false);
                column.ID = ID;
                ColumnsList.Add(column);
            }
            char ID = 'D';
            for (int i = 0; i < columns; i++, ID++)
            {
                Column column = new Column(ID, 66, 5, false);
                column.ID = ID;
                ColumnsList.Add(column);
            }
        }

        //method
        public void CreateFloorRequestButtons(int _amountOfFloors)
        {
            int buttonFloor = 1;

            for (int i = 0; i < _amountOfFloors; i++)
                {
                    if (buttonFloor < _amountOfFloors)
                    { //If it's not the last floor
                    FloorRequestButton floorRequestButtons = new FloorRequestButton(ID, floor, 'up'); //id, floor, direction
                    this.FloorRequestButtons.add(callButton)
                        ID++;
                    }

                    if (buttonFloor > 1)
                    { //If it's not the first floor
                    FloorRequestButton floorRequestButton = new FloorRequestButton(ID, floor, 'down') //id, floor, direction
                    this.floorRequestButtonsList.add(callButton)
                        ID++;
                    }
                floorRequestButtons++;
                }
        }

        //method 1
        public void AssignElevator(int _requestedFloor, string _direction)
            {
                Column column = new Column();
                Elevator elevator = new Elevator(_id);
            //var result = ();
            //return result;

            //IndexOf()
            //int first = firstColumn.Range(B1, B6)
            //int secondColumn.Range(2, 20);
            //int thirdColumn.Range(21, 40);
            //int fourthColumn.Range(41, 60);

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
            public void FindBestColumn(int _requestedFloor)
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