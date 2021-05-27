using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Column
    {
        //fields
        //private int GlobalMinFloor;
        //private int GlobalMaxFloor;

        //auto-properties
        public int ID { get; set; }
        public string Status { get; set; }
        public List<int> ServedFloors;
        //public List<int> ServedFloors { get; set; }
        public bool IsBasement { get; set; }
        public List<Elevator> ElevatorsList;
        public List<CallButton> CallButtonsList;

        //constructors
        public Column()
        {

        }
        public Column(int _id, int _amountOfElevators, int _servedFloors, bool _isBasement)
        {
            this.ID = _id;
            this.Status = "online";
            this.ServedFloors = new List<int>();
            //this.ServedFloors = _servedFloors;
            this.IsBasement = false;
            this.ElevatorsList = new List<Elevator>();
            this.CallButtonsList = new List<CallButton>();
        }

        //public Column(int minFloor, int maxFloor)
        //{
        //    GlobalMinFloor = minFloor;
        //    GlobalMaxFloor = maxFloor;
        //}

        //method to add to ServedFloors
        //The floors are separated amongst the columns in the following way: B6 to B1, 2 to 20, 21 to 40, 41 to 60.
        //private List<int> ServedFloors = new List<int>();
        static void PushServedFloors(int _amountOfColumns, int _requestedFloor)
        {
            for (var item = 0; item < _amountOfColumns; item++)
            {
                if (this.ID == 0)
                {
                    for (int i = 0; i > -6; i--)
                    {
                        this.ServedFloors.Add(i);
                        Console.WriteLine(i);
                    }
                }
                else if (this.ID == 1)
                {
                    for (int i = 0; i < 21; i++)
                    {
                        this.ServedFloors.Add(i);
                    }
                }
                else if (this.ID == 2)
                {
                    this.ServedFloors.Add(1);
                    for (int i = 21; i < 41; i++)
                    {
                        this.ServedFloors.Add(i);
                    }
                }
                else if (this.ID == 3)
                {
                    this.ServedFloors.Add(1);
                    for (int i = 41; i < 61; i++)
                    {
                        this.ServedFloors.Add(i);
                    }
                }
                foreach (var i in ServedFloors)
                {
                    Console.WriteLine(i);
                }
            }
            //int floor;
            //string column;

            //floor = 1;
            //switch (floor)
            //{
            //    case 01:
            //    case 02:
            //    case 03:
            //    case 04:
            //    case 05:
            //    case 06:
            //        column = colb;
            //        break;

            //    case > 1:
            //    case <= 20:
            //        column = col1;
            //        break;

            //    case 21:
            //    case <= 40:
            //        column = col2;
            //        break;

            //    case 41:
            //    case <= 60:
            //        column = col3;
            //        break;

            //    default:
            //        column = lob;
            //        break;

            //List<int> numbers = new List<int>();
            //public int 
            //int[] array = new int[] { 1, 2, 3 };
            //numbers.AddRange(array);
        }
        //int first = firstColumn.Range(01, 06)
        //int secondColumn.Range(2, 20);
        //int thirdColumn.Range(21, 40);
        //int fourthColumn.Range(41, 60);

        //    for (int i = 0; i<columns; i++, ID++)
        //    {
        //        column.ID = ID;
        //        ColumnsList.Add(column);
        //    }

        //method to add to CallButtonsList
        public void CreateCallButtons(int _amountOfFloors)
        {
            int buttonFloor = 1;

            for (int i = 0; i < _amountOfFloors; i++)
                {
                    if (buttonFloor < _amountOfFloors)
                    { //If it's not the last floor
                    CallButton callButton = new CallButton(callButtonID, buttonFloor, "up"); //id, floor, direction
                    this.CallButtonsList.Add(callButton);
                        callButtonID++;
                    }

                    if (buttonFloor > 1)
                    { //If it's not the first floor
                    CallButton callButton = new CallButton(callButtonID, buttonFloor, "down"); //id, floor, direction
                    this.CallButtonsList.Add(callButton);
                        callButtonID++;
                    }
                buttonFloor++;
                }
        }

        //method to add to ElevatorsList
        public void CreateElevators(int _amountOfFloors, int _amountOfElevators)
        {
            for (int i = 0; i < _amountOfElevators; i++)
            {
                Elevator elevator = new Elevator(elevatorID, _amountOfFloors); //id, amountOfFloors
                this.ElevatorsList.Add(elevator);
                elevatorID++;
            }
        }

        //method to request elevator
        //****************MAIN****************
        public Elevator RequestElevator(int _requestedFloor, string _direction)
        {
            //Elevator elevator = new Elevator(_id);
            string elevator = this.FindBestElevator(_floor, _direction);
            elevator.FloorRequestsList.Add(_floor);
            //elevator.sortFloorList();
            elevator.Go();
            //elevator.SwingDoors();
            return elevator;
        }
        //****************MAIN****************

        //method to find best elevator
        public FindBestElevator(int _requestedFloor, string _direction)
        {
            if (_requestedFloor == 1)
            {
                ElevatorsList.ForEach(elevator =>
                {
                    Elevator elevator1 = new Elevator(ID);
                    Elevator.ID = ID;
                    ElevatorsList.Add(elevator);
                    if (elevator1.CurrentFloor == 1 && elevator1.Status == "stopped")
                    {

                    }
                    if (elevator1.CurrentFloor == 1 && elevator1.Status == "idle")
                    {

                    }
                });
                if (_requestedFloor != 1)
                {

                }
            }
        }

        //method to score elevator
        //checkIfElevatorIsBetter(scoreToCheck, newElevator, bestElevatorInformations, floor)
        //{
        //    if (scoreToCheck < bestElevatorInformations.bestScore)
        //    {
        //        bestElevatorInformations.bestScore = scoreToCheck
        //        bestElevatorInformations.bestElevator = newElevator
        //        bestElevatorInformations.referenceGap = Math.abs(newElevator.currentFloor - floor)
        //    }
        //    else if (bestElevatorInformations.bestScore == scoreToCheck)
        //    {
        //        let gap = Math.abs(newElevator.currentFloor - floor)
        //      if (bestElevatorInformations.referenceGap > gap)
        //        {
        //            bestElevatorInformations.bestScore = scoreToCheck
        //        bestElevatorInformations.bestElevator = newElevator
        //        bestElevatorInformations.referenceGap = gap
        //    }
        //    }
        //    return bestElevatorInformations
        //}


    }
}
