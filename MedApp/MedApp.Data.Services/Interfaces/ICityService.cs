using MedApp.Data.Models;
using System.Collections.Generic;

namespace MedApp.Data.Services.Interfaces
{
    public interface ICityService
    {
        public IEnumerable<City> GetAllCities();
    }
}
