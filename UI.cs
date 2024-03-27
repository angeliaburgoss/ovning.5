using System;
using System.Collections.Generic;
namespace ovning._5
{

    //defines a "UI" class the implements the "IUI" interface
    public class UI : IUI
	{
        //private Garage<Vehicle> garage1 = new Garage<Vehicle>(8);
        GarageHandler garageHandler;



        //UI constructor, takes a name and capacity as parameters
        // creates a new "Garage<Vehicle>" instance with specified name and capacity
        // initializes a "GarageHandler" instance with the garage

        public UI (string name, int capacity)
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(name, capacity);
            garageHandler = new GarageHandler(garage);
            //garage1 = new Garage<Vehicle>(capacity);
        }

        
        // method that displays the main method of the application
        // handles user input based selected menu options
        public void menu()
        {
            bool exit = true;

            while (exit)
            {
                Console.WriteLine("\nWelcome to THE GARAGE");
                Console.WriteLine("1. Park a vehicle in the garage");
                Console.WriteLine("2. List all parked vehicles");
                Console.WriteLine("3. Find Vehicle");
                Console.WriteLine("4. Remove a vehicle from the garage");
                Console.WriteLine("5. Create a new garage");
                Console.WriteLine("6. Exit");

                Console.WriteLine("Choose 1, 2, 3, 4, 5, or 6 to quit application");

                string input = Console.ReadLine();

                              
                   switch (input)
                {
                    case "1":
                        submenu();

                        // park vehicle in garage. calls submenu method to chose type of vehicle to be parked
                        break;

                    case "2":
                        Console.WriteLine("Enter the garage name you want to list vehicles from: ");
                        string gName = Console.ReadLine();
                        (garageHandler.getGarage(gName)).ListParkedVehicles();

                        //list parked vehicles in specifed garage
                        //prompts user to input garage name, lists vehicles parked in that garage by calling the
                        // "ListParkedVehicles" method of "GarageHandler" 

                        break;

                    case "3":
                        Console.WriteLine("Enter the regnumber of the vehicle that you wish to find: ");
                        string regnr = Console.ReadLine();
                        garageHandler.findVehicleInGarage(regnr);

                        //finds vehicles based on regnumber. prompts user to input regnumber
                        //searches for it in all garages through the "findVehicleInGarage" method of "GarageHandler"

                        break;

                    case "4":
                        Console.WriteLine("Enter the name of the garage you wish to remove a vehicle from: ");
                        string gname = Console.ReadLine();
                        Garage<Vehicle> g= garageHandler.getGarage(gname);
                        garageHandler.removeVehicleFromGarage(g);

                        //removes a vehicle from a specified garage
                        //prompts user to input garage name and then removes vehicle from that garage
                        //using the "removeVehicleFromGarage" method of "GarageHandler"

                        break;

                    case "5":
                        Console.WriteLine("Enter desired name for the new garage: ");
                        string input2 = Console.ReadLine();
                        Console.WriteLine("Enter desired capacity for the new garage: ");
                        int input3 = int.Parse(Console.ReadLine());

                        Garage<Vehicle> ga = new Garage<Vehicle>(input2, input3);
                        garageHandler.addGarage(ga);                     
                        
                        Console.WriteLine("A new garage was created with the capacity: " + input2);

                        //creates a new garage. Prompts user to input name and capacity for new garage
                        //creates a new "Garage<Vehicle>" instance and adds it to the list of garages
                        // using the "addGarage" method of "GarageHandler"

                        break;

                    case "6":
                        exit = false;

                        //sets exit variable to false, which terminates the while loop of the switch statements
                        // the application can therefore be excited.
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input (1, 2, 3, 4, 5, or 6 to exit)");
                        break;

                }
            }

        }


        //submenu method displays the submenu to menu for selecting the type of vehicle to park and handles user input
        public void submenu()
        {
            bool isTrue = true;

            while (isTrue)
            {
                Console.WriteLine("\nWhich type of vehicle do you want to park? (1, 2, 3, 4, 5) choose the right type, or 6 to return to main menu");
                Console.WriteLine("1. Airplane");
                Console.WriteLine("2. Motorcycle");
                Console.WriteLine("3. Car");
                Console.WriteLine("4. Bus");
                Console.WriteLine("5. Boat");
                Console.WriteLine("6. Return to main manu");

                Console.WriteLine("Choose 1, 2, 3, 4, 5, or 6 to exit");

                string input2 = Console.ReadLine();

                Vehicle vehicle = null;


                //switch statement with the different kinds of vehicles that user can choose to park
                switch (input2)
                {
                    case "1":
                        vehicle = new Airplane();
                        vehicle.VehicleType = "Airplane";
                        Console.WriteLine("Enter the number of engines of the Airplane: ");
                        ((Airplane)vehicle).NumberOfEngines = (int.Parse(Console.ReadLine()));

                        break;

                    case "2":
                        vehicle = new Motorcycle();
                        vehicle.VehicleType = "Motorcycle";
                        Console.WriteLine("Enter the cylinder volume of the Motorcycle: ");
                        ((Motorcycle)vehicle).CylinderVolume = (double.Parse(Console.ReadLine()));
                                                
                        break;

                    case "3":
                        vehicle = new Car();
                        vehicle.VehicleType = "Car";
                        Console.WriteLine("Enter the fuel type of the Car: ");
                        ((Car)vehicle).FuelType = Console.ReadLine();
                                               
                        break;

                    case "4":
                        vehicle = new Bus();
                        vehicle.VehicleType = "Bus";
                        Console.WriteLine("Enter the number of seats of the Bus: ");
                        ((Bus)vehicle).NumberOfSeats = (int.Parse(Console.ReadLine()));
                                             
                        
                        break;

                    case "5":
                        vehicle = new Boat();
                        vehicle.VehicleType = "Boat";
                        Console.WriteLine("Enter the lenght of the Boat: ");
                        ((Boat)vehicle).Length = (int.Parse(Console.ReadLine()));
        
                        break;

                    case "6":
                        isTrue = false;                     
                        return;

                    default:
                        Console.WriteLine("Invalid input, please choose a valid vehicle type");
                        return;
                }

                
                //ask for more vehicle information "regnumber, color, numberofwheels and the garagename) for where the vehicle will be parked in
                Console.WriteLine("Enter vehicles regnumber: ");
                vehicle.RegNumber = Console.ReadLine();

                Console.Write("Enter vehicles color: ");
                vehicle.Color = Console.ReadLine();

                Console.Write("Enter the number of wheels of the vehicle: ");
                vehicle.NumberOfWheels = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the garage name");
                string garageName = Console.ReadLine();

                //parks vehicle in the specified garage using "ParkVehicle" method of "GarageHandler"
                (garageHandler.getGarage(garageName)).ParkVehicle(vehicle);
                //garage1.ParkVehicle(vehicle);
            }


        }





        public UI()
		{
		}
	}
}

