using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Models
{
  public class Limpeza
  {
    public int Id { get; set; }
    public int ReservaId { get; set; }
    public Reserva Reserva { get; set; }
    public int ColaboradorId { get; set; }
    public Colaborador Colaborador { get; set; }


    public Limpeza() { }

    public Limpeza(
        int ReservaId,
        int ColaboradorId,
        string Data_Saida
    )
    {
      this.ReservaId = ReservaId;
      this.ColaboradorId = ColaboradorId;
      this.Data_Saida = Data_Saida;

      Context db = new Context();
      db.Limpezas.Add(this);
      db.SaveChanges();
    }

    public override string ToString()
    {
      return $"\n *"
          + $"\n ID: {this.Id}"
          + $"\n ReservaId: {this.ReservaId}"
          + $"\n ColaboradorId: {this.ColaboradorId}";
      +$"\n Check-out: {this.Data_Saida}";
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }
      if (!Limpeza.ReferenceEquals(this, obj))
      {
        return false;
      }
      Limpeza it = (Limpeza)obj;
      return it.Id == this.Id;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public static IEnumerable<Limpeza> GetLimpezas()
    {
      try
      {
        Context db = new Context();
        return (from Limpeza in db.Limpezas select Limpeza);
      }
      catch
      {
        throw new System.Exception("Sem conexão com o banco!");
      }
    }

    public static Limpeza GetLimpeza(
        int ReservaId,
        int ColaboradorId
    )
    {
      Context db = new Context();
      IEnumerable<Limpeza> Limpezas = from Limpeza in db.Limpezas
                                      where Limpeza.ReservaId == ReservaId && Limpeza.ColaboradorId == ColaboradorId
                                      select Limpeza;

      return Limpezas.First();
    }

    public static Limpeza GetById(int Id)
    {
      Context db = new Context();
      IEnumerable<Limpeza> Limpezas = from Limpeza in db.Limpezas
                                      where Limpeza.Id == Id
                                      select Limpeza;

      return Limpezas.First();
    }

    public static IEnumerable<Limpeza> GetByReservaId(int ReservaId)
    {
      Context db = new Context();
      return (from Limpeza in db.Limpezas
              where Limpeza.ReservaId == ReservaId
              select Limpeza);
    }

    public static void RemoverLimpeza(Limpeza Colaborador)
    {
      Context db = new Context();
      db.Limpezas.Remove(Colaborador);
      db.SaveChanges();
    }
  }
}