using System.Threading;
using System.Threading.Tasks;
using Calculator.Model.ApiModel.Request.v1;
using Calculator.Model.ApiModel.Response.v1;

namespace Calculator.BO.Interfaces {
    public interface ICalculatorSupervisor {
        Task<ResponseQuery> GetAllOperationAsync(CancellationToken ct = default(CancellationToken));
        Task<ResponseQuery> GetOperationByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<ResponseAdd> AddAsync(RequestAdd requestAdd, CancellationToken ct = default(CancellationToken));
        Task<ResponseSub> SubAsync(RequestSub requestSub, CancellationToken ct = default(CancellationToken));
        Task<ResponseMult> MultAsync(RequestMult requestMult, CancellationToken ct = default(CancellationToken));
        Task<ResponseDiv> DivAsync(RequestDiv requestDiv, CancellationToken ct = default(CancellationToken));
        Task<ResponseSqrt> SqrtAsync(RequestAdd requestSqrt, CancellationToken ct = default(CancellationToken));
    }
}
