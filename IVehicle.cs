using System;
namespace ovning._5
{
	//define an interface "IVehicle" with the properties "VehicleType, RegNumber, Color, NumberOfWheels)

	interface IVehicle
	{
		string VehicleType { get; }

		string RegNumber { get; }

		string Color { get; }

		int NumberOfWheels { get; }

	}
}
