using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class TechnologicalPracticeAppContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public TechnologicalPracticeAppContext() : base("name=TechnologicalPracticeAppContext")
    {
    }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.Ecolabel> Ecolabels { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.Company> Companies { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.Demand> Demands { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.Country> Countries { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.EcoType> EcoTypes { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.Country_Ecolabel> Country_Ecolabel { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.Demand_Ecolabel> Demand_Ecolabel { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.EcoType_Ecolabel> EcoType_Ecolabel { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.PersonalCabinet> PersonalCabinets { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.Person> People { get; set; }

    public System.Data.Entity.DbSet<TechnologicalPracticeApp.Models.AccessLevel> AccessLevels { get; set; }
}
