using MiniCarsales.Enums;
using MiniCarsales.Models;
using System.ComponentModel.DataAnnotations;

namespace MiniCarsales.ViewModels
{
	public class CarViewModel
	{
		public int Id { get; set; }

		[Required]
		public string Make { get; set; }

		[Required]
		public string Model { get; set; }

		[Required(ErrorMessage = "Please enter a valid year."), Range(1000, 9999)]
		public int Year { get; set; }

		[Required]
		public string Engine { get; set; }

		[Required, Range(1, int.MaxValue)]
		public int Doors { get; set; }

		[Required, Range(1, int.MaxValue)]
		public int Wheels { get; set; }

		[Required]
		[Display(Name = "Body Type")]
		public BodyType BodyType { get; set; }

		public static CarViewModel FromDbModel(Car car)
		{
			return new CarViewModel
			{
				Id = car.Id,
				Make = car.Make,
				Model = car.Model,
				Year = car.Year,
				Engine = car.Engine,
				Doors = car.Doors,
				Wheels = car.Wheels,
				BodyType = car.BodyType
			};
		}

		public static Car ToDbModel(CarViewModel car)
		{
			return new Car
			{
				Id = car.Id,
				VehicleType = VehicleType.Car,
				Make = car.Make,
				Model = car.Model,
				Year = car.Year,
				Engine = car.Engine,
				Doors = car.Doors,
				Wheels = car.Wheels,
				BodyType = car.BodyType
			};
		}
	}
}
