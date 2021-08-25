namespace HelloWorldWeb.Models
{
    using System;
    using System.Diagnostics;
    using HelloWorldWeb.Services;

    [DebuggerDisplay("{Name}[{Id}]")]
    public class TeamMember
    {
        private static int idCount = 0;
        private readonly ITimeService timeService;

        public TeamMember()
        {
        }

        public TeamMember(string name, ITimeService timeService)
        {
            // kept for testing
            this.Name = name;
            this.Id = idCount;
            idCount++;
            this.timeService = timeService;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public static int GetIdCount()
        {
            return idCount;
        }

        public int GetAge()
        {
            TimeSpan age;
            DateTime birthdate = this.Birthdate;
            DateTime zeroTime = new DateTime(1, 1, 1);
            age = timeService.Now() - birthdate;
            int years = (zeroTime + age).Year - 1;

            return years;
        }
    }
}