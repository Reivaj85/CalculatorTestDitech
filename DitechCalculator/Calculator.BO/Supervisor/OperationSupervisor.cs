using System;
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

        public async Task<ResponseQuery> GetOperationByIdAsync(int id, CancellationToken ct = default(CancellationToken)) {
            var operation = OperationConverter.Convert(await _operationRepository.GetByIdAsync(id,ct));
            return operation;
        }

        public Task<ResponseAdd> AddAsync(RequestAdd requestAdd, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDiv> DivAsync(RequestDiv requestDiv, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }

        public Task<ResponseMult> MultAsync(RequestMult requestMult, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }

        public Task<ResponseSqrt> SqrtAsync(RequestAdd requestSqrt, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }

        public Task<ResponseSub> SubAsync(RequestSub requestSub, CancellationToken ct = default(CancellationToken)) {
            throw new System.NotImplementedException();
        }
    }
}
