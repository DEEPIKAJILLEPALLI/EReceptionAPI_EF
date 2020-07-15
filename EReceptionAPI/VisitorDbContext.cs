using EReceptionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace EReceptionAPI
{
    public class VisitorDbContext:DbContext
    {
        public VisitorDbContext() : base("name=VisitorDbContextConnectionString")
        {

        }
        public DbSet<Visitor> Visitors { get; set; }

        
    }
}