using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class ColaboradorController
    {
        public static Colaborador IncluirColaborador(
            string Nome,
            string Matricula,
            string Senha
        )
        {
            if(String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            if(String.IsNullOrEmpty(Matricula))
            {
                throw new Exception("Matrícula inválida");
            }

            if(String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Senha inválida");
            }

            return new Colaborador(Nome, Matrícula, Senha);
        }

        public static Colaborador AlterarColaborador(
            int Id,
            string Nome,
            string Matrícula,
            string Senha
        )
        {
            Colaborador colaborador = GetColaborador(Id);

            if(!String.IsNullOrEmpty(Nome))
            {
                Nome = Nome;
            }

            if(!String.IsNullOrEmpty(Matricula))
            {
                Matricula = Matricula;
            }

            if(!String.IsNullOrEmpty(Senha))
            {
                Senha = Senha;
            }

            Colaborador.AlterarColaborador(Id, Nome, Matricula, Senha);
            
            return colaborador;
        }

        public static Colaborador RemoverColaborador(
            int Id
        )
        {
            Colaborador colaborador = GetColaborador(Id);
            Colaborador.RemoverColaborador(colaborador);
            return colaborador;
        }

        public static Colaborador GetColaborador(
            int Id
        )
        {
            Colaborador colaborador = (
                from Colaborador in Colaborador.GetColaboradores()
                    where Colaborador.Id == Id
                    select Colaborador
            ).First();

            if(colaborador == null)
            {
                throw new Exception("Colaborador não encontrado");
            }

            return colaborador;
        }

        public static IEnumerable<Colaborador> VisualizarColaborador()
        {
            return Colaborador.GetColaboradores();
        }

        public static void Auth(
            string Matricula,
            string Senha
        )
        {
            Colaborador.Auth(Matricula, Senha);
        }
    }
}