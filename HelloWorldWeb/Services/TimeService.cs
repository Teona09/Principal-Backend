namespace HelloWorldWeb.Services
{
    using System;

    public class TimeService : ITimeService
    {
        public TimeService()
        {
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
