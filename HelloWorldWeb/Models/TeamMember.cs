namespace HelloWorldWeb.Models
{
    using System;
    using HelloWorldWeb.Services;

    public class TeamMember
    {
        private static int idCount = 0;
        private readonly ITimeService timeService;

        public TeamMember(string name, ITimeService timeService)
        {
            this.Name = name;
            this.Id = idCount;
            idCount++;
            this.timeService = timeService;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public int GetAge()
        {
            TimeSpan age;
            DateTime birthdate = this.Birthdate;
            DateTime zeroTime = new DateTime(1, 1, 1);
            age = timeService.Now() - birthdate;
            int years = (zeroTime + age).Year - 1;

            return years;
        }

        public static int GetIdCount()
        {
            return idCount;
        }
    }
}