using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Column
    {
        //fields


        //auto-properties
        public int ID { get; set; }
        public string Status { get; set; }
        public int[] ServedFloors { get; set; }
        public bool IsBasement { get; set; }
        
        public string _direction { get; private set; }
        public int _floor { get; private set; }

        public List<Elevator> ElevatorsList = new List<Elevator>();
        public List<CallButton> CallButtonsList = new List<CallButton>();

        //constructor
        public Column(int _id, int _amountOfElevators, int _servedFloors, bool _isBasement)
        {
            this.ID = _id;
            this.Status = "online";
            this.ServedFloors = new int[] {};
            this.IsBasement = false;
            this.ElevatorsList = new Elevator(_id);
            this.CallButtonsList = new CallButton(_id, _floor, _direction);

            //dow we need this?
            this.CreateElevators(_amountOfFloors, _amountOfElevators);
            this.CreateCallButtons(_amountOfFloors);
        }

        //method to add to ServedFloors
        //The floors are separated amongst the columns in the following way: B6 to B1, 2 to 20, 21 to 40, 41 to 60.
        //private List<int> ServedFloors = new List<int>();
        static void ServedFloors()
        {

        }
        int first = firstColumn.Range(01, 06)
        int secondColumn.Range(2, 20);
        int thirdColumn.Range(21, 40);
        int fourthColumn.Range(41, 60);

            for (int i = 0; i<columns; i++, ID++)
            {
                column.ID = ID;
                ColumnsList.Add(column);
            }

        //method to add to CallButtonsList
        public static void CreateCallButtons(int _amountOfFloors)
        {
            int buttonFloor = 1;

            for (int i = 0; i < _amountOfFloors; i++)
                {
                    if (buttonFloor < _amountOfFloors)
                    { //If it's not the last floor
                    int callButton = new CallButton(callButtonID, buttonFloor, "up") //id, floor, direction
                    this.CallButtonsList.Add(callButton);
                        callButtonID++;
                    }

                    if (buttonFloor > 1)
                    { //If it's not the first floor
                    int callButton = new CallButton(callButtonID, buttonFloor, "down") //id, floor, direction
                    this.CallButtonsList.Add(callButton);
                        callButtonID++;
                    }
                buttonFloor++;
                }
        }

        //method to add to ElevatorsList
        public static void CreateElevators(_amountOfFloors, _amountOfElevators)
        {
            for (int i = 0; i < _amountOfElevators; i++)
            {
            char elevator = new Elevator(elevatorID, _amountOfFloors) //id, amountOfFloors
            this.ElevatorsList.Add(elevator);
                elevatorID++;
            }
        }

        //method to request elevator
        //****************MAIN****************
        public Elevator requestElevator(int _requestedFloor, string _direction)
        {
            //Elevator elevator = new Elevator(_id);
            string elevator = this.FindBestElevator(_floor, _direction);
            elevator.FloorRequestsList.Add(_floor);
            //elevator.sortFloorList();
            elevator.Go();
            elevator.SwingDoors();
            return elevator;
        }
        //****************MAIN****************

        //method to find best elevator
        public char FindBestElevator(int _requestedFloor, string _direction)
        {
            if (_requestedFloor == 1)
            {
                foreach (char elevator in ElevatorsList)
                {
                    Elevator elevator = new Elevator(ID);
                    Elevator.ID = ID;
                    ElevatorsList.Add(elevator);
                        if (elevator.CurrentFloor == 1 && elevator.Status == "stopped")
                        {
                            
                        }
                        if (elevator.CurrentFloor == 1 && elevator.Status == "idle")
                        {

                        }
                }
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
