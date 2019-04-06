using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calculator.BO.Interfaces;
using Calculator.Model.ApiModel.Request.v1;
using Calculator.Model.ApiModel.Response.v1;
using Calculator.Model.Converters;

namespace Calculator.BO.Supervisor {
    public partial class CalculatorSupervisor : ICalculatorSupervisor {


        public async Task<ResponseQuery> GetAllOperationAsync(CancellationToken ct = default(CancellationToken)) {
            var operations = OperationConverter.ConvertList(await _operationRepository.GetAllAsync(ct));
            return operations;
        }

        public async Task<ResponseQuery> GetOperationByIdAsync(string id, CancellationToken ct = default(CancellationToken)) {
            var operation = OperationConverter.ConvertList(await _operationRepository.GetByIdAsync(id,ct));
            return operation;
        }

        public async Task<ResponseAdd> AddAsync(RequestAdd requestAdd, bool save, string id,CancellationToken ct = default(CancellationToken)) {
            var resAdd = requestAdd.Addends.ToList().Sum();
            if (save) {
                await _operationRepository.AddAsync(new Model.Entities.Operation() {
                    IdHeader = id,
                    OperationType = "Sum",
                    Date = DateTime.Now.ToString(),
                    Calculation = $"{string.Join(" + ", requestAdd.Addends)} = {resAdd}"
                });
            }
            return new ResponseAdd() {
                Sum = resAdd
            };
        }

        public async Task<ResponseDiv> DivAsync(RequestDiv requestDiv, bool save, string id, CancellationToken ct = default(CancellationToken)) {
            var resDiv = Math.Abs(requestDiv.Dividend) / Math.Abs(requestDiv.Divisor);
            var remDiv = Math.Abs(requestDiv.Dividend) % Math.Abs(requestDiv.Divisor);
            if (save) {
                await _operationRepository.AddAsync(new Model.Entities.Operation() {
                    IdHeader = id,
                    OperationType = "Div",
                    Date = DateTime.Now.ToString(),
                    Calculation = $"{Math.Abs(requestDiv.Dividend)} / ({ Math.Abs(requestDiv.Divisor)}) = {resDiv}"
                });
                await _operationRepository.AddAsync(new Model.Entities.Operation() {
                    IdHeader = id,
                    OperationType = "Div",
                    Date = DateTime.Now.ToString(),
                    Calculation = $"{Math.Abs(requestDiv.Dividend)} % ({ Math.Abs(requestDiv.Divisor)}) = {remDiv}"
                });
            }
            return new ResponseDiv() {
                Quotient = resDiv,
                Remainder = remDiv
            };
        }

        public async Task<ResponseMult> MultAsync(RequestMult requestMult, bool save, string id, CancellationToken ct = default(CancellationToken)) {
            var resMult = 1;
            foreach(var num in requestMult.Factors) {
                resMult *= num;
            }
            if (save) {
                await _operationRepository.AddAsync(new Model.Entities.Operation() {
                    IdHeader = id,
                    OperationType = "Mult",
                    Date = DateTime.Now.ToString(),
                    Calculation = $"{string.Join(" * ", requestMult.Factors)} = {resMult}"
                });
            }
            return new ResponseMult() {
                Product = resMult
            };
        }

        public Task<ResponseSqrt> SqrtAsync(RequestAdd requestSqrt, bool save, string id, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseSub> SubAsync(RequestSub requestSub, bool save, string id, CancellationToken ct = default(CancellationToken)) {
            var resSub = Math.Abs(requestSub.Minuend) - Math.Abs(requestSub.Subtrahend);
            if (save) {
                await _operationRepository.AddAsync(new Model.Entities.Operation() {
                    IdHeader = id,
                    OperationType = "Sub",
                    Date = DateTime.Now.ToString(),
                    Calculation = $"{requestSub.Minuend} - ({requestSub.Subtrahend}) = {resSub}"
                });
            }
            return new ResponseSub() {
                Difference = resSub
            };
        }
    }
}
