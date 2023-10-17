using dstestproject.Storage;
using dstestproject.Storage.Entity;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dstestproject.Managers.WeatherElements
{
    public class WeatherElementManager : IWeatherElementManager
    {
        private readonly DsTestDataContext _dbContext;
        private IEnumerable<WeatherElement> weatherElementsCached;
        private bool isActuallyWeatherElementsCached;
        public WeatherElementManager(DsTestDataContext dbContext)
        {
            _dbContext = dbContext;
            isActuallyWeatherElementsCached = false;
        }

        private int SaveContextChanges()
        {
            var ret = _dbContext.SaveChanges();
            isActuallyWeatherElementsCached = false;
            return ret;
        }

        private DbSet<WeatherElement> GetActullyContextWeatherElementsAsNoTracking()
        {
            var elements = _dbContext.WeatherElements;
            weatherElementsCached = elements.AsNoTracking().ToList();
            isActuallyWeatherElementsCached = true;
            return elements;
        }

        private IReadOnlyCollection<WeatherElement> GetAllAsNoTracking()
        {
            if (isActuallyWeatherElementsCached)
            {
                var query = weatherElementsCached.OrderBy(a => a.Date);
                var entities = query.ToList();
                return entities;
            }
            else
            {
                var query = GetActullyContextWeatherElementsAsNoTracking().OrderBy(a => a.Date).AsNoTracking();
                var entities = query.ToList();
                return entities;
            }
        }






        public async Task<IReadOnlyCollection<WeatherElement>> GetFilteredByMonth(int filterYear, int filterMonth)
        {
            if (isActuallyWeatherElementsCached)
            {
                var query = weatherElementsCached
                    .Where(we => we.Date.Year == filterYear && we.Date.Month == filterMonth)
                    .OrderBy(a => a.Date);
                var entities = query.ToList();
                return entities;
            }
            else
            {
                var query = GetActullyContextWeatherElementsAsNoTracking()
                .Where(we => we.Date.Year == filterYear && we.Date.Month == filterMonth)
                .OrderBy(a => a.Date)
                .AsNoTracking();
                var entities = await Task.Run(() => query.ToList());
                return entities;
            }
        }

        public async Task<IReadOnlyCollection<WeatherElement>> GetFilteredByYear(int filterYear)
        {
            if (isActuallyWeatherElementsCached)
            {
                var query = weatherElementsCached
                    .Where(we => we.Date.Year == filterYear)
                    .OrderBy(a => a.Date);
                var entities = query.ToList();
                return entities;
            }
            else
            {
                var query = GetActullyContextWeatherElementsAsNoTracking()
                .Where(we => we.Date.Year == filterYear)
                .OrderBy(a => a.Date)
                .AsNoTracking();
                var entities = await query.ToListAsync();
                return entities;
            }
        }

        public async Task<List<int>> GetYearsOfAll()
        {
            if (isActuallyWeatherElementsCached)
                return weatherElementsCached
                .Select(weatherElement => weatherElement.Date.Year)
                .Distinct()
                .ToList();
            else
                return await GetActullyContextWeatherElementsAsNoTracking()
                .Select(weatherElement => weatherElement.Date.Year)
                .Distinct()
                .ToListAsync();
        }

        public async void TryAddRange(IEnumerable<WeatherElement> newEntities)
        {

            var entities = GetAllAsNoTracking();

            if (entities.Count != 0)
                newEntities = newEntities.Where(e => !entities.Any(en => en.Date == e.Date));

            await _dbContext.WeatherElements.AddRangeAsync(newEntities);
            SaveContextChanges();
            return;
        }
    }
}
