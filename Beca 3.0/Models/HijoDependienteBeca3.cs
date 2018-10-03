using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beca_3._0.Models
{
    public class HijoDependienteBeca3
    {
        [Key]
        public int HijoDependienteID { get; set; }

        [Display(Name = "Solicitud:")]
        public int SolicitudID { get; set; }

        [Display(Name = "Nombres y Apellidos:")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string NombresApellidos { get; set; }

        [Display(Name = "Institución en la que Esdtudia:")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string InstitucionEsdudia { get; set; }

        [Display(Name = "Costo anual de colegiatura del último año:")]
        [Required(ErrorMessage = "You must enter {0}")]
        public float CostoAnualEstudio { get; set; }



        public virtual AnalisisInicialBeca AnalisisInicialBeca { get; set; }
    }
}