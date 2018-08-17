using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Models.Currency;
using Models.Enams;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace UnitTest.BussinesLogic
{
    public class CurrencyServiceTest
    {
        [Fact]
        public void TransferOfCurrency_FromBelRub_ReturnExpectedValue()
        {
            //arrange
            const float value = 1;
            const double expectedResult = 33;
            var expectedRate = new Rate
            {
                CurId = (int) Currency.Dollar,
                CurName = "Доллар США",
                Date = DateTimeOffset.Now,
                CurScale = 100,
                CurOfficialRate = 3,
                CurAbbreviation = "USD"
            };

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(GetHttpResponseMessage(expectedRate)));
            var currencyService = new CurrencyService(new HttpClient(mockHttpMessageHandler.Object));

            //act
            var actual = currencyService.TransferOfCurrency(value, Currency.BelarusianRuble, Currency.Dollar);

            //assert
            Assert.Equal(Math.Round(expectedResult), Math.Round(actual));
        }

        [Fact]
        public void TransferOfCurrency_ToBelRub_ReturnExpectedValue()
        {
            //arrange
            const float value = 10;
            const int expectedResult = 20;
            var expectedRate = new Rate
            {
                CurId = (int) Currency.Dollar,
                CurName = "Доллар США",
                Date = DateTimeOffset.Now,
                CurScale = 1,
                CurOfficialRate = 2,
                CurAbbreviation = "USD"
            };

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(GetHttpResponseMessage(expectedRate)));
            var currencyService = new CurrencyService(new HttpClient(mockHttpMessageHandler.Object));

            //act
            var actual = currencyService.TransferOfCurrency(value, Currency.Dollar, Currency.BelarusianRuble);

            //assert
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void GetRate_ReturnExpectedValue()
        {
            //arrange
            var expectedRate = new Rate
            {
                CurId = (int) Currency.Dollar,
                CurName = "Доллар США",
                Date = DateTimeOffset.Now,
                CurScale = 1,
                CurOfficialRate = 2,
                CurAbbreviation = "USD"
            };
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(GetHttpResponseMessage(expectedRate)));
            var currencyService = new CurrencyService(new HttpClient(mockHttpMessageHandler.Object));

            //act
            var actual = currencyService.GetRate(Currency.Dollar);

            //assert
            Assert.Equal(expectedRate.CurId, actual.CurId);
            Assert.Equal(expectedRate.CurName, actual.CurName);
            Assert.Equal(expectedRate.Date, actual.Date);
            Assert.Equal(expectedRate.CurScale, actual.CurScale);
            Assert.Equal(expectedRate.CurOfficialRate, actual.CurOfficialRate);
            Assert.Equal(expectedRate.CurAbbreviation, actual.CurAbbreviation);
        }

        [Fact]
        public void Dispose_ExpectedExeption()
        {
            //arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(GetHttpResponseMessage(new Rate())));
            var currencyService = new CurrencyService(new HttpClient(mockHttpMessageHandler.Object));
            currencyService.Dispose();

            //act
            void Act() => currencyService.GetRate(Currency.Dollar);

            //assert
            Assert.Throws<ObjectDisposedException>((Action) Act);
        }

        private HttpClient GetMockClient()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>())
                .Returns(Task.FromResult(GetHttpResponseMessage(new Rate())));
            return new HttpClient(mockHttpMessageHandler.Object);
        }

        private static HttpResponseMessage GetHttpResponseMessage(object o)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json")
            };
        }
    }
}