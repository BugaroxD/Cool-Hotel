using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Models
{
    public class Colaborador
    {
        public static Colaborador ColaboradorAuth;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Senha { get; set; }

        public Colaborador() { }

        public Colaborador(
            string Nome,
            string Matricula,
            string Senha
        )
        {
            this.Nome = Nome;
            this.Matricula = Matricula;
            this.Senha = Senha;

            Context db = new Context();
            db.Colaboradores.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n Matricula: {this.Matricula}"
                + $"\n Senha: {this.Senha}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Colaborador.ReferenceEquals(this, obj))
            {
                return false;
            }
            Colaborador it = (Colaborador) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarColaborador(
            int Id,
            string Nome,
            string Matricula,
            string Senha
        )
        {
            Colaborador colaborador = GetColaborador(Id);
            colaborador.Nome = Nome;
            colaborador.Matricula = Matricula;
            colaborador.Senha = Senha;

            Context db = new Context();
            db.Colaboradores.Update(colaborador);
            db.SaveChanges();
        }


        public static IEnumerable<Colaborador> GetColaboradores()
        {
            Context db = new Context();
            return (from Colaborador in db.Colaboradores select Colaborador);
        }

        public static Colaborador GetColaborador(int Id)
        {
            Context db = new Context();
            IEnumerable<Colaborador> colaboradores = from Colaborador in db.Colaboradores
                            where Colaborador.Id == Id
                            select Colaborador;

            return colaboradors.First();
        }

        public static void RemoverColaborador(Colaborador colaborador)
        {
            Context db = new Context();
            db.Colaboradores.Remove(colaborador);
            db.SaveChanges();
        }

        public static void Auth(string Matricula, string Senha)
        {
            Colaborador colaborador = GetColaboradores()
                .Where(it => it.Matricula == Matricula 
                    && BCrypt.Net.BCrypt.Verify(Senha, it.Senha)
                )
                .First();
            
            ColaboradorAuth = colaborador;
        }
    }
}