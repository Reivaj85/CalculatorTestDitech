using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Calculator.Model.Entities;

namespace Calculator.DALC.Repositories.Interfaces {
    /// <summary>
    /// Operation repository.
    /// </summary>
    public interface IOperationRepository : IDisposable {
        Task<Operation> AddAsync(Operation newOperation, CancellationToken ct = default(CancellationToken));
        Task<Operation> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Operation>> GetAllAsync(CancellationToken ct = default(CancellationToken));
    }
}
