using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beca_3._0.Models
{
    public class EgresosFamiliaresBeca3
    {
        [Key]
        //Egresos familiares
        public int EgresosFamiliaresID { get; set; }


        public int SolicitudID { get; set; }

        [Display(Name = "Alimentacion:")]
        public float Alimentacion { get; set; }

        [Display(Name = "Educacion:")]
        public float Educacion { get; set; }

        [Display(Name = "Salud:")]
        public float Salud { get; set; }

        [Display(Name = "Vestimenta:")]
        public float Vestimenta { get; set; }

        [Display(Name = "Arriendo:")]
        public float Arriendo { get; set; }

        [Display(Name = "Gastos Básicos (luz, agua, etc.):")]
        public float GastosBasicos { get; set; }

        [Display(Name = "Seguros privados (casa, auto, médico):")]
        public float SeguroPrivado { get; set; }

        [Display(Name = "Cuotas de préstamos:")]
        public float CuotaPrestamos { get; set; }

        [Display(Name = "Restaurantes:")]
        public float Restaurantes { get; set; }

        [Display(Name = "Entretenimiento:")]
        public float Entretenimiento { get; set; }

        [Display(Name = "Viajes:")]
        public float Viajes { get; set; }

        [Display(Name = "Compra de equipos, muebles, etc.:")]
        public float CompraEquipos { get; set; }


        [Display(Name = "Otros egresos:")]
        public float OtrosEgresos { get; set; }

        [Display(Name = "Descuentos a rol de pagos:")]
        public float DescuentoRol { get; set; }

        //Totales
        [Display(Name = "Total Egresos:")]
        public float Totalegresos { get; set; }

        [Display(Name = "Total Otros Egresos:")]
        public float TotalOtrosEgresos { get; set; }

        [Display(Name = "Total Descuentos:")]
        public float TotalDescuentosRol { get; set; }

        public virtual AnalisisInicialBeca AnalisisInicialBeca { get; set; }
        public virtual ICollection<MasEgresosBeca3> MasEgresosBeca3 { get; set; }
        public virtual ICollection<RolDescuentoBecas3> RolDescuentoBecas3 { get; set; }
    }
}