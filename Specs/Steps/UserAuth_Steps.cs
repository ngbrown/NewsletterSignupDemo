namespace Specs.Steps
{
    using Moq;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    using Web.Infrastructure.Authentication;

    [Binding]
    public class UserAuth_Steps
    {
        private IAuthenticationService auth;

        [Given(@"a user exists with username ""(.*)"" and password ""(.*)""")]
        public void GivenAUserExistsWithUsernameAdminAndPasswordPassword(string username, string password)
        {
            var mock = new Mock<IAuthenticationService>();
            mock.Setup(x => x.IsValidLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            mock.Setup(x => x.IsValidLogin(username, password)).Returns(true);

            this.auth = mock.Object;
        }

        [Then(@"that user should be able to login using ""(.*)"" and ""(.*)""")]
        public void ThenThatUserShouldBeAbleToLoginUsingAdminAndPassword(string username, string password)
        {
            Assert.That(this.auth.IsValidLogin(username, password), Is.True);
        }

        [Then(@"that user should not be able to login using ""(.*)"" and ""(.*)""")]
        public void ThenThatUserShouldNotBeAbleToLoginUsingAdminAndBadguy(string username, string password)
        {
            Assert.That(this.auth.IsValidLogin(username, password), Is.False);
        }
    }
}
