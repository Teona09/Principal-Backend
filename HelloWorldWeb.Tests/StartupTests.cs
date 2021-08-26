namespace HelloWorldWeb.Tests
{
    using Xunit;
    public class StartupTests
    {
        [Fact]
        public void ConvertHerokuStringToASPNETString()
        {
            // Assume
            string herokuConnection = "postgres://maqrkxkoxlfrqz:2ea28f9dc7716878079d2a660e053a825c2c03cdbcc3266e499a158c1d7c8064@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/d8hst65qbjq34u";

            // Act
            string aspnetConnectionString = Startup.ConvertHerokuStringToAspnetString(herokuConnection);

            // Assert
            Assert.Equal("Host=ec2-34-251-245-108.eu-west-1.compute.amazonaws.com;Port=5432;Database=d8hst65qbjq34u;User Id=maqrkxkoxlfrqz;Password=2ea28f9dc7716878079d2a660e053a825c2c03cdbcc3266e499a158c1d7c8064;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;", aspnetConnectionString);
        }
    }
}
