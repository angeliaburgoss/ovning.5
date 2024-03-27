using System;
namespace ovning._5
{

	//define an abstract class "Vehicle" that implements the "IVehicle" interface. In turn it implementes the properties of IVehicle
	public abstract class Vehicle : IVehicle
	{
		public string VehicleType { get; set; }
		public string RegNumber { get; set; }
		public string Color { get; set; }
		public int NumberOfWheels { get; set; }

	}
}

