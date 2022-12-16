namespace DemoMoqLibrary
{
    public interface IDrivingRegulations
    {
        bool IsAllowedToDrive(Person person, Country country);
    }

    public class DrivingRegulations : IDrivingRegulations
    {
        private readonly Dictionary<Country, int> drivingAges;


        public DrivingRegulations()
        {
            drivingAges= new Dictionary<Country, int>
            {
                {Country.Italy, 18 },
                {Country.USA, 16 },
                {Country.France, 21 },
            };
        }

        public bool IsAllowedToDrive(Person person, Country country)
        {
            var age = drivingAges[country];
            return age <= person.Age;
        }
    }
}
