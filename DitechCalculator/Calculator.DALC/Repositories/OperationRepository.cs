using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Calculator.DALC.Repositories.Interfaces;
using Calculator.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calculator.DALC.Repositories {
    /// <summary>
    /// Operation repository.
    /// </summary>
    public class OperationRepository : IOperationRepository {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Calculator.DALC.Repositories.OperationRepository"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public OperationRepository(CalculatorContext context) {
            _context = context;
        }

        /// <summary>
        /// The context.
        /// </summary>
        private readonly CalculatorContext _context;

        /// <summary>
        /// Releases all resource used by the <see cref="T:Calculator.DALC.Repositories.OperationRepository"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="T:Calculator.DALC.Repositories.OperationRepository"/>. The <see cref="Dispose"/> method leaves
        /// the <see cref="T:Calculator.DALC.Repositories.OperationRepository"/> in an unusable state. After calling
        /// <see cref="Dispose"/>, you must release all references to the
        /// <see cref="T:Calculator.DALC.Repositories.OperationRepository"/> so the garbage collector can reclaim the
        /// memory that the <see cref="T:Calculator.DALC.Repositories.OperationRepository"/> was occupying.</remarks>
        public void Dispose() {
            _context.Dispose();
        }

        /// <summary>
        /// Adds the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="newOperation">New operation.</param>
        /// <param name="ct">Ct.</param>
        public async Task<Operation> AddAsync(Operation newOperation, CancellationToken ct = default(CancellationToken)) {
            _context.Operations.Add(newOperation);
            await _context.SaveChangesAsync(ct);
            return newOperation;
        }

        /// <summary>
        /// Gets all async.
        /// </summary>
        /// <returns>The all async.</returns>
        /// <param name="ct">Ct.</param>
        public async Task<List<Operation>> GetAllAsync(CancellationToken ct = default(CancellationToken)) {
            return await _context.Operations.ToListAsync(ct);
        }

        /// <summary>
        /// Gets the by identifier async.
        /// </summary>
        /// <returns>The by identifier async.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="ct">Ct.</param>
        public async Task<Operation> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken)) {
            return await _context.Operations.FirstOrDefaultAsync(o => o.Id == id,ct);
        }
    }
}
