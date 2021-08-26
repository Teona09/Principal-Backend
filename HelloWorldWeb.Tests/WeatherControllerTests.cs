namespace HelloWorldWeb.Tests
{
    using HelloWorldWeb.Models;
    using HelloWorldWebApp.Controllers;
    using Moq;
    using System;
    using System.IO;
    using System.Linq;
    using Xunit;

    public class WeatherControllerTests
    {
        [Fact]
        public void TestCheckingConversionFromJsonToDailyWeatherRecord()
        {
            // Assume
            string content = LoadJsonFromResource();
            var WeatherControllerSettingsMock = new Mock<IWeatherControllerSettings>();
            WeatherController weatherController = new WeatherController(WeatherControllerSettingsMock.Object);

            // Act
            var result = weatherController.ConvertResponseToWeatherForecastList(content);

            // Assert
            Assert.Equal(7, result.Count());
            var firstDay = result.First();

            Assert.Equal(new DateTime(2021, 8, 12), firstDay.Date);
            Assert.Equal(24.26f, firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.TestData.ContentForWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
