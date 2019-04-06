using System.ComponentModel.DataAnnotations;

namespace Calculator.Model.ApiModel.Request.v1 {
    /// <summary>
    /// Modelo de la solicitud de la operacion division
    /// </summary>
    public class RequestDiv {
        /// <summary>
        /// Corresponde al numero dividendo de la operacion aritmetica.
        /// </summary>
        /// <value>The dividend.</value>
        [Required(ErrorMessage = "El numero dividend es obligatorio")]
        public int Dividend { get; set; }

        /// <summary>
        /// Corresponde al numero divisor de la operacion aritmetica
        /// </summary>
        /// <value>The divisor.</value>
        [Required(ErrorMessage = "El numero divisor es obligatorio")]
        public int Divisor { get; set; }
    }
}
