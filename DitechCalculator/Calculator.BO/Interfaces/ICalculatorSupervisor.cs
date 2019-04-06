using System.Threading;
using System.Threading.Tasks;
using Calculator.Model.ApiModel.Request.v1;
using Calculator.Model.ApiModel.Response.v1;

namespace Calculator.BO.Interfaces {
    public interface ICalculatorSupervisor {
        Task<ResponseQuery> GetAllOperationAsync(CancellationToken ct = default(CancellationToken));
        Task<ResponseQuery> GetOperationByIdAsync(string id, CancellationToken ct = default(CancellationToken));
        Task<ResponseAdd> AddAsync(RequestAdd requestAdd, bool save, string id,CancellationToken ct = default(CancellationToken));
        Task<ResponseSub> SubAsync(RequestSub requestSub, bool save, string id,CancellationToken ct = default(CancellationToken));
        Task<ResponseMult> MultAsync(RequestMult requestMult, bool save, string id,CancellationToken ct = default(CancellationToken));
        Task<ResponseDiv> DivAsync(RequestDiv requestDiv, bool save, string id,CancellationToken ct = default(CancellationToken));
        Task<ResponseSqrt> SqrtAsync(RequestSqrt requestSqrt, bool save, string id,CancellationToken ct = default(CancellationToken));
    }
}
