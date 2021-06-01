using System;
using System.Collections.Generic;
using System.Text;
namespace RocketElevatorsCsharpController
{
    public class Column
    {
        public char ColID { get; set; }
        public string Status { get; set; }
        public List<int> ServedFloors;
        //public List<int> ServedFloors { get; set; }
        //List<int> ServedFloors = new List<int>;
        public bool IsBasement { get; set; }
        public List<Elevator> ElevatorsList;
        public List<CallButton> CallButtonsList;


        //constructor
        public Column(char _id, int _amountOfElevators, int _servedFloors, bool _isBasement)
        {
            this.ColID = _id;
            this.Status = "online";
            this.ServedFloors = new List<int>();
            //this.ServedFloors = _servedFloors;
            this.IsBasement = false;
            this.ElevatorsList = new List<Elevator>();
            this.CallButtonsList = new List<CallButton>();
            
            for (int i = 0; i < _amountOfElevators; i++)
            {
                Elevator elevator = new Elevator(i);
                this.ElevatorsList.Add(elevator);
            }
            
            for (int j = 0; j <= _servedFloors; j++)
            {
                //FloorRequestButton floorButton = j;
                if (j != 1)
                {
                    CallButton button = new CallButton(j, j, "down");
                    this.CallButtonsList.Add(button);
                }
                else if (j != _servedFloors)
                {
                    CallButton button = new CallButton(j, j, "up");
                    this.CallButtonsList.Add(button);
                }
            }
        }

        //method to add to ServedFloors
        //The floors are separated amongst the columns in the following way: B6 to B1, 2 to 20, 21 to 40, 41 to 60.
        //private List<int> ServedFloors = new List<int>();
        private void PushServedFloors(int _amountOfColumns)
        {
            for (var item = 'A'; item < _amountOfColumns; item++)
            {
                if (this.ColID == 'A')
                {
                    for (int i = 0; i > -6; i--)
                    {
                        this.ServedFloors.Add(i);
                    }
                }
                else if (this.ColID == 'B')
                {
                    for (int i = 2; i < 21; i++)
                    {
                        this.ServedFloors.Add(i);
                    }
                }
                else if (this.ColID == 'C')
                {
                    // this.ServedFloors.Add(0);
                    for (int i = 21; i < 41; i++)
                    {
                        this.ServedFloors.Add(i);
                    }
                }
                else if (this.ColID == 'D')
                {
                    // this.ServedFloors.Add(0);
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
        }

        public void CreateCallButtons(int _amountOfFloors)
        {
            int buttonFloor = 1;
            int callButtonID = 0;
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
            
            for (int i = 1; i <= _amountOfElevators; i++)
            {
                Elevator elevator = new Elevator(i); //id, amountOfFloors
                this.ElevatorsList.Add(elevator);
            }
        }

        //method to request elevator
        //****************MAIN****************
        public Elevator RequestElevator(int _requestedFloor, string _direction)
        {
            Elevator elevator = this.FindBestElevator(_requestedFloor, _direction);
            elevator.FloorRequestsList.Add(_requestedFloor);
            //elevator.sortFloorList();
            elevator.Go();
            // Console.WriteLine("<OPENING DOORS>");
            elevator.SwingDoors();
            return elevator;
        }

        //****************MAIN****************

        //method to find best elevator
        
        
        public Elevator FindBestElevator(int _requestedFloor, string _direction)
        {
            Elevator chosenElevator = null;
            float floorCost = 10000;
            // int score = 0;
            if (_requestedFloor == 1)
            {
                this.ElevatorsList.ForEach(elevator =>
                {
                    // if (elevator.CurrentFloor == 1 && elevator.Status == "down")
                    // {
                    //     chosenElevator = elevator;
                    // }
                    if (elevator.CurrentFloor == 1 && elevator.Status == "stopped")
                    {
                        chosenElevator = elevator;
                    }
                    if (elevator.CurrentFloor == 1 && elevator.Status == "idle")
                    {
                        chosenElevator = elevator;
                    }
                    else if (_requestedFloor != 1)
                    {
                        chosenElevator = elevator;
                    }
                });
            }
            return chosenElevator;
        }

        //public Elevator FindNearest(int _requestedFloor, string direction)
        //{
        //    var selectedElevator;
        //    int elevatorGap = 9000;
        //    for (int i = 0; i < ElevatorsList.Count; i++)
        //    {
        //        if (this.ElevatorsList[i].)
        //        {
        //            var floorGap = Math.Abs(this.ElevatorsList);
        //            if (floorGap > elevatorGap)
        //            {
        //                floorGap = elevatorGap;
        //                selectedElevator = this.ElevatorsList[i];
        //            }
        //        }
        //    }
        //}
        
        //public Column(int minFloor, int maxFloor)
        //{
        //    GlobalMinFloor = minFloor;
        //    GlobalMaxFloor = maxFloor;
        //}

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
