namespace Specs.Mocks
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Moq;

    public static class MvcMockHelpers
    {
        /// <summary>
        /// Get's a controller context for use in mocking.
        /// </summary>
        /// <param name="httpMethod">The type of HTTP method, usually "GET", or "POST".</param>
        public static ControllerContext GetControllerContextMock(string httpMethod)
        {
            var request = new Mock<HttpRequestBase>();
            request.Setup(r => r.HttpMethod).Returns(httpMethod);
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(c => c.Request).Returns(request.Object);
            var controllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), new Mock<ControllerBase>().Object);
            return controllerContext;
        }
    }
}