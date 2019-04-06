using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Calculator.Model.ApiModel.Response.v1 {
    /// <summary>
    /// Response query.
    /// </summary>
    [DataContract]
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
        [DataMember(Name = "operations")]
        public List<Operation> Operations { get; set; }
    }

    /// <summary>
    /// Operation.
    /// </summary>
    [DataContract]
    public class Operation {
        /// <summary>
        /// identificador de la operacion
        /// </summary>
        /// <value>The identifier.</value>
        //[DataMember(Name = "id")]
        public string Id { get; set; }
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
        [DataMember(Name = "calculation")]
        public string Calculation { get; set; }

        /// <summary>
        /// Fecha de la operacion
        /// </summary>
        /// <value>The date.</value>
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
    }
}
