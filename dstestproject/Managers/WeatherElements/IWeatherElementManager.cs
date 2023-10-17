using dstestproject.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dstestproject.Managers.WeatherElements
{
    public interface IWeatherElementManager
    {
        Task<IReadOnlyCollection<WeatherElement>> GetFilteredByMonth(int filterYear, int filterMonth);
        Task<IReadOnlyCollection<WeatherElement>> GetFilteredByYear(int filterYear);
        Task<List<int>> GetYearsOfAll();
        void TryAddRange(IEnumerable<WeatherElement> newEntities);
        
    }
}
