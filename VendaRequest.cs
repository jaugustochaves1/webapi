using System.Collections.Generic;
using System.Linq;

namespace webapi
{
    public class VendaRequest
    {
        public int IdVendedor { get; set; }
        public IEnumerable<ItemRequest> Itens { get; set; }

        public IList<string> Notificacoes { get; set; }

        public bool Valido => Notificacoes.Count == 0;
        public bool Invalido => !Valido;

        public VendaRequest()
        {
            Notificacoes = new List<string>();
        }

        public void Validar()
        {
            if(IdVendedor <= 0)
            {
                Notificacoes.Add("Vendedor inválido");
            }

            if (!Itens.Any())
            {
                Notificacoes.Add("A lista de itens deve estar preenchida");
            }
        }

        public void ValidarStatus()
        {
            if (IdVendedor <= 0)
            {
                Notificacoes.Add("Vendedor inválido");
            }
        }
    }
}
