namespace Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TechTalk.SpecFlow;

    using Moq;

    using NUnit.Framework;

    [Binding]
    public class Subscription_Steps
    {
        [Given(@"a subscription does exist with a name of ""(.*), (.*)"" and an e-mail of ""(.*)""")]
        public void GivenASubscriptionDoesExist(string lastName, string firstName, string email)
        {
            //TODO: implement arrange (recondition) logic
            // For storing and retrieving scenario-specific data, 
            // the instance fields of the class or the
            //     ScenarioContext.Current
            // collection can be used.
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 
            
            ScenarioContext.Current.Pending();
        }

        [Given(@"a subscription does not exist with an e-mail of ""(.*)""")]
        public void GivenASubscriptionDoesNotExist(string email)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"a user with the name ""(.*), (.*)"" and e-mail ""(.*)"" subscribes")]
        public void WhenAUserSubscribes(string lastName, string firstName, string email)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"a user with the name ""(.*), (.*)"" and e-mail ""(.*)"" un-subscribes")]
        public void WhenAUserUnSubscribes(string lastName, string firstName, string email)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the e-mail ""(.*)"" is in the persistent store")]
        public void ThenTheE_MailIsInThePersistentStore(string email)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the e-mail ""(.*)"" is not in the persistent store")]
        public void ThenTheE_MailIsNotInThePersistentStore(string email)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a error message is displayed")]
        public void ThenAErrorMessageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a success message is displayed")]
        public void ThenASuccessMessageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
