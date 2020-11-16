using MiniCarsales.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Models
{
	public abstract class Vehicle
	{
		public int Id { get; set; }
		[Required]
		[Display(Name = "Vehicle Type")]
		public VehicleType VehicleType { get; set; }
		[Required]
		public string Make { get; set; }
		[Required]
		public string Model { get; set; }
		[Required(ErrorMessage = "Please enter a valid year."), Range(1000, 9999)]
		public int Year { get; set; }
	}
}
