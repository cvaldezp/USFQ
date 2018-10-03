using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Beca_3._0.Models
{
    public class SolicitudInicialContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SolicitudInicialContext() : base("name=SolicitudInicialContext")
        {
        }

        public System.Data.Entity.DbSet<Beca_3._0.Models.AnalisisInicialBeca> AnalisisInicialBecas { get; set; }

        public System.Data.Entity.DbSet<Beca_3._0.Models.HijoDependienteBeca3> HijoDependienteBeca3 { get; set; }

        public System.Data.Entity.DbSet<Beca_3._0.Models.IngresosFamiliaresBecas3> IngresosFamiliaresBecas3 { get; set; }

        public System.Data.Entity.DbSet<Beca_3._0.Models.EgresosFamiliaresBeca3> EgresosFamiliaresBeca3 { get; set; }

        public System.Data.Entity.DbSet<Beca_3._0.Models.ImpuestoRentaBeca3> ImpuestoRentaBeca3 { get; set; }

        public System.Data.Entity.DbSet<Beca_3._0.Models.MasEgresosBeca3> MasEgresosBeca3 { get; set; }

        public System.Data.Entity.DbSet<Beca_3._0.Models.RolDescuentoBecas3> RolDescuentoBecas3 { get; set; }
    }
}
