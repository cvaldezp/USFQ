using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beca_3._0.Models
{
    public class RolDescuentoBecas3
    {
        [Key]
        public int DescuentoRolID { get; set; }

        [Display(Name = "Egresos:")]
        public int EgresosFamiliaresID { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string Descripcion { get; set; }


        [Display(Name = "Valor:")]
        [Required(ErrorMessage = "You must enter {0}")]
        public float ValorOtrosEgresos { get; set; }

        public virtual EgresosFamiliaresBeca3 EgresosFamiliaresBeca3 { get; set; }
    }
}