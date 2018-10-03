using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beca_3._0.Models
{
    public class IngresosFamiliaresBecas3
    {
        [Key]
        public int IngresosFamiliaresID { get; set; }

        [Display(Name = "Solicitud:")]
        public int SolicitudID { get; set; }


        [Display(Name = "Sueldo Bruto Padre:")]
        //[Range(0.00, 99.00, ErrorMessage = "Solo valores numéricos menores de 99")]
        public float sueldoBrutoPadre { get; set; }

        [Display(Name = "Ingresos Adicionales Padre:")]        
        public float IngresosAdicionalesPadre { get; set; }
        [Display(Name = "¿Cuánto recibe mensualmente?:")]        
        public float InversionesPadre { get; set; }
        [Display(Name = "¿Cuánto recibe mensualmente?:")]        
        public float ArriendoPropiedadesPadre { get; set; }

        //[Required(ErrorMessage = "Ingrese un valor en este campo")]
        public string SioNoRecibeAdicionalPadre { get; set; }
        //[Required(ErrorMessage = "Ingrese un valor en este campo")]
        public string SioNoTrabajaRelDependenciaPadre { get; set; }



        //Ingresos de la madre
        [Display(Name = "Sueldo Bruto Madre:")]
        public float sueldoBrutoMadre { get; set; }
        [Display(Name = "Ingresos Adicionales Madre:")]
        public float IngresosAdicionalesMadre { get; set; }
        public float InversionesMadre { get; set; }
        public float ArriendoPropiedadesMadre { get; set; }

        //[Required(ErrorMessage = "Ingrese un valor en este campo")]
        public string SioNoRecibeAdicionalMadre { get; set; }
        //[Required(ErrorMessage = "Ingrese un valor en este campo")]
        public string SioNoTrabajaRelDependenciaMadre { get; set; }

        //Totales
        
        [Display(Name = "Total Ingresos Padre:")]        
        public float TotalIngresosPadre { get; set; }        
        [Display(Name = "Total Ingresos Madre:")]        
        public float TotalIngresosMadre { get; set; }




        public virtual AnalisisInicialBeca AnalisisInicialBeca { get; set; }
        
    }
}