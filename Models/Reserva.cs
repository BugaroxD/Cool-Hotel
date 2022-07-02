using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdHospede { get; set; }
        public Hospede Hospede { get; set; }
        public int IdQuarto { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime DataEntrada { get; set; }
        // Campos que não são requeridos inicialmente:
        public DateTime DataSaida { get; set; }
        public bool Pago { get; set; }

        public Reserva() { }

        public Reserva(
            int IdHospede,
            int IdQuarto,
            DateTime DataEntrada
        )   
        {
            this.IdHospede = IdHospede;
            this.IdQuarto = IdQuarto;
            this.DataEntrada = DataEntrada;

            Context db = new Context();
            db.Reservas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID Reserva: {this.Id}"
                + $"\n ID Hóspede: {this.IdHospede}"
                + $"\n Data de Entrada: {this.DataEntrada}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !Reserva.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Reserva iterable = (Reserva) obj;
            return iterable.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Alterar uma Reserva existente.
        public static void AlterarReserva(
            int Id,
            int IdHospede,
            int IdQuarto,
            DateTime DataEntrada
        )
        {
            try
            {
                Reserva reserva = GetReserva(Id);
                reserva.IdHospede = IdHospede;
                reserva.IdQuarto = IdQuarto;
                reserva.DataEntrada = DataEntrada;

                Context db = new Context();
                db.Reservas.Update(reserva);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos comunicar com o Banco de Dados");
            }
        }

        // Retorna uma Reserva pelo seu ID.
        public static Reserva GetReserva(int Id)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Reserva> reserva = from Reserva in db.Reservas
                        where Reserva.Id == Id
                        select Reserva;
                return reserva.First();
            }
            catch
            {
                throw new System.Exception("Não conseguimos comunicar com o Banco de Dados.");
            }
        }

        // Retorna uma lista de Reservas.
        public static IEnumerable<Reserva> ListaReservas()
        {
            try
            {
                Context db = new Context();
                return (from Reserva in db.Reservas select Reserva);
            }
            catch
            {
                throw new System.Exception("Não conseguimos comunicar com o Banco de Dados.");
            }

        }

        // Remove a uma Reserva por Id.
        public static RemoveReserva(Reserva reserva)
        {
            try
            {
                Context db = new Context();
                db.Reservas.Remove(reserva);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos comunicar com o Banco de Dados.");
            }
        }
    }
}