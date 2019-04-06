using System;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Model.Entities {
    /// <summary>
    /// Operation Entitie
    /// </summary>
    public class Operation {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the type of the operation.
        /// </summary>
        /// <value>The type of the operation.</value>
        public string OperationType { get; set; }
        /// <summary>
        /// Gets or sets the calculation.
        /// </summary>
        /// <value>The calculation.</value>
        public string Calculation { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string Date { get; set; }
    }
}
