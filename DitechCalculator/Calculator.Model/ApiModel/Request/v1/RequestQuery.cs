using System.ComponentModel.DataAnnotations;

namespace Calculator.Model.ApiModel.Request.v1 {
    /// <summary>
    /// Modelo de la solicitud del query de las operaciones
    /// </summary>
    public class RequestQuery {
        /// <summary>
        /// Corresponde al id de la operacion
        /// </summary>
        [Required(ErrorMessage = "El id es obligatorio")]
        public int Id { get; set; }
    }
}
