using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Calculator.ApiRest;
using Calculator.Model.ApiModel.Request.v1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace Calculator.UnitTest {
    public class TestCalculatorController {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestCalculatorController() {
            _server = new TestServer(new WebHostBuilder()
           .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Task_Sum_Numbers() {
            int[] numbers = { 1, 4, 6 };
            RequestAdd requestAdd = new RequestAdd() {
                Addends = numbers
            };

            string strPayload = JsonConvert.SerializeObject(requestAdd);
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/v1/calculator/add", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("{\"sum\":11}", responseString);
        }

        [Fact]
        public async Task Task_Sub_Numbers() {
            RequestSub requestSub = new RequestSub() {
                Minuend = 3,
                Subtrahend = -7
            };

            string strPayload = JsonConvert.SerializeObject(requestSub);
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/v1/calculator/sub", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("{\"difference\":-4}", responseString);
        }

        [Fact]
        public async Task Task_Mult_Numbers() {
            int[] numbers = { 8, 3, 2 };
            RequestMult requestMult = new RequestMult() {
                Factors = numbers
            };

            string strPayload = JsonConvert.SerializeObject(requestMult);
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/v1/calculator/mult", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("{\"product\":48}", responseString);
        }

        [Fact]
        public async Task Task_Div_Numbers() {
            RequestDiv requestDiv = new RequestDiv() {
                Dividend = 11,
                Divisor = 2
            };

            string strPayload = JsonConvert.SerializeObject(requestDiv);
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/v1/calculator/div", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("{\"quotient\":5,\"remainder\":1}", responseString);
        }

        [Fact]
        public async Task Task_Sqrt_Numbers() {
            RequestSqrt requestSqrt = new RequestSqrt() {
                Number=16
            };

            string strPayload = JsonConvert.SerializeObject(requestSqrt);
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/v1/calculator/sqrt", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("{\"square\":4.0}", responseString);
        }
    }
}
