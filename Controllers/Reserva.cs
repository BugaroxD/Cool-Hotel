using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class ReservaController
    {
        public static Reserva IncluirReserva(int IdHospede, int IdQuarto, Date DataEntrada)
        {
            Reserva reserva = GetReserva(id);
        }

        public static Quarto AlterarQuarto(int Id, int NumeroQuarto, int Andar, string Descricao, string Reservado, double Valor)
        {
            Quarto quarto = GetQuarto(Id);

            if(!String.IsNullOrEmpty(Descricao))
            {
                Descricao = quarto.Descricao;
            }

            if(!String.IsNullOrEmpty(Reservado))
            {
                Reservado = quarto.Reservado;
            }
            
            Quarto.AlterarQuarto(Id, NumeroQuarto, Andar, Descricao, Reservado, Valor);

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

            if(quarto == null)
            {
                throw new Exception("Quarto não encontrado");
            }

            return quarto;
        }

        public static IEnumerable<Quarto> VisualizarQuarto()
        {
            return Quarto.GetQuartos();
        }
    }
}