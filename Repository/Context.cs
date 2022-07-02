using Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
  public class Context : DbContext
  {
    public DbSet<Hospede> Hospedes { get; set; }

    public DbSet<Colaborador> Colaboradores { get; set; }
    
    //public DbSet<Reserva> Reservas { get; set; }

    public DbSet<Produto> Produtoss { get; set; }

    public DbSet<Despesa> Despesas { get; set; }

    public DbSet<Limpeza> Limpezas { get; set; }

   
    // Heroku Config
    //"Server=us-cdbr-east-05.cleardb.net;User Id=b4a4154b57bdb4;Database=heroku_96f4f1c4546dac0;Pwd=b857f5e2"

    // Local Config
    //"Server=localhost;User Id=root;Database=habbo-hotel"
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql("Server=localhost;User Id=root;Database=habbo-hotel");
  }
}