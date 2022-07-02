using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
  public class HospedeController
  {
    public static Hospede IncluirHospede(
        string Nome,
        string NomeMae,
        string DataNascimento,
        string Cpf,
        string Senha,
        string NrCartao,
        int Cvv,
        string DataValidade,
        string FormaPagamento
    )
    {
      if (String.IsNullOrEmpty(Nome))
      {
        throw new Exception("Nome inválido");
      }

      if (String.IsNullOrEmpty(NomeMae))
      {
        throw new Exception("Nome da mãe inválido");
      }

      if (String.IsNullOrEmpty(DataNascimento))
      {
        throw new Exception("Data de nascimento inválida");
      }

      if (String.IsNullOrEmpty(Cpf))
      {
        throw new Exception("CPF inválido");
      }

      if (String.IsNullOrEmpty(Senha))
      {
        throw new Exception("Senha inválida");
      }

      if (String.IsNullOrEmpty(NrCartao))
      {
        throw new Exception("Número do cartão inválido");
      }

      if (String.IsNullOrEmpty(Cvv.ToString()))
      {
        throw new Exception("CVV inválido");
      }

      if (String.IsNullOrEmpty(DataValidade))
      {
        throw new Exception("Data de validade inválido");
      }

      if (String.IsNullOrEmpty(FormaPagamento))
      {
        throw new Exception("Forma de pagamento inválido");
      }

      return new Hospede(Nome, NomeMae, DataNascimento, Cpf, Senha, NrCartao, Cvv, DataValidade, FormaPagamento);
    }

    public static Hospede AlterarHospede(
        int Id,
        string Nome,
        string NomeMae,
        string DataNascimento,
        string Cpf,
        string Senha,
        string NrCartao,
        int Cvv,
        string DataValidade,
        string FormaPagamento
    )
    {
      Hospede hospede = GetHospede(Id);

      if (!String.IsNullOrEmpty(Nome))
      {
        Nome = Nome;
      }

      if (!String.IsNullOrEmpty(NomeMae))
      {
        NomeMae = NomeMae;
      }

      if (!String.IsNullOrEmpty(Data_nascimento))
      {
        Data_nascimento = Data_nascimento;
      }

      if (!String.IsNullOrEmpty(Cpf))
      {
        Cpf = Cpf;
      }

      if (!String.IsNullOrEmpty(Senha))
      {
        Senha = Senha;
      }

      if (!String.IsNullOrEmpty(NrCartao))
      {
        NrCartao = NrCartao;
      }

      if (!String.IsNullOrEmpty(Cvv))
      {
        Cvv = Cvv;
      }

      if (!String.IsNullOrEmpty(DataValidade))
      {
        DataValidade = DataValidade;
      }

      if (!String.IsNullOrEmpty(FormaPagamento))
      {
        FormaPagamento = FormaPagamento;
      }

      Hospede.AlterarHospede(Id, Nome, NomeMae, DataNascimento, Cpf, Senha, NrCartao, Cvv, DataValidade, FormaPagamento);

      return hospede;
    }

    public static Hospede RemoverHospede(
        int Id
    )
    {
      Hospede Hospede = GetHospede(Id);
      Hospede.RemoverHospede(hospede);
      return hospede;
    }

    public static Hospede GetHospede(
        int Id
    )
    {
      Hospede hospede = (
          from Hospede in Hospede.GetHospedes()
          where Hospede.Id == Id
          select Hospede
      ).First();

      if (hospede == null)
      {
        throw new Exception("Hospede não encontrado");
      }

      return Hospede;
    }

    public static IEnumerable<Hospede> VisualizarHospede()
    {
      return Hospede.GetHospedes();
    }

    public static void Auth(
        string Nome,
        string NomeMae,
        string DataNascimento,
        string Cpf,
        string Senha,
        string NrCartao,
        int Cvv,
        string DataValidade,
        string FormaPagamento
    )
    {
      Hospede.Auth(Nome, NomeMae, DataNascimento, Cpf, Senha, NrCartao, Cvv, DataValidade, FormaPagamento);
    }
  }
}