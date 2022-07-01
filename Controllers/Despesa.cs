using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class DespesaController
    {
        public static Despesa InserirDespesa(
            int ReservaId,
            int ProdutoId,
            string Qnt_Consumida
        )
        {
            return new Despesa(ReservaId, ProdutoId);
        }

        public static Despesa RemoverDespesa(
            int Id
        )
        {
            Despesa Despesa = GetDespesa(Id);
            Despesa.RemoverDespesa(Despesa);
            return Despesa;
        }
         public static IEnumerable<Despesa> ReservaId(int Id)
        {
            return Despesa.ReservaId(Id);
        }
        public static Despesa GetByDespesa(int ReservaId, int ProdutoId)
        {
            return Despesa.GetDespesa(ReservaId, ProdutoId);
        }
        public static Despesa GetById(int Id)
        {
            Despesa Despesa = Despesa.GetById(Id);

            return Despesa;
        }

         public static IEnumerable<Despesa> VisualizarDespesa()
        {
            return Despesa.GetDespesas();
        }

        public static Despesa GetDespesa(
            int Id
        )
        {
            Despesa Despesa = (
                from despesa in Despesa.GetDespesas()
                    where despesa.Id == Id
                    select despesa
            ).First();

            if(Despesa == null)
            {
                throw new Exception("Tag da senha não encontrada");
            }
            return Despesa;
        }
    } // public class DespesaController
} // namespace Controller