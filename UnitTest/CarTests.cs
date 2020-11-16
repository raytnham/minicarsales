using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCarsales.Models;
using MiniCarsales.Enums;
using MiniCarsales.Providers;

namespace UnitTest
{
	[TestClass]
	public class CarTests
	{
		private readonly CarProvider _carProvider = CarProvider.GetInstance();

		[TestMethod]
		public void CreateCarSuccessfully()
		{
			var validCar = new Car
			{
				VehicleType = VehicleType.Car,
				Make = "Toyota",
				Model = "Camry",
				Year = 2015,
				Engine = "Inline",
				Doors = 4,
				Wheels = 4,
				BodyType = BodyType.Sedan
			};
			var result = _carProvider.AddCar(validCar, false);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void CreateCarFailed()
		{
			var invalidCar = new Car
			{
				VehicleType = VehicleType.Car,
				Make = string.Empty,
				Model = string.Empty,
				Year = 2015,
				Engine = "Inline",
				Doors = 4,
				Wheels = 4,
				BodyType = BodyType.Sedan
			};
			var result = _carProvider.AddCar(invalidCar);
			Assert.IsFalse(result);
		}
	}
}
