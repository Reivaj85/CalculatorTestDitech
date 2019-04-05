using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Calculator.Model.ApiModel.Response.v1 {
    /// <summary>
    /// Response query.
    /// </summary>
    public class ResponseQuery {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Calculator.Model.ApiModel.Response.v1.ResponseQuery"/> class.
        /// </summary>
        public ResponseQuery() {
            Operations = new List<Operation>();
        }
        /// <summary>
        /// Lista de operaciones
        /// </summary>
        /// <value>The operations.</value>
        public List<Operation> Operations { get; set; }
    }

    /// <summary>
    /// Operation.
    /// </summary>
    public class Operation {
        /// <summary>
        /// Tipo de operacion
        /// </summary>
        /// <value>The type operation.</value>
        [DataMember(Name = "operation")]
        public string TypeOperation { get; set; }

        /// <summary>
        /// Formula de la operacion
        /// </summary>
        /// <value>The calculation.</value>
        public string Calculation { get; set; }

        /// <summary>
        /// Fecha de la operacion
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }
    }
}
