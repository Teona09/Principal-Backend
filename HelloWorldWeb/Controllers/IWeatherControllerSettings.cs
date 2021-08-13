namespace HelloWorldWebApp.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Longitude { get; set; }

        string Latitude { get; set; }

        string ApiKey { get; set; }
    }
}