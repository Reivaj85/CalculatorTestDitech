using System.Threading;
using Calculator.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calculator.DALC {
    /// <summary>
    /// Calculator context.
    /// </summary>
    public class CalculatorContext : DbContext{
        /// <summary>
        /// The instance count.
        /// </summary>
        public static long InstanceCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Calculator.DALC.CalculatorContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public CalculatorContext(DbContextOptions options) : base(options)
            => Interlocked.Increment(ref InstanceCount);

        /// <summary>
        /// Gets or sets the operations.
        /// </summary>
        /// <value>The operations.</value>
        public DbSet<Operation> Operations { get; set; }
    }
}
