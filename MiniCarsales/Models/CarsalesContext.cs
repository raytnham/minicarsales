using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MiniCarsales.Models
{
	public class CarsalesContext : DbContext
	{
		public DbSet<Car> Cars { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite("Data Source=carsales.db");
	}
}
