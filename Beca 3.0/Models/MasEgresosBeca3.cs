using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beca_3._0.Models
{
    public class MasEgresosBeca3
    {
        [Key]
        public int OtroEgresoID { get; set; }

        
        public int EgresosFamiliaresID { get; set; }

        [Display(Name = "Descripcion:")]        
        public string Descripcion { get; set; }


        [Display(Name = "Valor:")]        
        public float ValorOtrosEgresos { get; set; }


        
        public virtual EgresosFamiliaresBeca3 EgresosFamiliaresBeca3 { get; set; }
    }
}