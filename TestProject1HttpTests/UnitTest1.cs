using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;
using HttpAPI;


namespace HttpAPI.Tests
{
    public class HttpServiceTests
    {
        private Mock<IHttpClientFactory> _httpClientFactoryMock;
        private Mock<HttpMessageHandler> _handlerMock;

        public HttpServiceTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            var httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient())
                                  .Returns(httpClient);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnContent_WhenResponseIsSuccessful()
        {
            // Arrange
            var url = "https://example.com";
            var expectedResponse = "response content";

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse),
                })
                .Verifiable();

            var httpService = new HttpService(_httpClientFactoryMock.Object);

            // Act
            var result = await httpService.GetAsync(url);

            // Assert
            Assert.Equal(expectedResponse, result);
            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get && req.RequestUri == new Uri(url)),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task PostAsync_ShouldReturnContent_WhenResponseIsSuccessful()
        {
            // Arrange
            var url = "https://example.com";
            var jsonContent = "{\"key\":\"value\"}";
            var expectedResponse = "response content";

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse),
                })
                .Verifiable();

            var httpService = new HttpService(_httpClientFactoryMock.Object);

            // Act
            var result = await httpService.PostAsync(url, jsonContent);

            // Assert
            Assert.Equal(expectedResponse, result);
            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post && req.RequestUri == new Uri(url)),
                ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}
