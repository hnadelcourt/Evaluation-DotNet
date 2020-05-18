using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Evaluation.Models
{
   public class BddContext : DbContext
   {
       public DbSet<Client> Clients { get; set; }
   }
    
}