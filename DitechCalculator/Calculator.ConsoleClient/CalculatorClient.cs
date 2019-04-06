using System;
using System.Collections.Generic;
using Calculator.Model.ApiModel.Request.v1;
using Calculator.Model.ApiModel.Response.v1;
using Rest.Net;
using Rest.Net.Interfaces;

namespace Calculator.ConsoleClient {
    public class CalculatorClient {
        private readonly IRestClient _client;
        public CalculatorClient() {
            _client = new RestClient("http://localhost:5000/api/v1/Calculator");
        }

        internal string Sum(List<int> listNumbers) {
            var requestAdd = new RequestAdd {
                Addends = listNumbers.ToArray()
            };
            var result = _client.Post<ResponseAdd>("/add", requestAdd);
            return (string)result.RawData;
        }

        internal string Save() {
            throw new NotImplementedException();
        }

        internal string Sub(int minuend,int subtrahend) {
            var requestSub = new RequestSub {
                Minuend = minuend,
                Subtrahend = subtrahend
            };
            var result = _client.Post<ResponseSub>("/sub", requestSub);
            return (string)result.RawData;
        }

        internal string Div(int dividendo, int divisor) {
            var requestDiv = new RequestDiv {
                Dividend = dividendo,
                Divisor = divisor
            };
            var result = _client.Post<ResponseDiv>("/div", requestDiv);
            return (string)result.RawData;
        }

        internal string Mult(List<int> listNumbers) {
            var requestMult = new RequestMult {
                Factors = listNumbers.ToArray()
            };
            var result = _client.Post<ResponseMult>("/mult", requestMult);
            return (string)result.RawData;
        }

        internal string Sqrt(int number) {
            var requestSqrt = new RequestSqrt {
                Number = number
            };
            var result = _client.Post<ResponseSqrt>("/sqrt", requestSqrt);
            return (string)result.RawData;
        }

        internal string Query() {
            var result = _client.Get<ResponseQuery>("/journal/query");
            return (string)result.RawData;
        }
    }
}
