using dstestproject.Managers.WeatherElements;
using dstestproject.Storage;
using dstestproject.Storage.Entity;
using dstestproject.Storage.StringShortNamedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace dstestproject.Controllers
{
    public class WeatherDataController : Controller
    {
        private readonly IWeatherElementManager _manager;
        public WeatherDataController(IWeatherElementManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public ViewResult HomePage()
        {
            return View();
        }
        public async Task<ViewResult> WeatherElementsAdd()
        {
            return View();
        }

        public async Task<ViewResult> WeatherElementsList(string year, string navigationMethod, string month)
        {
            int intMonth, intYear;
            IEnumerable<int> yearsInDatabase = await _manager.GetYearsOfAll();
            if (String.IsNullOrEmpty(navigationMethod))
            {
                navigationMethod = "month";
                intYear = DateTime.Now.Year;
                intMonth = DateTime.Now.Month;

                if (yearsInDatabase.Count() > 0 && !yearsInDatabase.Contains(intYear))
                {
                    intYear = yearsInDatabase.OrderBy(y => Math.Abs(y - intYear)).First();
                }
                IEnumerable<WeatherElement> entities = await _manager.GetFilteredByYear(intYear);
                var monthsUsed = entities
                .Select(weatherElement => weatherElement.Date.Month)
                .Distinct()
                .ToList();
                if (monthsUsed.Count() > 0 && !monthsUsed.Contains(intMonth))
                {
                    intMonth = monthsUsed.OrderBy(m => Math.Abs(m - intMonth)).First();
                }
                return View((entities.Where(e => e.Date.Month == intMonth), yearsInDatabase));
            }
            else
            {
                intMonth = month switch
                {
                    "January" => 1,
                    "February" => 2,
                    "March" => 3,
                    "April" => 4,
                    "May" => 5,
                    "June" => 6,
                    "July" => 7,
                    "August" => 8,
                    "September" => 9,
                    "October" => 10,
                    "November" => 11,
                    "December" => 12
                };
                intYear = Convert.ToInt32(year);
            }

            try
            {
                if (navigationMethod == "month")
                {
                    IEnumerable<WeatherElement> entities = await _manager.GetFilteredByMonth(intYear, intMonth);
                    return View((entities, yearsInDatabase));
                }
                else
                {
                    IEnumerable<WeatherElement> entities = await _manager.GetFilteredByYear(intYear);
                    return View((entities, yearsInDatabase));
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Upload(IFormFileCollection files)
        {

            try
            {
                var filenameStartString = "UploadedFiles";
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var r = file.Headers.IsReadOnly;
                        var filePath = Path.Combine(filenameStartString, file.FileName);
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }


                        var Entities = await ExcelFunctionality.ParseWeatherElemetsFromFile(filePath);
                        _manager.TryAddRange(Entities);
                    }
                }


                return RedirectToAction(nameof(WeatherElementsAdd));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<ActionResult<WeatherElementStringShortNamedUnit>> GetJSONWeatherElementsListFilteredBy(string year, string navigationMethod, string month)
        {
            try
            {
                int intMonth, intYear;

                if (!int.TryParse(year, out intYear))
                    return null;
                if (string.IsNullOrEmpty(month))
                    return null;
                if (string.IsNullOrEmpty(navigationMethod))
                    return null;
                if (navigationMethod != "month" && navigationMethod != "year")
                    return null;
                intMonth = month switch
                {
                    "January" => 1,
                    "February" => 2,
                    "March" => 3,
                    "April" => 4,
                    "May" => 5,
                    "June" => 6,
                    "July" => 7,
                    "August" => 8,
                    "September" => 9,
                    "October" => 10,
                    "November" => 11,
                    "December" => 12,
                    _ => 0
                };
                if (intMonth < 1 || 12 < intMonth)
                    return null;

                if (navigationMethod == "month")
                {
                    IEnumerable<WeatherElement> entities = await _manager.GetFilteredByMonth(intYear, intMonth);
                    return Ok(entities.Select(e => (WeatherElementStringShortNamedUnit)e).ToList());
                }
                else
                {
                    IEnumerable<WeatherElement> entities = await _manager.GetFilteredByYear(intYear);
                    return Ok(entities.Select(e => (WeatherElementStringShortNamedUnit)e).ToList());
                }

            }
            catch
            {
                return null;
            }


        }




    }
}
