using dstestproject.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dstestproject.Storage.StringShortNamedModels
{
    public class WeatherElementStringShortNamedUnit
    {
        /// <summary>
        /// Date
        /// </summary>
        public string D { get; set; }
        /// <summary>
        /// Time
        /// </summary>
        public string T { get; set; }
        /// <summary>
        /// Temperature
        /// </summary>
        public string Te { get; set; }
        /// <summary>
        /// Humidity
        /// </summary>
        public string H { get; set; }
        /// <summary>
        /// Dew Point
        /// </summary>
        public string DP { get; set; }
        /// <summary>
        /// Pressure
        /// </summary>
        public string P { get; set; }
        /// <summary>
        /// Wind
        /// </summary>
        public string W { get; set; }
        /// <summary>
        /// Cloudy
        /// </summary>
        public string C { get; set; }
        /// <summary>
        /// Cloud Height
        /// </summary>
        public string CH { get; set; }
        /// <summary>
        /// Horizontal Visibility
        /// </summary>
        public string HV { get; set; }
        /// <summary>
        /// Weather Phenomenon
        /// </summary>
        public string WP { get; set; }

        public WeatherElementStringShortNamedUnit(WeatherElement originalElement)
        {

            D = originalElement.Date.ToShortDateString();
            T = originalElement.Date.ToShortTimeString();
            Te = originalElement.TemperatureInteger + (originalElement.TemperatureFractional == 0 ? "" : "," + originalElement.TemperatureFractional);
            H = originalElement.HumidityInteger + (originalElement.HumidityFractional == 0 ? "" : "," + originalElement.HumidityFractional);
            DP = originalElement.DewPointInteger + (originalElement.DewPointFractional == 0 ? "" : "," + originalElement.DewPointFractional);
            P = Convert.ToString(originalElement.Pressure);
            W = (originalElement.WindSpeedInteger == 0 && originalElement.WindSpeedFractional == 0 ? "" : originalElement.WindSpeedInteger) +
                (originalElement.WindSpeedFractional == 0 ? "" : "," + originalElement.WindSpeedFractional) +
                " " + originalElement.WindDirections;
            C = originalElement.Cloudy < 0 ? "" : Convert.ToString(originalElement.Cloudy);
            CH = originalElement.CloudHeight < 0 ? "" : Convert.ToString(originalElement.CloudHeight);
            HV = (originalElement.HorizontalVisibilityInteger < 0 ? "" : (originalElement.HorizontalVisibilityInteger == 0 ? "" : originalElement.HorizontalVisibilityInteger) + 
                (originalElement.HorizontalVisibilityFractional == 0 ? "" : "," + originalElement.HorizontalVisibilityFractional));
            WP = originalElement.WeatherPhenomenon;
        }
        public static implicit operator WeatherElementStringShortNamedUnit(WeatherElement weatherElement)
        {
            return new(weatherElement);
        }
    }
}
