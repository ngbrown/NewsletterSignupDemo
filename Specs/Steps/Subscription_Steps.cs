namespace Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    using Mocks;

    using TechTalk.SpecFlow;

    using Moq;

    using NUnit.Framework;

    using Web.Controllers;
    using Web.Infrastructure.Storage;
    using Web.Model;

    [Binding]
    public class Subscription_Steps
    {
        private SessionMock sessionMock;
        private Mock<IDataStorage> dataStorageMock;

        [Given(@"a subscription does exist with a name of ""(.*), (.*)"" and an e-mail of ""(.*)""")]
        public void GivenASubscriptionDoesExist(string lastName, string firstName, string email)
        {
            this.dataStorageMock = new Mock<IDataStorage>();
            this.sessionMock = new SessionMock();

            this.dataStorageMock.Setup(x => x.NewSession()).Returns(() => this.sessionMock);
            this.sessionMock.Add(new Subscription()
                {
                    LastName = lastName, 
                    FirstName = firstName, 
                    EMail = email
                });
        }

        [Given(@"a subscription does not exist with an e-mail of ""(.*)""")]
        public void GivenASubscriptionDoesNotExist(string email)
        {
            this.dataStorageMock = new Mock<IDataStorage>();
            this.sessionMock = new SessionMock();

            this.dataStorageMock.Setup(x => x.NewSession()).Returns(() => this.sessionMock);
        }

        [When(@"a user with the name ""(.*), (.*)"" and e-mail ""(.*)"" subscribes")]
        public void WhenAUserSubscribes(string lastName, string firstName, string email)
        {
            var formCollection = new FormCollection
                {
                    { "EMail", email },
                    { "LastName", lastName},
                    { "FirstName", firstName},
                };


            var controller = new SubscriptionController(this.dataStorageMock.Object)
                {
                    ControllerContext = MvcMockHelpers.GetControllerContextMock("POST")
                };

            var actionResult = controller.Create(formCollection);

            ScenarioContext.Current["Controller"] = controller;
            ScenarioContext.Current["ActionResult"] = actionResult;
        }

        [When(@"a user with the name ""(.*), (.*)"" and e-mail ""(.*)"" un-subscribes")]
        public void WhenAUserUnSubscribes(string lastName, string firstName, string email)
        {
            var controller = new SubscriptionController(this.dataStorageMock.Object)
            {
                ControllerContext = MvcMockHelpers.GetControllerContextMock("POST")
            };

            var actionResult = controller.Delete(email, new FormCollection());

            ScenarioContext.Current["Controller"] = controller;
            ScenarioContext.Current["ActionResult"] = actionResult;
        }

        [Then(@"the e-mail ""(.*)"" is in the persistent store")]
        public void ThenTheE_MailIsInThePersistentStore(string email)
        {
            Assert.That(this.sessionMock.Single<Subscription>(x => x.EMail.Equals(email,StringComparison.InvariantCultureIgnoreCase)), Is.Not.Null);
        }

        [Then(@"the e-mail ""(.*)"" is not in the persistent store")]
        public void ThenTheE_MailIsNotInThePersistentStore(string email)
        {
            Assert.That(this.sessionMock.Single<Subscription>(x => x.EMail.Equals(email,StringComparison.InvariantCultureIgnoreCase)), Is.Null);
        }

        [Then(@"a error message is displayed")]
        public void ThenAErrorMessageIsDisplayed()
        {
            var controller = (Controller)ScenarioContext.Current["Controller"];
            ////var result = (RedirectToRouteResult)ScenarioContext.Current["ActionResult"];

            Assert.That(controller.TempData.ContainsKey("info") == false);
            Assert.That(controller.TempData.ContainsKey("warning"));
            Assert.That(controller.TempData.ContainsKey("error") == false);
        }

        [Then(@"a success message is displayed")]
        public void ThenASuccessMessageIsDisplayed()
        {
            var controller = (Controller)ScenarioContext.Current["Controller"];
            ////var result = (RedirectToRouteResult)ScenarioContext.Current["ActionResult"];

            Assert.That(controller.TempData.ContainsKey("info"));
            Assert.That(controller.TempData.ContainsKey("warning") == false);
            Assert.That(controller.TempData.ContainsKey("error") == false);
        }
    }
}
