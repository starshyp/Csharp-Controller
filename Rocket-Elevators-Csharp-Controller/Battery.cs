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
                int ID = 0;
                for (int i = 0; i <= _amountOfColumns; ID++)
                {
                    Column column = new Column(ID, 5, 20, false);
                    column.ID = ID;
                    this.ColumnsList.Add(column);
                }
            this.FloorRequestButtonsList = new List<FloorRequestButton>();
            //FloorRequestButtonsList++;
                int FLRB_ID = 0;
                for (int i = 0; i < _amountOfFloors; ID++)
                {
                    FloorRequestButton flrb = new FloorRequestButton(FLRB_ID, 5, "down");
                    flrb.FLRB_ID = FLRB_ID;
                    this.FloorRequestButtonsList.Add(flrb);
                }
        }

        //method to assign elevator
        private Elevator AssignElevator(int _requestedFloor, string _direction)
        {
            Column bestColumn = FindBestColumn(_requestedFloor);
            Elevator chosenElevator = bestColumn.FindBestElevator(_requestedFloor, _direction);
            return chosenElevator;
        }
        
        //private Column FindBestElevator(int requestedFloor, string direction)
        //{
        //    throw new NotImplementedException();
        //}

        //method to find best column
        private Column FindBestColumn(int _requestedFloor)
        {
            Column chosenColumn = null;
            ColumnsList.ForEach(currentColumn => {
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