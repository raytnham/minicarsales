using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Enums
{
	public enum VehicleType
	{
		[Display(Name = "Car")]
		Car = 0,
		[Display(Name = "Boat")]
		Boat = 1,
		[Display(Name = "Bike")]
		Bike = 2,
		[Display(Name = "Caravan")]
		Caravan = 3
	}
}
