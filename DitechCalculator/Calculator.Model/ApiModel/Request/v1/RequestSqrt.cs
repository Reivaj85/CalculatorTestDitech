using System.ComponentModel.DataAnnotations;

namespace Calculator.Model.ApiModel.Request.v1 {
    /// <summary>
    /// Modelo de la solicitud de la raiz cuadrada
    /// </summary>
    public class RequestSqrt {
        /// <summary>
        /// Numero al cual se le calcula la raiz cuadrada
        /// </summary>
        [Required(ErrorMessage = "El numero es obligatorio")]
        public int Number { get; set; }
    }
}
