using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beca_3._0.Models
{
    public class ImpuestoRentaBeca3
    {
        [Key]
        //Datos del Padre
        public int ImpuestoRentaID { get; set; }

        [Display(Name = "Solicitud:")]
        public int SolicitudID { get; set; }

        [Display(Name = "Formulario 102 Padre:")]
        public float Formulario102Padre { get; set; }

        [Display(Name = "Formulario 104 Padre:")]
        public float Formulario104Padre { get; set; }

        [Display(Name = "Comprobante de Retencion 107 Padre:")]
        public float Comprobante107Padre { get; set; }

        //Datos de la madre
        [Display(Name = "Formulario 102 Madre:")]
        public float Formulario102Madre { get; set; }

        [Display(Name = "Formulario 104 Madre:")]
        public float Formulario104Madre { get; set; }

        [Display(Name = "Comprobante de Retencion 107 Madre:")]
        public float Comprobante107Madre { get; set; }
        //Totales
        public float TotalFormularioPadre { get; set; }
        public float TotalFormularioMadre { get; set; }

        public virtual AnalisisInicialBeca AnalisisInicialBeca { get; set; }
    }
}