using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                //var ID = 1;
                Elevator elevator = new Elevator(i);
                this.ElevatorsList.Add(elevator);
                //ID++;
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

            //for (int j = 0; j <= _servedFloors; j++)
            //{
            //    var buttonFloor = 1;
            //    var buttonID = 0;
            //    //FloorRequestButton floorButton = j;
            //    if (buttonFloor > 1)
            //    {
            //        CallButton button = new CallButton(buttonID, buttonFloor, "down");
            //        this.CallButtonsList.Add(button);
            //        buttonID++;
            //    }
            //    else if (buttonFloor == 1)
            //    {
            //        CallButton button = new CallButton(buttonID, buttonFloor, "up");
            //        this.CallButtonsList.Add(button);
            //        buttonID++;
            //    }
            //}
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

        //public void CreateCallButtons(int _amountOfFloors)
        //{
        //    int buttonFloor = 1;
        //    int callButtonID = 0;
        //    for (int i = 0; i < _amountOfFloors; i++)
        //    {
        //        if (buttonFloor < _amountOfFloors)
        //        { //If it's not the last floor
        //            CallButton callButton = new CallButton(callButtonID, buttonFloor, "up"); //id, floor, direction
        //            this.CallButtonsList.Add(callButton);
        //            callButtonID++;
        //        }

        //        if (buttonFloor > 1)
        //        { //If it's not the first floor
        //            CallButton callButton = new CallButton(callButtonID, buttonFloor, "down"); //id, floor, direction
        //            this.CallButtonsList.Add(callButton);
        //            callButtonID++;
        //        }
        //        buttonFloor++;
        //    }
        //}

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
            Console.WriteLine("Floor Request Made on floor " + _requestedFloor);
            Console.WriteLine("Column " + this.ColID + " chosen ");
            Console.WriteLine("Processing...");
            Console.WriteLine("Pshhhkkkkkkrrrr​kakingkakingkakingtsh​chchchchchchchcch");
            Elevator elevator = this.FindBestElevator(_requestedFloor, _direction);
            Console.WriteLine("Best Elevator for the job: Elevator #" + elevator.ID);
            elevator.FloorRequestsList.Add(_requestedFloor);
            //elevator.FloorRequestsList.ForEach(i => Console.WriteLine(i));
            elevator.SortFloorList();
            //move to user
            elevator.Go();
            
            //Console.WriteLine("Elevator has arrived at destination: floor " + _requestedFloor);
            //elevator.SwingDoors();
            //elevator.FloorRequestsList.Add(1);

            //move user to lobby
            //elevator.Go(1, "down");
            //Console.WriteLine("Elevator has arrived at lobby: floor 1");
            //elevator.SwingDoors();
            return elevator;
        }

        //****************MAIN****************

        //method to find best elevator

        //if floorrequestslist is empty
        //    then move elevator 1

        public Elevator FindBestElevator(int _requestedFloor, string _direction)
        {
            // Elevator chosenElevator = null;

            // var score = 10000000;
            // int distance = 10000000;

            Hashtable bestElevatorInfo = new Hashtable(){
                {"chosenElevator", null},
                {"score", 5},
                {"distance", 100000000}
            };

            this.ElevatorsList.ForEach(elevator =>
            {
                // Let's first check if the elevator is at my floor already and going in my direction
                if (_requestedFloor == elevator.CurrentFloor && _direction == elevator.Direction)
                {
                    isBestElevator(elevator, 1);
                }
                // If not then let's check if the elevator is higher than me, is coming down, and I want to also go down
                else if (_requestedFloor < elevator.CurrentFloor && elevator.Direction == "down" && _direction == elevator.Direction)
                {
                    // for (var i = 1; i < this.ElevatorsList.Count; i++)
                    // {
                    //     var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
                    //     if (cost > distance)
                    //     {
                    //         cost = distance;
                    //         chosenElevator = i;
                    //         //elevator.Status = "active";
                    //     }
                    // }
                    isBestElevator(elevator, 2);
                }
                // Or if the opposite is true and the elevator is lower than me, is going up, and I want to go up
                else if (_requestedFloor > elevator.CurrentFloor && elevator.Direction == "up" && _direction == elevator.Direction)
                {
                    // for (var i = 1; i < this.ElevatorsList.Count; i++)
                    // {
                    //     var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
                    //     if (cost > distance)
                    //     {
                    //         cost = distance;
                    //         chosenElevator = i;
                    //         //elevator.Status = "active";
                    //     }
                    // }
                    isBestElevator(elevator, 2);
                }
                // Let's check for any "idle" elevators
                else if (elevator.Status == "idle")
                {
                    isBestElevator(elevator, 3);
                }
                // If not other elevator meets our criteria, just select this elevator
                else
                {
                    // Console.WriteLine($"Requested Floor: {_requestedFloor}");
                    // Console.WriteLine($"Elevator Current Floor: {elevator.CurrentFloor}");
                    // Console.WriteLine($"Elevator Direction: {elevator.Direction}");
                    // Console.WriteLine($"Requested Direction: {_direction}");

                    isBestElevator(elevator, 4);
                }
            });

            void isBestElevator(Elevator elevator, int elevatorScore)
            {
                if (elevatorScore < (int)bestElevatorInfo["score"])
                {
                    bestElevatorInfo["chosenElevator"] = elevator;
                    bestElevatorInfo["score"] = elevatorScore;
                    bestElevatorInfo["distance"] = Math.Abs(elevator.CurrentFloor - _requestedFloor);
                }
                else if (elevatorScore == (int)bestElevatorInfo["score"])
                {
                    var elevatorDistance = Math.Abs(elevator.CurrentFloor - _requestedFloor);
                    if (elevatorDistance < (int)bestElevatorInfo["distance"])
                    {
                        bestElevatorInfo["chosenElevator"] = elevator;
                        bestElevatorInfo["distance"] = elevatorDistance;
                    }
                }
            }

            // return ElevatorsList[chosenElevator];
            return (Elevator)bestElevatorInfo["chosenElevator"];
        }

        //public Elevator FindBestElevator(int _requestedFloor, string _direction)
        //{
        //    var chosenElevator = 1;
        //    var cost = 1000;

        //    this.ElevatorsList.ForEach(elevator =>
        //    {
        //        if (_requestedFloor < elevator.CurrentFloor && elevator.Direction == "up" && _direction == elevator.Direction)
        //        {
        //            for (var i = 1; i < this.ElevatorsList.Count; i++)
        //            {
        //                var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
        //                if (cost > distance)
        //                {
        //                    cost = distance;
        //                    chosenElevator = i;
        //                    //elevator.Status = "active";
        //                }
        //            }
        //        }
        //        else if (_requestedFloor > elevator.CurrentFloor && elevator.Direction == "down" && _direction == elevator.Direction)
        //        {
        //            for (var i = 1; i < this.ElevatorsList.Count; i++)
        //            {
        //                var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
        //                if (cost > distance)
        //                {
        //                    cost = distance;
        //                    chosenElevator = i;
        //                    //elevator.Status = "active";
        //                }
        //            }
        //        }
        //        else if (_requestedFloor == elevator.CurrentFloor && elevator.Status == "stopped" && _direction == elevator.Direction)
        //        {
        //            for (var i = 1; i < this.ElevatorsList.Count; i++)
        //            {
        //                var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
        //                if (cost > distance)
        //                {
        //                    cost = distance;
        //                    chosenElevator = i;
        //                    //elevator.Status = "active";
        //                }
        //            }
        //        }
        //        else if (_requestedFloor > elevator.CurrentFloor && elevator.Status == "moving" && _direction == elevator.Direction)
        //        {
        //            for (var i = 1; i < this.ElevatorsList.Count; i++)
        //            {
        //                var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
        //                if (cost > distance)
        //                {
        //                    cost = distance;
        //                    chosenElevator = i;
        //                    //elevator.Status = "active";
        //                }
        //            }
        //        }
        //        else if (_requestedFloor < elevator.CurrentFloor && elevator.Status == "moving" && _direction == elevator.Direction)
        //        {
        //            for (var i = 1; i < this.ElevatorsList.Count; i++)
        //            {
        //                var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
        //                if (cost > distance)
        //                {
        //                    cost = distance;
        //                    chosenElevator = i;
        //                    //elevator.Status = "active";
        //                }
        //            }
        //        }
        //        else if (elevator.Status == "idle")
        //        {
        //            for (var i = 1; i < this.ElevatorsList.Count; i++)
        //            {
        //                var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
        //                if (cost > distance)
        //                {
        //                    cost = distance;
        //                    chosenElevator = i;
        //                    //elevator.Status = "active";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine(_requestedFloor);
        //            Console.WriteLine(elevator.CurrentFloor);
        //            Console.WriteLine(elevator.Direction);
        //            Console.WriteLine(_direction);
        //        }
        //    });
        //    return ElevatorsList[chosenElevator];
        //}

        //public Elevator FindBestElevator(int _requestedFloor, string _direction)
        //{
        //    var cost = 1000;
        //    var chosenElevator = 0;

        //    for (var i = 0; i < this.ElevatorsList.Count; i++)
        //    {
        //        var distance = ElevatorsList[i].CurrentFloor - _requestedFloor;
        //        if (distance > 0 && distance < cost)
        //        {
        //            cost = distance;
        //            chosenElevator = i;
        //        }
        //    }
        //    return ElevatorsList[chosenElevator];
        //}

        //public Elevator FindBestElevator(int _requestedFloor, string _direction)
        //{
        //    Elevator chosenElevator = null;
        //    var cost = 1000;
        //    ElevatorsList.ForEach(elevator =>
        //    {
        //        if (elevator.Status == "idle")
        //        {
        //            chosenElevator = elevator;
        //            Console.WriteLine("Passed test");
        //        }
        //        else if (elevator.Status != "idle" && elevator.Direction == "down")
        //        {
        //            for (var i = 0; i < this.ElevatorsList.Count; i++)
        //            {
        //                //Console.WriteLine("----------------------");
        //                var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
        //                //Console.WriteLine("TESTING");
        //                //Console.WriteLine(this.ElevatorsList[i].CurrentFloor);
        //                if (cost >= distance)
        //                {
        //                    cost = distance;
        //                    chosenElevator = ElevatorsList[i];
        //                    //chosenElevator.Status = "active";
        //                }
        //            }
        //        }
        //        //else if (elevator.Status != "idle" && elevator.Direction == "up")
        //        //{
        //        //    for (var i = 0; i < this.ElevatorsList.Count; i++)
        //        //    {
        //        //        //Console.WriteLine("----------------------");
        //        //        var distance = Math.Abs(this.ElevatorsList[i].CurrentFloor - _requestedFloor);
        //        //        //Console.WriteLine("TESTING");
        //        //        //Console.WriteLine(this.ElevatorsList[i].CurrentFloor);
        //        //        if (cost >= distance)
        //        //        {
        //        //            cost = distance;
        //        //            chosenElevator = ElevatorsList[i];
        //        //            //chosenElevator.Status = "active";
        //        //        }
        //        //    }
        //        //}
        //        else
        //        {
        //            Console.WriteLine("Failed");
        //        }
        //    });
        //    return chosenElevator;
        //}


        ///////////
        ///

        //foreach (var elevator in this.ElevatorsList)
        //    if (elevator.Status == "idle")
        //    {
        //        return elevator;
        //    }
        ///
        ///////////

        //return ElevatorsList[chosenElevator];

        //if (_requestedFloor == 1)
        //{
        //    this.ElevatorsList.ForEach(elevator =>
        //    {
        //        // if (elevator.CurrentFloor == 1 && elevator.Status == "down")
        //        // {
        //        //     chosenElevator = elevator;
        //        // }
        //        if (elevator.CurrentFloor == 1 && elevator.Status == "stopped")
        //        {
        //            chosenElevator = elevator;
        //        }
        //        if (elevator.CurrentFloor == 1 && elevator.Status == "idle")
        //        {
        //            chosenElevator = elevator;
        //        }
        //        else if (_requestedFloor != 1)
        //        {
        //            chosenElevator = elevator;
        //        }
        //    });
        //}
        //else
        //{
        //    chosenElevator = this.ElevatorsList[0];
        //}
        //return chosenElevator;


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

        //def bestElevator(self, _requestedFloor, _requestedDirection) -> None:
        //bestElevatorInfo = {
        //    "getElevator": "",
        //    "score": 5,
        //    "floorCost": 10000
        ////}
        //public Elevator FindBestElevator(int _requestedFloor, string _direction)
        //{
        //    this.ElevatorsList.ForEach(elevator =>
        //    {
        //        if (_requestedFloor == elevator.CurrentFloor && elevator.Status == "stopped" && _direction == elevator.Direction)
        //        {

        //        }
        //    });
        //}


        //    for elevator in self.elevatorsList:
        //        if (_requestedFloor == elevator.currentFloor and elevator.status == 'stopped' and _requestedDirection == elevator.direction:
        //            bestElevatorInfo = self.elevatorScore(1, elevator, bestElevatorInfo, _requestedFloor)

        //        elif _requestedFloor > elevator.currentFloor and elevator.direction == 'up' and _requestedDirection == elevator.direction:
        //            bestElevatorInfo = self.elevatorScore(2, elevator, bestElevatorInfo, _requestedFloor)

        //        elif _requestedFloor<elevator.currentFloor and elevator.direction == 'down' and _requestedDirection == elevator.direction:
        //            bestElevatorInfo = self.elevatorScore(2, elevator, bestElevatorInfo, _requestedFloor)

        //        elif elevator.status == 'idle':
        //            bestElevatorInfo = self.elevatorScore(3, elevator, bestElevatorInfo, _requestedFloor)

        //        else:
        //            bestElevatorInfo = self.elevatorScore(4, elevator, bestElevatorInfo, _requestedFloor)

        //    return bestElevatorInfo["getElevator"]

        //def elevatorScore(self, scoreCheck, newElevator, bestElevatorInfo, floor) -> None:
        //    if scoreCheck<bestElevatorInfo["score"]:
        //        bestElevatorInfo["score"] = scoreCheck
        //        bestElevatorInfo["getElevator"] = newElevator
        //        bestElevatorInfo["floorCost"] = abs(newElevator.currentFloor - floor)
        //    elif bestElevatorInfo["score"] == scoreCheck:
        //        gap = abs(newElevator.currentFloor - floor)
        //        if bestElevatorInfo["floorCost"] > gap:
        //            bestElevatorInfo["score"] = scoreCheck
        //            bestElevatorInfo["getElevator"] = newElevator
        //            bestElevatorInfo["floorCost"] = gap

        //    return bestElevatorInfo



    }
}
