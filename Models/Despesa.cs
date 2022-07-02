using System.Collections.Generic;
using System.Linq;
using Repository;
using System;


namespace Models
{
  public class Despesa
  {
    public int Id { get; set; }
    public int ReservaId { get; set; }
    public Reserva Reserva { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int Qnt_Consumida { get; set; }


    public Despesa() { }

    public Despesa(
        int ReservaId,
        int ProdutoId,
        int Qnt_Consumida
    )
    {
      this.ReservaId = ReservaId;
      this.ProdutoId = ProdutoId;
      this.Qnt_Consumida = Qnt_Consumida;

      Context db = new Context();
      db.Despesas.Add(this);
      db.SaveChanges();
    }

    public override string ToString()
    {
      return $"\n *"
          + $"\n ID: {this.Id}"
          + $"\n ReservaId: {this.ReservaId}"
          + $"\n ProdutoId: {this.ProdutoId}"
      + $"\n Quantidade Consumida: {this.Qnt_Consumida}";
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }
      if (!Despesa.ReferenceEquals(this, obj))
      {
        return false;
      }
      Despesa it = (Despesa)obj;
      return it.Id == this.Id;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public static IEnumerable<Despesa> GetDespesas()
    {
      try
      {
        Context db = new Context();
        return (from Despesa in db.Despesas select Despesa);
      }
      catch
      {
        throw new System.Exception("Sem conexão com o banco!");
      }
    }

    public static Despesa GetDespesa(
        int ReservaId,
        int ProdutoId
    )
    {
      Context db = new Context();
      IEnumerable<Despesa> Despesas = from Despesa in db.Despesas
                                      where Despesa.ReservaId == ReservaId && Despesa.ProdutoId == ProdutoId
                                      select Despesa;

      return Despesas.First();
    }

    public static Despesa GetById(int Id)
    {
      Context db = new Context();
      IEnumerable<Despesa> Despesas = from Despesa in db.Despesas
                                      where Despesa.Id == Id
                                      select Despesa;

      return Despesas.First();
    }

    public static IEnumerable<Despesa> GetByReservaId(int ReservaId)
    {
      Context db = new Context();
      return (from Despesa in db.Despesas
              where Despesa.ReservaId == ReservaId
              select Despesa);
    }

    public static void RemoverDespesa(Despesa Produto)
    {
      Context db = new Context();
      db.Despesas.Remove(Produto);
      db.SaveChanges();
    }
  }
}