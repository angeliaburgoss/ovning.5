using System;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace ovning._5

{
    //define a generic class "Garage" with "T" as a type parameter that is a subclass to "Vehicle
    // it implements "IEnumerable<T>" which allows instances of the class to be enumerated

    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        //declare a private array "vehicles" of type T. here the vehicles parked in the garage will be stored 
        private T[] vehicles;

        //declare a property that stores the garage name
        public string GarageName { get; set; }


        //the constructor to garage class that initializes "GarageName" property with a name and intializes vehicles array with a capacity
        public Garage (string name, int capacity)
        {
            this.GarageName = name;
            vehicles = new T[capacity];

        }

        //method to park vehicle in garage. It iterates over the array to find a "null" spot where a vehicle will be parked.
        //if garage(array) is full a message will be outputed to let the user know that the garage is full and vehicle could not be parked
        public void ParkVehicle(T vehicle)
        {

            //
            bool parked = false;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    parked = true;
                    Console.WriteLine(vehicle.GetType().Name + " with regnumber: " + vehicle.RegNumber + " has been parked in " + GarageName);
                    break;
                }
            }

            if (!parked)
            {
                Console.WriteLine("The garage is full and the vehicle could not be parked");
            }
        }

        //method to remove a vehicle from garage based on regnumber. Asks user to input regnumber and then iterates over
        //the "vehicles" array to find and remove desired vehicle from garage.
        //if vehicle is not found based on regnumber input a message is printed out that the vehicle with input regnumber could not be found in garage.
        public void RemoveVehicle()
        {

            bool vehicleRemove = false;

            Console.WriteLine("Enter the reg number of the vehicle that you want to remove: ");
            string regnumber = Console.ReadLine();


            foreach (var vehicle in vehicles)
            {
                if (vehicle != null && vehicle.RegNumber.Equals(regnumber, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Vehicle " + vehicle.GetType().Name + " with reg number " + vehicle.RegNumber + " has been removed from garage: " + GarageName);
                    vehicleRemove = true;
                    vehicles[Array.IndexOf(vehicles, vehicle)] = null;
                    break;
                }
            }

            if (!vehicleRemove)
            {
                Console.WriteLine("Vehicle with reg number: " + regnumber + " was not found in the garage");
            }
        }
              
                       
    

        //lists parked vehicles in garage by iterating over the array "vehicles" and prints out info about each vehicle parked in which garage
        public void ListParkedVehicles()
        {
            Console.WriteLine("List of parked vehicles in the garage: ");

            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                    Console.WriteLine(vehicle.GetType().Name + " with regnumber " + vehicle.RegNumber + " is in " + GarageName);
            }
        }


        //method finds a vehicles with a specified regnumber based on user input. If vehicle is found a message print out
        // indicating the vehicle type, regnumber and garage name that it was found in
        // if vehicle is not found it lets the user know by out puting that the vehicle with specified regnumber could not be found and in which garage.
        public void findVehicle(string regnr)
        {
            bool isFound = false;
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null && vehicle.RegNumber.Equals(regnr, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Vehicle " + vehicle.GetType().Name + " with reg number " + vehicle.RegNumber + " has been found in garage: " + GarageName);
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Vehicle with reg number: " + regnr + " was not found in the garage " + GarageName);
            }
        }



        //tried to do another method that would list all parked vehicles based on properties so that user could input for exmple all black cars
        //public void ListParkedVehicleTypes()
        //{
        //    Console.WriteLine("List of types of parked vehicles in the garage: ");
        //    int countCar = 0;
        //    int countAirplane = 0;
        //    int countMotorCycle = 0;
        //    int countBus = 0;
        //    int countBoat = 0;
        //    foreach (var vehicle in vehicles)
        //    {
        //        if (vehicle != null)
        //        { 

        //            if(vehicle.VehicleType == "Car")
        //            {
        //                countCar++;
        //            }
        //            else if(vehicle.VehicleType == "Airplane")
        //            {
        //                countAirplane++;
        //            }
        //            else if (vehicle.VehicleType == "Motorcycle")
        //            {
        //                countMotorCycle++;
        //            }
        //            else if (vehicle.VehicleType == "Bus")
        //            {
        //                countBus++;
        //            }
        //            else if (vehicle.VehicleType == "Boat")
        //            {
        //                countBoat++;
        //            }

        //            Console.WriteLine(vehicle.GetType().Name + " with regnumber " + vehicle.RegNumber + " is in the garage");
        //        }
        //    }


        // method that implements the "IEnumerable<T>" interface's "GetEnumerator" method which allows instances of the "Garage<T>"
        // class to be enumerates through a foreach loop 
        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in vehicles)
            {
                yield return item;
            }
        }

        // method that implements the non-generic "IEnumerable" interface's method "GetEnumerator" method by delegating to the generic method from above
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    }

}























