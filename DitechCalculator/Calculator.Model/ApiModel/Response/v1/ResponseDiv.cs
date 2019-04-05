namespace Calculator.Model.ApiModel.Response.v1 {
    /// <summary>
    /// Modelo de la respuesta de la division
    /// </summary>
    public class ResponseDiv {
        /// <summary>
        /// Corresponde al el resultado de la operacion aritmetica
        /// </summary>
        /// <value>The quotient.</value>
        public int Quotient { get; set; }

        /// <summary>
        /// Corresponde a los restos de la operacion aritmetica
        /// </summary>
        /// <value>The remainder.</value>
        public int Remainder { get; set; }
    }
}
