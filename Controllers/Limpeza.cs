using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
  public class LimpezaController
  {
    public static Limpeza InserirLimpeza(
        int ReservaId,
        int ProdutoId,
        string Data_Saida
    )
    {
      if (String.IsNullOrEmpty(Data_Saida))
      {
        throw new Exception("Check-out inválido");
      }
      return new Limpeza(ReservaId, ProdutoId, Data_Saida);
    }

    public static Limpeza RemoverLimpeza(
        int Id
    )
    {
      Limpeza Limpeza = GetLimpeza(Id);
      Limpeza.RemoverLimpeza(Limpeza);
      return Limpeza;
    }
    public static IEnumerable<Limpeza> ReservaId(int Id)
    {
      return Limpeza.ReservaId(Id);
    }
    public static Limpeza GetByLimpeza(int ReservaId, int ProdutoId)
    {
      return Limpeza.GetLimpeza(ReservaId, ProdutoId);
    }
    public static Limpeza GetById(int Id)
    {
      Limpeza Limpeza = Limpeza.GetById(Id);

      return Limpeza;
    }

    public static IEnumerable<Limpeza> VisualizarLimpeza()
    {
      return Limpeza.GetLimpezas();
    }

    public static Limpeza GetLimpeza(
        int Id
    )
    {
      Limpeza Limpeza = (
          from Limpeza in Limpeza.GetLimpezas()
          where Limpeza.Id == Id
          select Limpeza
      ).First();

      if (Limpeza == null)
      {
        throw new Exception("Colaborador da limpeza não encontrada");
      }
      return Limpeza;
    }
  } // public class LimpezaController
} // namespace Controller