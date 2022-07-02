using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Models
{
  public class Depesa
  {
    public int Id { get; set; }
    public int ReservaId { get; set; }
    public Reserva Reserva { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }


    public Depesa() { }

    public Depesa(
        int ReservaId,
        int ProdutoId,
        int QntConsumida
    )
    {
      this.ReservaId = ReservaId;
      this.ProdutoId = ProdutoId;
      this.QntConsumida = QntConsumida;

      Context db = new Context();
      db.Depesas.Add(this);
      db.SaveChanges();
    }

    public override string ToString()
    {
      return $"\n *"
          + $"\n ID: {this.Id}"
          + $"\n ReservaId: {this.ReservaId}"
          + $"\n ProdutoId: {this.ProdutoId}";
      +$"\n Quantidade Consumida: {this.QntConsumida}";
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }
      if (!Depesa.ReferenceEquals(this, obj))
      {
        return false;
      }
      Depesa it = (Depesa)obj;
      return it.Id == this.Id;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public static IEnumerable<Depesa> GetDepesas()
    {
      try
      {
        Context db = new Context();
        return (from Depesa in db.Depesas select Depesa);
      }
      catch
      {
        throw new System.Exception("Sem conexão com o banco!");
      }
    }

    public static Depesa GetDepesa(
        int ReservaId,
        int ProdutoId
    )
    {
      Context db = new Context();
      IEnumerable<Depesa> Depesas = from Depesa in db.Depesas
                                    where Depesa.ReservaId == ReservaId && Depesa.ProdutoId == ProdutoId
                                    select Depesa;

      return depesas.First();
    }

    public static Depesa GetById(int Id)
    {
      Context db = new Context();
      IEnumerable<Depesa> Depesas = from Depesa in db.Depesas
                                    where Depesa.Id == Id
                                    select Depesa;

      return Depesas.First();
    }

    public static IEnumerable<Depesa> GetByReservaId(int ReservaId)
    {
      Context db = new Context();
      return (from Depesa in db.Depesas
              where Depesa.ReservaId == ReservaId
              select Depesa);
    }

    public static void RemoverDepesa(Depesa Produto)
    {
      Context db = new Context();
      db.Depesas.Remove(Produto);
      db.SaveChanges();
    }
  }
}