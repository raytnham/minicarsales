using MiniCarsales.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Models
{
	public class Car : Vehicle
	{
		[Required]
		public string Engine { get; set; }

		[Required, Range(1, int.MaxValue)]
		public int Doors { get; set; }

		[Required, Range(1, int.MaxValue)]
		public int Wheels { get; set; }

		[Required]
		[Display(Name = "Body Type")]
		public BodyType BodyType { get; set; }
	}
}
