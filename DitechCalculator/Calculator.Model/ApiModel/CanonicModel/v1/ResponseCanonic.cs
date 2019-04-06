namespace Calculator.Model.ApiModel.CanonicModel.v1 {
    /// <summary>
    /// Response canonic.
    /// </summary>
    public class ResponseCanonic {
        /// <summary>
        /// Codigo de error
        /// </summary>
        /// <value>The error code.</value>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Estado del error
        /// </summary>
        /// <value>The error status.</value>
        public int ErrorStatus { get; set; }

        /// <summary>
        /// Mensaje del error
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage { get; set; }
    }
}
