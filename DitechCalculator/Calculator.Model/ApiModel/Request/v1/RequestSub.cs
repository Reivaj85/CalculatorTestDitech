using System.ComponentModel.DataAnnotations;

namespace Calculator.Model.ApiModel.Request.v1 {
    public class RequestSub {
        [Required(ErrorMessage = "El minuend es obligatorio para realizar la resta.")]
        public int Minuend { get; set; }
        [Required(ErrorMessage = "El subtrahend es obligatorio para realizar la resta.")]
        public int Subtrahend { get; set; }
    }
}
