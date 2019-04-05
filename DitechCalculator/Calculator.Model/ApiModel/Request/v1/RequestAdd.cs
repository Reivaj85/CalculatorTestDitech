﻿using System.ComponentModel.DataAnnotations;

namespace Calculator.Model.ApiModel.Request.v1 { 
    public class RequestAdd {
        [Required(ErrorMessage = "El arreglo de números enteros es obligatorio")]
        [MinLength(2, ErrorMessage = "El arreglo debe contener por lo menos 2 numeros para realizar la suma de manera correcta")]
        [MaxLength(100, ErrorMessage = "El arreglo no debe contener mas de 100 posiciones ya que se ve comprometido el performance del servicio.")]
        public int[] Addends { get; set; }
    }
}
