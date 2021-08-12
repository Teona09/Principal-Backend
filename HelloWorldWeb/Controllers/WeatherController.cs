using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HelloWorldWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string longitude = "23.5800";
        private readonly string latitude = "46.7700";
        private readonly string apiKey = "c969b66bb3c8e3fe32d4485a1623f42c";

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            // https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=c969b66bb3c8e3fe32d4485a1623f42c
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherForecastList(response.Content);
        }

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherForecastList(string content)
        {
            var json = JObject.Parse(content);

            List<DailyWeatherRecord> result = new List<DailyWeatherRecord>();

            var jsonArray = json["daily"].Take(7);

            foreach (var item in jsonArray)
            {
                // TODO: convert item to dailyWeatherRecord

                DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(new DateTime(2021, 8, 12), 22.0f, WeatherType.Mild);
                long unixDateTime = item.Value<long>("dt");
                dailyWeatherRecord.Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date;

                float Temp = item.SelectToken("temp").Value<float>("day");
                dailyWeatherRecord.Temperature = Temp;

                string weather = item.SelectToken("weather")[0].Value<string>("description");
                dailyWeatherRecord.Type = Convert(weather);

                result.Add(dailyWeatherRecord);
            }

            return result;
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "few clouds":
                    return WeatherType.FewClouds;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                case "light rain":
                    return WeatherType.LightRain;
                case "moderate rain":
                    return WeatherType.ModerateRain;
                default:
                    throw new Exception($"Unknown weather type {weather}.");
            }
        }

        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WeatherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeatherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeatherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
