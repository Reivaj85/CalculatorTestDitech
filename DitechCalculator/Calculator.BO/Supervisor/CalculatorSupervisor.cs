using Calculator.BO.Interfaces;
using Calculator.DALC.Repositories.Interfaces;

namespace Calculator.BO.Supervisor {
    /// <summary>
    /// Calculator supervisor.
    /// </summary>
    public partial class CalculatorSupervisor : ICalculatorSupervisor {
        private readonly IOperationRepository _operationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Calculator.BO.Supervisor.CalculatorSupervisor"/> class.
        /// </summary>
        public CalculatorSupervisor() {
        }

        public CalculatorSupervisor(IOperationRepository operationRepository) {
            _operationRepository = operationRepository;
        }
    }
}
