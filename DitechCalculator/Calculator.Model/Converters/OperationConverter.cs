using System;
using System.Collections.Generic;
using Calculator.Model.ApiModel.Response.v1;

namespace Calculator.Model.Converters {
    /// <summary>
    /// Operation converter.
    /// </summary>
    public static class OperationConverter {
        /// <summary>
        /// Convert the specified operation.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="operation">Operation.</param>
        public static ResponseQuery Convert(Entities.Operation operation) {
            if (operation == null) return null;
            var responseQuery = new ResponseQuery();
            responseQuery.Operations.Add(ConvertResponse(operation));
            return responseQuery;
        }

        /// <summary>
        /// Converts the list.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="operations">Operations.</param>
        public static ResponseQuery ConvertList(IEnumerable<Entities.Operation> operations) {
            if (operations == null) return null;
            var responseQuery = new ResponseQuery();
            foreach (var operation in operations) {
                responseQuery.Operations.Add(ConvertResponse(operation));
            }
            return responseQuery;
        }

        /// <summary>
        /// Converts the response.
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="operation">Operation.</param>
        private static Operation ConvertResponse(Entities.Operation operation) {
            return new Operation() {
                Id = operation.IdHeader,
                TypeOperation = operation.OperationType,
                Calculation = operation.Calculation,
                Date = DateTime.Parse(operation.Date)
            };
        }
    }
}
