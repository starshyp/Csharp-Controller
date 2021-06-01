using System;

namespace RocketElevatorsCsharpController
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello world");

            //scenario 3
            //int _id, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn
            Battery battery = new Battery(4, 4, 60, 6, 5);
            battery.ColumnsList['D'].ElevatorsList[0].CurrentFloor = 58;
            battery.ColumnsList['D'].ElevatorsList[0].Direction = "down";

            battery.ColumnsList['D'].ElevatorsList[1].CurrentFloor = 50;
            battery.ColumnsList['D'].ElevatorsList[1].Direction = "up";

            battery.ColumnsList['D'].ElevatorsList[2].CurrentFloor = 46;
            battery.ColumnsList['D'].ElevatorsList[2].Direction = "up";

            battery.ColumnsList['D'].ElevatorsList[3].CurrentFloor = 1;
            battery.ColumnsList['D'].ElevatorsList[3].Direction = "up";

            battery.ColumnsList['D'].ElevatorsList[4].CurrentFloor = 60;
            battery.ColumnsList['D'].ElevatorsList[4].Direction = "down";

            //int _id, int _amountOfElevators, int _servedFloors, bool _isBasement)
            Column column = new Column('D', 5, 20, false);
            column.RequestElevator(54, "down");
        }
    }
}
