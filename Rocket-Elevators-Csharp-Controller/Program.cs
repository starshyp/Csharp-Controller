using System;

namespace RocketElevatorsCsharpController
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Battery battery = new Battery(1,1,1,1,1);
            //battery.FindBestColumn(5);

            //Column column1 = new Column(...);

            //Elevator elevator = new Elevator();
            //CallButton callButton = new CallButton();
            //FloorRequestButton floorRequestButton = new FloorRequestButton();
            //Door door = new Door();

            //Console.WriteLine("Hello World!");

            //Column column = new Column(0, 5, { 1,2,3,4,5}, true);
            //Console.WriteLine(column.ID);
            //Console.WriteLine(column.amountOfElevators);
            //Console.WriteLine(column.servedFloors);
            //Console.WriteLine(column.isBasement);

            Battery battery = new Battery(4, 60, 6, 5, 5);
            battery.ColumnsList[3].ElevatorsList[0].CurrentFloor = 58;
            battery.ColumnsList[3].ElevatorsList[0].Direction = "down";

            battery.ColumnsList[3].ElevatorsList[1].CurrentFloor = 50;
            battery.ColumnsList[3].ElevatorsList[1].Direction = "up";

            battery.ColumnsList[3].ElevatorsList[2].CurrentFloor = 46;
            battery.ColumnsList[3].ElevatorsList[2].Direction = "up";

            battery.ColumnsList[3].ElevatorsList[3].CurrentFloor = 1;
            battery.ColumnsList[3].ElevatorsList[3].Direction = "up";

            battery.ColumnsList[3].ElevatorsList[4].CurrentFloor = 60;
            battery.ColumnsList[3].ElevatorsList[4].Direction = "down";

            //int _id, int _amountOfElevators, int _servedFloors, bool _isBasement)
            Column column = new Column(4, 5, 4, false);
            column.RequestElevator(54, "down");

            //SCENARIO **TO-DO**
            //Column column = new Column("B", 2, 2);

            //column.elevatorsList[0].currentFloor = 3
            //Elevator elevator = column.requestElevator(1, 'down');
            //elevator.requestFloor(6)

            //column.elevatorsList[0].currentFloor = 6
            //Column elevator1 = column.requestElevator(3, 'down')
            //elevator1.requestFloor(5)

            //Column column2 = new Column("A", 4, 1)

            //column2.elevatorsList[0].currentFloor = 10
            //Column elevator2 = column2.requestElevator(9, 'up')
            //elevator2.requestFloor(2)
        }
    }
}
