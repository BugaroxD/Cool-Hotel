using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
  public class QuartoController
  {
    public static Quarto IncluirQuarto(int NumeroQuarto, int Andar, string Descricao, string Reservado, double Valor)
    {
      if (String.IsNullOrEmpty(Descricao))
      {
        throw new Exception("Descrição inválida");
      }

      if (String.IsNullOrEmpty(Reservado))
      {
        throw new Exception("Status de reserva inválido");
      }

      return new Quarto(NumeroQuarto, Andar, Descricao, Reservado, Valor);
    }

    public static Quarto AlterarQuarto(int Id, int NumeroQuarto, int Andar, string Descricao, string Reservado, double Valor)
    {
      Quarto quarto = GetQuarto(Id);

      if (!String.IsNullOrEmpty(Descricao))
      {
        Descricao = quarto.Descricao;
      }

      if (!String.IsNullOrEmpty(Reservado))
      {
        Reservado = quarto.Reservado;
      }

      Quarto.AlterarQuarto(Id, NumeroQuarto, Andar, Descricao, Reservado, Valor);

      return quarto;
    }

    public static Quarto AtualizaReservado(int Id, string Reservado)
    {
      Quarto quartoReservado = GetQuartoReservado(Reservado);


      if (!String.IsNullOrEmpty(Reservado))
      {
        Reservado = quarto.Reservado;
      }

      Quarto.AltualizaReservado(Id, Reservado);

      return quarto;
    }

    public static Quarto RemoverItem(int Id)
    {
      Quarto quarto = GetQuarto(Id);
      Quarto.RemoverQuarto(quarto);
      return quarto;
    }

    public static Quarto GetQuarto(int Id)
    {
      Quarto quarto = (
          from Quarto in Quarto.GetQuartos()
          where Quarto.Id == Id
          select Quarto
      ).First();

      if (quarto == null)
      {
        throw new Exception("Quarto não encontrado");
      }

      return quarto;
    }

    public static List<Quarto> VisualizarQuarto()
    {
      return Quarto.GetQuartos();
    }
  }
}