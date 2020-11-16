using MiniCarsales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Providers
{
    public sealed class CarProvider
    {
        private static CarProvider _instance;
        private readonly CarsalesContext _dbContext;
        private static readonly object _instanceLock = new object();

        private CarProvider(CarsalesContext context)
        {
            _dbContext = context;
        }

        public static CarProvider GetInstance()
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    var dbContext = new CarsalesContext();
                    _instance = new CarProvider(dbContext);
                }
                return _instance;
            }
        }

        public Car[] GetAllCars()
        {
            return _dbContext.Cars.ToArray();
        }
    }
}
