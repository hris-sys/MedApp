using MedApp.Data.Models;
using MedApp.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedApp.Data.Services.Classes
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext context;

        public CityService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<City> GetAllCities()
        {
            var result = this.context.Cities
                                     .ToList();

            return result;
        }
    }
}
