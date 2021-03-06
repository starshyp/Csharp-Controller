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
        public List<Column> ColumnsList;
        public List<FloorRequestButton> FloorRequestButtonsList;

        //constructor
        public Battery(int _id, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            //properties
            this.ID = _id;
            this.Status = "online";
            this.ColumnsList = new List<Column>();
            this.FloorRequestButtonsList = new List<FloorRequestButton>();

            char[] colArr = { 'A', 'B', 'C', 'D'};
            for (int i = 0; i < colArr.Length; i++)
            {
                Column column = new Column(colArr[i], 5, 20, true);
                column.ColID = colArr[i];
                this.ColumnsList.Add(column);
                //Console.Write(colArr[i]);
            }

            //char ID = 'A';
            //for (int i = 0; i < _amountOfColumns; i++, ID++)
            //{
            //    Column column = new Column(ID, 5, 20, true);
            //    column.ColID = ID;
            //    this.ColumnsList.Add(column);
            //}

            //for (int ID = 0; ID <= _amountOfColumns; ID++)
            //{
            //    Column column = new Column(ID, 5, 20, true);
            //    column.ColID = ID;
            //    this.ColumnsList.Add(column);
            //}

            // int floorbID = 0;

            void CreateFloorRequestButtons(int amountOfFloors)
            {
                int floor = 0;
                var floorRequestID = 0;

                if (floor == 0)
                {
                    for (int i = 0; i < amountOfFloors; i++)
                    {
                        FloorRequestButton floorb = new FloorRequestButton(floorRequestID, floor, "up");
                        this.FloorRequestButtonsList.Add(floorb);
                        floor++;
                        floorRequestID++;
                    }
                }
                else if (floor < 0)
                {
                    for (int i = -6; i < amountOfFloors; i--)
                    {
                        FloorRequestButton floorb = new FloorRequestButton(floorRequestID, floor, "down");
                        this.FloorRequestButtonsList.Add(floorb);
                        floor--;
                        floorRequestID--;
                    }
                }
                
                
                // for (int i = 0; i <= _amountOfFloors; i++)
                // {
                //     if (floor < 0)
                //     {
                //         FloorRequestButton floorb = new FloorRequestButton(floorRequestID, floor, "up");
                //         // floorb.FloorbID = i;
                //         this.FloorRequestButtonsList.Add(floorb);
                //         floor--;
                //         floorRequestID--;
                //     }
                //     else if (floor > 0)
                //     {
                //         FloorRequestButton floorb = new FloorRequestButton(floorRequestID, floor, "down");
                //         // floorb.FloorbID = i;
                //         this.FloorRequestButtonsList.Add(floorb);
                //         floor++;
                //         floorRequestID++;
                //     }
                //     else if (floor < _amountOfFloors || floor > _amountOfFloors)
                //     {
                //         FloorRequestButton floorb = new FloorRequestButton(floorRequestID, floor, "up");
                //         // floorb.FloorbID = i;
                //         this.FloorRequestButtonsList.Add(floorb);
                //         floor++;
                //         floorRequestID++;
                //     }
                // }
            }
        }

        //method to assign elevator
        private Elevator AssignElevator(int _requestedFloor, string _direction)
        {
            Column bestColumn = FindBestColumn(_requestedFloor);
            Elevator chosenElevator = bestColumn.FindBestElevator(_requestedFloor, _direction);
            return chosenElevator;
        }

        //method to find best column
        public Column FindBestColumn(int _requestedFloor)
        {
            Column chosenColumn = null;
            ColumnsList.ForEach(currentColumn => 
            {
                if (currentColumn.ServedFloors[0] == _requestedFloor)
                {
                    chosenColumn = currentColumn;
                }
            });
            return chosenColumn;
        }
    }
}

//OLD CODE
//defined fields
//public int ID;
//public string status;
//public List<Column> columnsList = new List<Column>();
//public Array floorRequestButtonsList;

//public void FindBestColumn(int_requestedFloor)
//    {
//        Column column = new Column(minFloor, maxFloor);
//        ColumnsList.ForEach(chosenColumn => {
//        if (_requestedFloor >= column.GlobalMinFloor && _requestedFloor <= column.GlobalMaxFloor)
//        {
//            return chosenColumn;
//        }
//    });

//List<Column> column = new List<Column>();
//Column column = new Column(_id, _amountOfElevators, _servedFloors, _isBasement);
//    ForEach (int column in this.ColumnsList)
//{
//    if (_servedFloors == _requestedFloor)
//    {
//        //int column = value;
//        //Column column = new Column();
//        return column;
//    }
//}


//else (chosenColumn.ServedFloors[0] != _requestedFloor)
//{
//    return chosenColumn;
//}
//return chosenColumn;

//int chosenColumn1 = chosenColumn;

//pushcolumnslist
//    List<Column> ColumnsList = new List<Column>();
//    char ID = "b";
//    for (int i = 0; i < columns; i++, ID++)
//    {
//        Column column = new Column(ID, 5, colb, true);
//        column.ID = ID;
//        ColumnsList.Add(column);
//    }
//    char ID = "1";
//    for (int i = 0; i < columns; i++, ID++)
//    {
//        Column column = new Column(ID, 5, col1, false);
//        column.ID = ID;
//        ColumnsList.Add(column);
//    }
//    char ID = "2";
//    for (int i = 0; i < columns; i++, ID++)
//    {
//        Column column = new Column(ID, 5, col2, false);
//        column.ID = ID;
//        ColumnsList.Add(column);
//    }
//    char ID = "3";
//    for (int i = 0; i < columns; i++, ID++)
//    {
//        Column column = new Column(ID, 5, col3, false);
//        column.ID = ID;
//        ColumnsList.Add(column);
//    }

//private int FindBestColumn(int requestedFloor)
//{
//    throw new NotImplementedException();
//}

//if (currentFloor == 1 && _requestedFloor == firstColumn)
//{
//    Elevator elevator = new Elevator(_id, _amountOfFloors);
//    this.elevatorsList.push(elevator)
//        _id++;
//}
//else if (currentFloor == 1 && _requestedFloor == secondColumn)
//{
//    int elevator = new Elevator(_id, _amountOfFloors);
//    this.elevatorsList.push(elevator)
//        _id++;
//}
//else if (currentFloor == 1 && _requestedFloor == thirdColumn)
//{
//    int elevator = new Elevator(_id, _amountOfFloors);
//    this.elevatorsList.push(elevator)
//        _id++;
//}
//else if (currentFloor == 1 && _requestedFloor == fourthColumn)
//{
//    int elevator = new Elevator(_id, _amountOfFloors);
//    this.elevatorsList.push(elevator)
//        _id++;
//