using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class DailyWeatherRecord
    {
        public DailyWeatherRecord(DateTime day, float temperature, WeatherType type)
        {
            Date = day;
            Temperature = ConvertKelvinToCelsius(temperature);
            Type = type;
        }

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Date { get; set; }

        public static float ConvertKelvinToCelsius(float temp)
        {
            float celsiusToKelvinDifference = 273.15f;
            float celsiusTemperature = temp - celsiusToKelvinDifference;
            return (float)Math.Round(celsiusTemperature, 2);
        }
    }
}
