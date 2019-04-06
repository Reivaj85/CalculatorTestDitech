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
            var operation = OperationConverter.Convert(await _operationRepository.GetByIdAsync(id,ct));
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

        public Task<ResponseDiv> DivAsync(RequestDiv requestDiv, bool save, string id, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }

        public Task<ResponseMult> MultAsync(RequestMult requestMult, bool save, string id, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }

        public Task<ResponseSqrt> SqrtAsync(RequestAdd requestSqrt, bool save, string id, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }

        public Task<ResponseSub> SubAsync(RequestSub requestSub, bool save, string id, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }
    }
}
