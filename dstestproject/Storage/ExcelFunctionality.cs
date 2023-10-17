using dstestproject.Storage.Entity;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace dstestproject.Storage
{
    public static class ExcelFunctionality
    {
        /// <summary>
        /// Теоретически может вызывать исключения
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Task<List<WeatherElement>> ParseWeatherElemetsFromFile(string filename)
        {

            var newList = new List<WeatherElement>();


            var file = new FileInfo(filename);
            using (var stream = new FileStream(file.FullName, FileMode.Open))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    foreach (System.Data.DataTable table in result.Tables)
                    {
                        foreach (System.Data.DataRow row in table.Rows)
                        {
                            try
                            {

                                WeatherElement tmpWeatherElement = new WeatherElement();

                                DateTime tmpDateTime;
                                if (DateTime.TryParse(Convert.ToString(row[0]), out tmpDateTime))
                                {
                                    string currentCellText;
                                    string[] tmpTwoStrings;


                                    tmpWeatherElement.Date = tmpDateTime + (TimeSpan.Parse(Convert.ToString(row[1])));


                                    currentCellText = Convert.ToString(row[2]).Trim();
                                    if (!currentCellText.Contains(","))
                                    {
                                        tmpWeatherElement.TemperatureInteger = Convert.ToSByte(currentCellText);
                                        tmpWeatherElement.TemperatureFractional = 0;
                                    }
                                    else
                                    {
                                        tmpTwoStrings = currentCellText.Split(',');
                                        tmpWeatherElement.TemperatureInteger = Convert.ToSByte(tmpTwoStrings[0]);
                                        tmpWeatherElement.TemperatureFractional = Convert.ToSByte(tmpTwoStrings[1]);
                                    }


                                    currentCellText = Convert.ToString(row[3]).Trim();
                                    if (!currentCellText.Contains(","))
                                    {
                                        tmpWeatherElement.HumidityInteger = Convert.ToSByte(currentCellText);
                                        tmpWeatherElement.HumidityFractional = 0;
                                    }
                                    else
                                    {
                                        tmpTwoStrings = currentCellText.Split(',');
                                        tmpWeatherElement.HumidityInteger = Convert.ToSByte(tmpTwoStrings[0]);
                                        tmpWeatherElement.HumidityFractional = Convert.ToSByte(tmpTwoStrings[1]);
                                    }


                                    currentCellText = Convert.ToString(row[4]).Trim();
                                    if (!currentCellText.Contains(","))
                                    {
                                        tmpWeatherElement.DewPointInteger = Convert.ToSByte(currentCellText);
                                        tmpWeatherElement.DewPointFractional = 0;
                                    }
                                    else
                                    {
                                        tmpTwoStrings = currentCellText.Split(',');
                                        tmpWeatherElement.DewPointInteger = Convert.ToSByte(tmpTwoStrings[0]);
                                        tmpWeatherElement.DewPointFractional = Convert.ToSByte(tmpTwoStrings[1]);
                                    }


                                    tmpWeatherElement.Pressure = Convert.ToInt16(row[5]);


                                    currentCellText = Convert.ToString(row[6]).Trim();
                                    if (string.IsNullOrEmpty(currentCellText))
                                        tmpWeatherElement.WindDirections = "Штиль";
                                    else
                                        tmpWeatherElement.WindDirections = currentCellText;


                                    currentCellText = Convert.ToString(row[7]).Trim();
                                    if (string.IsNullOrEmpty(currentCellText))
                                    {
                                        tmpWeatherElement.WindSpeedInteger = 0;
                                        tmpWeatherElement.WindSpeedFractional = 0;
                                    }
                                    else
                                    {
                                        if (!currentCellText.Contains(","))
                                        {
                                            tmpWeatherElement.WindSpeedInteger = Convert.ToSByte(currentCellText);
                                            tmpWeatherElement.WindSpeedFractional = 0;
                                        }
                                        else
                                        {
                                            tmpTwoStrings = currentCellText.Split(',');
                                            tmpWeatherElement.WindSpeedInteger = Convert.ToSByte(tmpTwoStrings[0]);
                                            tmpWeatherElement.WindSpeedFractional = Convert.ToSByte(tmpTwoStrings[1]);
                                        }
                                    }


                                    currentCellText = Convert.ToString(row[8]).Trim();
                                    if (string.IsNullOrEmpty(currentCellText))
                                    {
                                        tmpWeatherElement.Cloudy = -1;
                                    }
                                    else
                                    {
                                        tmpWeatherElement.Cloudy = Convert.ToSByte(currentCellText);
                                    }


                                    currentCellText = Convert.ToString(row[9]).Trim();
                                    if (string.IsNullOrEmpty(currentCellText))
                                    {
                                        tmpWeatherElement.CloudHeight = -1;
                                    }
                                    else
                                    {
                                        tmpWeatherElement.CloudHeight = Convert.ToInt16(currentCellText);
                                    }


                                    currentCellText = Convert.ToString(row[10]).Trim();
                                    if (!Int32.TryParse(currentCellText, out int a))
                                    {
                                        if (currentCellText.ToLower().Contains("менее"))
                                        {
                                            currentCellText = Regex.Match(currentCellText, @"\d+").Value;

                                            if (string.IsNullOrEmpty(currentCellText))
                                            {
                                                tmpWeatherElement.HorizontalVisibilityInteger = -1;
                                                tmpWeatherElement.HorizontalVisibilityFractional = -1;
                                            }
                                            else
                                            {
                                                if (!currentCellText.Contains(","))
                                                {
                                                    tmpWeatherElement.HorizontalVisibilityInteger = (sbyte)-Convert.ToSByte(currentCellText);
                                                    tmpWeatherElement.HorizontalVisibilityFractional = 0;
                                                }
                                                else
                                                {
                                                    tmpTwoStrings = currentCellText.Split(',');
                                                    tmpWeatherElement.HorizontalVisibilityInteger = (sbyte)-(Convert.ToSByte(tmpTwoStrings[0]));
                                                    tmpWeatherElement.HorizontalVisibilityFractional = Convert.ToSByte(tmpTwoStrings[1]);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            continue;
                                        }

                                    }
                                    if (string.IsNullOrEmpty(currentCellText))
                                    {
                                        tmpWeatherElement.HorizontalVisibilityInteger = -1;
                                        tmpWeatherElement.HorizontalVisibilityFractional = -1;
                                    }
                                    else
                                    {
                                        if (!currentCellText.Contains(","))
                                        {
                                            tmpWeatherElement.HorizontalVisibilityInteger = Convert.ToSByte(currentCellText);
                                            tmpWeatherElement.HorizontalVisibilityFractional = 0;
                                        }
                                        else
                                        {
                                            tmpTwoStrings = currentCellText.Split(',');
                                            tmpWeatherElement.HorizontalVisibilityInteger = Convert.ToSByte(tmpTwoStrings[0]);
                                            tmpWeatherElement.HorizontalVisibilityFractional = Convert.ToSByte(tmpTwoStrings[1]);
                                        }
                                    }


                                    tmpWeatherElement.WeatherPhenomenon = Convert.ToString(row[11]).Trim();

                                    newList.Add(tmpWeatherElement);
                                }

                            }
                            catch (Exception)
                            {

                            }
                            finally
                            {

                            }
                        }
                    }






                }
            }

            return Task.FromResult(newList);




        }
    }
}
