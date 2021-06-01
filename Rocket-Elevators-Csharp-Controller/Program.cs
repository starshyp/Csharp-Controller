using System;

namespace RocketElevatorsCsharpController
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello world");

            //scenario 3
            Battery battery = new Battery(1, 4, 60, 6, 5);
            Console.WriteLine("=======================TEST==============================");
            //Console.WriteLine(battery.ColumnsList);
            //Console.WriteLine(battery.ColumnsList[4].ElevatorsList[0]);
            Console.WriteLine("=====================================================");
            battery.ColumnsList[1].ElevatorsList[0].CurrentFloor = 58;
            battery.ColumnsList[1].ElevatorsList[0].Direction = "down";
            battery.ColumnsList[1].ElevatorsList[0].Status = "active";
            battery.ColumnsList[1].ElevatorsList[0].FloorRequestsList.Add(1);

            battery.ColumnsList[1].ElevatorsList[1].CurrentFloor = 50;
            battery.ColumnsList[1].ElevatorsList[1].Direction = "up";
            battery.ColumnsList[1].ElevatorsList[1].Status = "active";
            battery.ColumnsList[1].ElevatorsList[0].FloorRequestsList.Add(60);

            battery.ColumnsList[1].ElevatorsList[2].CurrentFloor = 46;
            battery.ColumnsList[1].ElevatorsList[2].Direction = "up";
            battery.ColumnsList[1].ElevatorsList[2].Status = "active";
            battery.ColumnsList[1].ElevatorsList[0].FloorRequestsList.Add(58);

            battery.ColumnsList[1].ElevatorsList[3].CurrentFloor = 1;
            battery.ColumnsList[1].ElevatorsList[3].Direction = "up";
            battery.ColumnsList[1].ElevatorsList[3].Status = "active";
            battery.ColumnsList[1].ElevatorsList[0].FloorRequestsList.Add(54);

            battery.ColumnsList[1].ElevatorsList[4].CurrentFloor = 60;
            battery.ColumnsList[1].ElevatorsList[4].Direction = "down";
            battery.ColumnsList[1].ElevatorsList[4].Status = "active";
            battery.ColumnsList[1].ElevatorsList[0].FloorRequestsList.Add(1);

            Column column = new Column('D', 5, 20, false);
            column.RequestElevator(54, "down");
            
            //assignElevator is the method that's called when someone is at the floor 1 and wants to go to another floor whilst requestElevator is the method that's called whenever someone IS NOT at the first floor (and is obligated to go to the first floor, he can't choose to go down 2 floors for example).
        }
    }
}
