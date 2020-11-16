using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniCarsales.Providers;
using MiniCarsales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Controllers
{
	public class CarController : Controller
	{
		private readonly ILogger<CarController> _logger;

		public CarController(ILogger<CarController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IActionResult Index()
		{
			using (var carProvider = CarProvider.GetInstance())
			{
				var allCars = carProvider.GetAllCars().Select(CarViewModel.FromDbModel);
				return View(allCars);
			}
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CarViewModel car)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "Please ensure all fields provided are valid.");
				return View();
			}

			using (var carProvider = CarProvider.GetInstance())
			{
				var success = carProvider.AddCar(CarViewModel.ToDbModel(car));
				if (!success)
				{
					ModelState.AddModelError(string.Empty, "Unable to create car, please try again later.");
					return View();
				}
			}
			
			return RedirectToAction("Index");
		}
	}
}
