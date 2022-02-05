using Prova_UCDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prova_UCDB.DAO
{
    public class Contexto : DbContext
    {
        public DbSet<Pedido> Pedido { get; set; }
    }
}
