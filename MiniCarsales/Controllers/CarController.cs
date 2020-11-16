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
		private readonly CarProvider _carProvider;

		public CarController(ILogger<CarController> logger)
		{
			_logger = logger;
			_carProvider = CarProvider.GetInstance();
		}

		[HttpGet]
		public IActionResult Index()
		{
			var allCars = _carProvider.GetAllCars().Select(CarViewModel.FromDbModel);
			return View(allCars);
		}
	}
}
