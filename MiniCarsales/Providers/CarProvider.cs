using MiniCarsales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Providers
{
    public sealed class CarProvider : IDisposable
    {
        private static CarProvider _instance;
        private CarsalesContext _dbContext;
        private static readonly object _instanceLock = new object();
        private bool _disposed = false;

        private CarProvider(){}

        public static CarProvider GetInstance()
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new CarProvider();
                }
                _instance._dbContext = new CarsalesContext();
                return _instance;
            }
        }

        public Car[] GetAllCars()
        {
            return _dbContext.Cars.ToArray();
        }

        public bool AddCar(Car car, bool saveChanges = true)
        {
            // Validating model
            var context = new ValidationContext(car, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(car, context, validationResults, true);

            if (!isValid) return false;

            try
            {
                _dbContext.Cars.Add(car);
                if (saveChanges) _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                // Log failure message here
            }
            return false;
        }

        public void Dispose() => Dispose(true);
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
