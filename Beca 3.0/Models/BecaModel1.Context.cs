﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Beca_3._0.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Asis_FinanEntities1 : DbContext
    {
        public Asis_FinanEntities1()
            : base("name=Asis_FinanEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int PRC_ACTUALIZA_EGRESOS3(Nullable<int> iDEgresos, Nullable<double> alimentacion, Nullable<double> educacionParam, Nullable<double> saludParam, Nullable<double> vestimentaParam, Nullable<double> arriendoParam, Nullable<double> gastosBasicosParam, Nullable<double> seguroPrivadoParam, Nullable<double> cuotaPrestamosParam, Nullable<double> restaurantesParam, Nullable<double> entretenimientoParam, Nullable<double> viajesParam, Nullable<double> compraEquiposParam, Nullable<double> otrosEgresosParam, Nullable<double> descuentoRolParam, Nullable<double> totalegresosParam)
        {
            var iDEgresosParameter = iDEgresos.HasValue ?
                new ObjectParameter("IDEgresos", iDEgresos) :
                new ObjectParameter("IDEgresos", typeof(int));
    
            var alimentacionParameter = alimentacion.HasValue ?
                new ObjectParameter("Alimentacion", alimentacion) :
                new ObjectParameter("Alimentacion", typeof(double));
    
            var educacionParamParameter = educacionParam.HasValue ?
                new ObjectParameter("EducacionParam", educacionParam) :
                new ObjectParameter("EducacionParam", typeof(double));
    
            var saludParamParameter = saludParam.HasValue ?
                new ObjectParameter("SaludParam", saludParam) :
                new ObjectParameter("SaludParam", typeof(double));
    
            var vestimentaParamParameter = vestimentaParam.HasValue ?
                new ObjectParameter("VestimentaParam", vestimentaParam) :
                new ObjectParameter("VestimentaParam", typeof(double));
    
            var arriendoParamParameter = arriendoParam.HasValue ?
                new ObjectParameter("ArriendoParam", arriendoParam) :
                new ObjectParameter("ArriendoParam", typeof(double));
    
            var gastosBasicosParamParameter = gastosBasicosParam.HasValue ?
                new ObjectParameter("GastosBasicosParam", gastosBasicosParam) :
                new ObjectParameter("GastosBasicosParam", typeof(double));
    
            var seguroPrivadoParamParameter = seguroPrivadoParam.HasValue ?
                new ObjectParameter("SeguroPrivadoParam", seguroPrivadoParam) :
                new ObjectParameter("SeguroPrivadoParam", typeof(double));
    
            var cuotaPrestamosParamParameter = cuotaPrestamosParam.HasValue ?
                new ObjectParameter("CuotaPrestamosParam", cuotaPrestamosParam) :
                new ObjectParameter("CuotaPrestamosParam", typeof(double));
    
            var restaurantesParamParameter = restaurantesParam.HasValue ?
                new ObjectParameter("RestaurantesParam", restaurantesParam) :
                new ObjectParameter("RestaurantesParam", typeof(double));
    
            var entretenimientoParamParameter = entretenimientoParam.HasValue ?
                new ObjectParameter("EntretenimientoParam", entretenimientoParam) :
                new ObjectParameter("EntretenimientoParam", typeof(double));
    
            var viajesParamParameter = viajesParam.HasValue ?
                new ObjectParameter("ViajesParam", viajesParam) :
                new ObjectParameter("ViajesParam", typeof(double));
    
            var compraEquiposParamParameter = compraEquiposParam.HasValue ?
                new ObjectParameter("CompraEquiposParam", compraEquiposParam) :
                new ObjectParameter("CompraEquiposParam", typeof(double));
    
            var otrosEgresosParamParameter = otrosEgresosParam.HasValue ?
                new ObjectParameter("OtrosEgresosParam", otrosEgresosParam) :
                new ObjectParameter("OtrosEgresosParam", typeof(double));
    
            var descuentoRolParamParameter = descuentoRolParam.HasValue ?
                new ObjectParameter("DescuentoRolParam", descuentoRolParam) :
                new ObjectParameter("DescuentoRolParam", typeof(double));
    
            var totalegresosParamParameter = totalegresosParam.HasValue ?
                new ObjectParameter("TotalegresosParam", totalegresosParam) :
                new ObjectParameter("TotalegresosParam", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PRC_ACTUALIZA_EGRESOS3", iDEgresosParameter, alimentacionParameter, educacionParamParameter, saludParamParameter, vestimentaParamParameter, arriendoParamParameter, gastosBasicosParamParameter, seguroPrivadoParamParameter, cuotaPrestamosParamParameter, restaurantesParamParameter, entretenimientoParamParameter, viajesParamParameter, compraEquiposParamParameter, otrosEgresosParamParameter, descuentoRolParamParameter, totalegresosParamParameter);
        }
    
        public virtual int PRC_SOLI_INICIAL_BECA3(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PRC_SOLI_INICIAL_BECA3", emailParameter);
        }
    }
}
