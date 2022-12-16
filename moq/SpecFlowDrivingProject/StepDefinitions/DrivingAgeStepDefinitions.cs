using DemoMoqLibrary;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDrivingProject.StepDefinitions
{
    [Binding]
    public class DrivingAgeStepDefinitions
    {
        private readonly ScenarioContext context;

        public DrivingAgeStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }


        [Given(@"the driver is (.*) years old")]
        public void GivenTheDriverIsYearsOld(int p0)
        {
            context["Person"] = new Person
            {
                Age = p0,
                Id = 1
            };

           
        }

        [When(@"they live in (.*)")]
        public void WhenTheyLiveIn(string countryName)
        {
            context["Country"] = countryName;

            var country= Enum.Parse<Country>(countryName);
            var person = (Person)context["Person"];
            IDrivingRegulations regulation = new DrivingRegulations();
            var result = regulation.IsAllowedToDrive(person, country);
            context["Result"] = result;
        }

        [Then(@"they are permitted to drive")]
        public void ThenTheyArePermittedToDrive()
        {
            var result = (bool)context["Result"];
            Assert.IsTrue(result);
        }

        [Then(@"they are not permitted to drive")]
        public void ThenTheyAreNotPermittedToDrive()
        {
            var result = (bool)context["Result"];
            Assert.IsFalse(result);
        }
    }
}
