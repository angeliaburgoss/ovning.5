using System;
namespace ovning._5
{

	// define a "GarageHandler" class that has a collection of "Garage<Vehicle>" instances 
	public class GarageHandler
	{
		//define a list "lt" that will hold references to garage objects 
		List<Garage<Vehicle>> lt = new List<Garage<Vehicle>>();
		

		// constructor of "GarageHandler". it takes a "Garage<Vehicle>" object as a parameter and adds it to the "lt" list.
		public GarageHandler(Garage<Vehicle> g)
		{
			lt.Add(g);
		}


		// method to add a new "Garage<Vehicle>" object to the "lt" list
		public void addGarage(Garage<Vehicle> g)
		{
			lt.Add(g);

		}


		// method to retrive a "Garage<Vehicle>" object from the "lt" list based on name.
		// it iterates over each garage in the list and returns the first garage with a matching name
		// if no garage with the specified name is found, null is returned
		public Garage<Vehicle> getGarage(string name)
		{
			foreach(var garage in lt)
			{
				if(name == garage.GarageName)
				{
					return garage;
				}
				
			}
			return null;
		}

		//method to remove a vehicle from a specifed garage
		// checks if garage excist in the "lt" list
		// if vehicle excists in list the "RemoveVehicle" method is called 
		public void removeVehicleFromGarage(Garage<Vehicle> ga)
		{

			if(lt.Contains(ga))
			{
				ga.RemoveVehicle();
			}
;			
			
		}


		// this method searches for a vehicles based on a specifed reg number.
		// searches through garages stored in the "lt" list
		// iterates over each garage in the list an then calls the "findVehicle" method of each garage to find vehicle
		public void  findVehicleInGarage(string regnr)

		{
			foreach (var g in lt)
			{
				g.findVehicle(regnr);
			}

		}
	}
}

