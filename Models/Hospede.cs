using System.Collections.Generic;
using System.Linq;
using Repository;
using System;

namespace Models
{
  public class Hospede
  {
    public static Hospede HospedAuth;

    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeMae { get; set; }
    public string DataNascimento { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public string NrCartao { get; set; }
    public int Cvv { get; set; }
    public string DataValidade { get; set; }
    public string FormaPagamento { get; set; }

    public Hospede() { }

    public Hospede(
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
      this.Nome = Nome;
      this.NomeMae = NomeMae;
      this.DataNascimento = DataNascimento;
      this.Cpf = Cpf;
      this.Senha = Senha;
      this.NrCartao = NrCartao;
      this.Cvv = Cvv;
      this.DataValidade = DataValidade;
      this.FormaPagamento = FormaPagamento;

      Context db = new Context();
      db.Hospedes.Add(this);
      db.SaveChanges();
    }

    public override string ToString()
    {
      return $"\n ---------------------------------------"
          + $"\n ID: {this.Id}"
          + $"\n Nome: {this.Nome}"
          + $"\n Nome: {this.NomeMae}"
          + $"\n Data de Nascimento: {this.DataNascimento}"
          + $"\n Cpf: {this.Cpf}"
          + $"\n Senha: {this.Senha}"
          + $"\n Número do Cartão: {this.NrCartao}"
          + $"\n CVV: {this.Cvv}"
          + $"\n Data de Validade: {this.DataValidade}"
          + $"\n Forma de Pagamento: {this.FormaPagamento}";
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }
      if (!Hospede.ReferenceEquals(this, obj))
      {
        return false;
      }
      Hospede it = (Hospede)obj;
      return it.Id == this.Id;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public static void AlterarHospede(
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
      Hospede.Nome = Nome;
      Hospede.NomeMae = NomeMae;
      Hospede.DataNascimento = DataNascimento;
      Hospede.Cpf = Cpf;
      Hospede.Senha = Senha;
      Hospede.NrCartao = NrCartao;
      Hospede.Cvv = Cvv;
      Hospede.DataValidade = DataValidade;
      Hospede.FormaPagamento = FormaPagamento;

      Context db = new Context();
      db.Hospedes.Update(hospede);
      db.SaveChanges();
    }


    public static IEnumerable<Hospede> GetHospedes()
    {
      Context db = new Context();
      return (from Hospede in db.Hospedes select Hospede);
    }

    public static Hospede GetHospede(int Id)
    {
      Context db = new Context();
      IEnumerable<Hospede> hospedes = from Hospede in db.Hospedes
                                      where Hospede.Id == Id
                                      select Hospede;

      return hospedes.First();
    }

    public static void RemoverHospede(Hospede hospede)
    {
      Context db = new Context();
      db.Hospedes.Remove(hospede);
      db.SaveChanges();
    }

    public static void Auth(string Cpf, string Senha)
    {
      Hospede hospede = GetHospedes()
          .Where(it => it.Cpf == Cpf
              && BCrypt.Net.BCrypt.Verify(Senha, it.Senha)
          )
          .First();

      HospedeAuth = hospede;
    }
  }
}