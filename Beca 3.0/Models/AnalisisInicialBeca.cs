using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beca_3._0.Models
{
    public class AnalisisInicialBeca
    {
        [Key]
        [Display(Name = "Solucitud:")]
        public int SolicitudID { get; set; }


        [Display(Name = "Cédula:")]
        public string Cedula { get; set; }

        [Display(Name = "Nombres Completos:")]
        public string NombresCompletosEstudiante { get; set; }


        [Display(Name = "Fecha de Solicitud:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy/MM/dd}")]        
        public string FechasolicitudBeca { get; set; }



        [Display(Name = "Email:")]
        //[Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.EmailAddress)]
        public string EmailEstudiante { get; set; }

        //Datos Representante Financiero
        [Display(Name = "Nombres:")]
        public string NombreRepresentanteFinan { get; set; }

        [Display(Name = "Apellidos:")]
        public string ApellidoRepresentanteFinan { get; set; }

        [Display(Name = "Nacionalidad:")]
        public string NacionalidadRepresentanteFinan { get; set; }

        [Display(Name = "Estado Civil:", Prompt = "Estado Civil")]
        public string EstadoCivilRF { get; set; }

        [Display(Name = "¿Su residencia es propia o alquilada?:")]
        public string ResidenciaPropia { get; set; }

        [Display(Name = "Genero:")]
        public string GeneroRF { get; set; }

        [Display(Name = "Barrio o Sector:")]
        public string SectorRepresentanteFinan { get; set; }

        [Display(Name = "Ciudad:")]
        public string CiudadRepresentanteFinan { get; set; }

        [Display(Name = "Teléfono Móvil:")]
        public string TelefonoCelularRepresentanteFinan { get; set; }

        [Display(Name = "Teléfono Fijo:")]
        public string TelefonoConvencionalRepresentanteFinan { get; set; }

        [Display(Name = "Lugar Trabajo:")]
        public string LugarTrabajoActualRF { get; set; }

        [Display(Name = "Cargo:")]
        public string CargoTrabajoActualRF { get; set; }

        [Display(Name = "Dirección Trabajo:")]
        [DataType(DataType.MultilineText)]
        public string DireccionTrabajoRF { get; set; }

        [Display(Name = "Número de Años Laborales:")]
        [Range(1, 100, ErrorMessage = "A number between 1 and 100.")]
        public int NumeroAniosTrabajoActualRF { get; set; }

        [Display(Name = "Nivel de educación culminada RF:")]
        public string NivelEducacionRF { get; set; }

        //conyuge
        [Display(Name = "Nombre:")]
        public string NombreConyuge { get; set; }

        [Display(Name = "Apellido:")]
        public string ApellidoConyuge { get; set; }

        [Display(Name = "Nacionalidad:")]
        public string NacionalidadConyuge { get; set; }

        [Display(Name = "Estado Civil:")]
        public string EstadoCivilConyuge { get; set; }

        [Display(Name = "¿Su residencia es propia o alquilada?:")]
        public string ResidenciaPropiaConyuge { get; set; }


        [Display(Name = "Genero:")]
        public string GeneroConyuge { get; set; }

        [Display(Name = "Barrio o Sector:")]
        public string SectorConyuge { get; set; }

        [Display(Name = "Ciudad:")]
        public string CiudadConyuge { get; set; }

        [Display(Name = "Teléfono Móvil:")]
        public string TelefonoCelularConyuge { get; set; }

        [Display(Name = "Teléfono Fijo:")]
        public string TelefonoConvencionalConyuge { get; set; }

        [Display(Name = "Lugar Trabajo:")]
        public string LugarTrabajoActualConyuge { get; set; }

        [Display(Name = "Cargo:")]
        public string CargoTrabajoActualConyuge { get; set; }

        [Display(Name = "dirección Trabajo:")]
        public string DireccionTrabajoConyuge { get; set; }

        [Display(Name = "Número de Años Laborales:")]
        [Range(1, 100, ErrorMessage = "A number between 1 and 100.")]
        public int NumeroAniosTrabajoActualConyuge { get; set; }

        [Display(Name = "Educación culminada?:")]
        public string NivelEducacionCulminadaConyuge { get; set; }

        [Display(Name = "Número Hijos:")]
        [Range(1, 15, ErrorMessage = "A number between 1 and 15.")]
        public int NumeroHijosConyuge { get; set; }


        [Display(Name = "Depende de Alguien más sus Ingresos?:")]
        public string DependeAlguienMas { get; set; }

        [Display(Name = "De Quién?:")]
        public string NombresDependientesAdicionales { get; set; }

        [Display(Name = "Comentarios:")]
        [DataType(DataType.MultilineText)]
        public string ComentariosAicionales { get; set; }

        [Display(Name = "Estado:")]
        public string Estado { get; set; }

        [Display(Name = "Monto para Inversion:")]
        public float MontoInterv { get; set; }

        [Display(Name = "Número de Años Laborales:")]
        public string AniosTrabajoActualRF { get; set; }

        [Display(Name = "Número de Años Laborales:")]
        public string AniosTrabajoActualConyuge { get; set; }

        [Display(Name = "Referencia Familiar:")]
        public string RefFamiliarRepFinanciero { get; set; }

        [Display(Name = "Codigo Banner:")]
        public string CodBanner { get; set; }

        public virtual ICollection<HijoDependienteBeca3> HijoDependienteBeca3 { get; set; }
    }
}