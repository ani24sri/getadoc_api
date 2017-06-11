using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace getadoc_api.Models
{
    public class getadocDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public getadocDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Appointments> Appointments { get; set; }

        public System.Data.Entity.DbSet<getadoc_api.Models.diseaseData> diseaseDatas { get; set; }

        public System.Data.Entity.DbSet<getadoc_api.Models.Patients> Patients { get; set; }
    }
}
