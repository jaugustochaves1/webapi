using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi
{
    public class VendaStatusRequest
    {
        public string Status { get; set; }
        public StatusPagamentoEnum EnumStatus { get; set; }
        public IList<string> Notificacoes { get; set; }
        public bool Valido => Notificacoes.Count == 0;
        public bool Invalido => !Valido;

        public void Validar()
        {
            if(Status == "Aguardando pagamento")
            {
                EnumStatus = StatusPagamentoEnum.AGUARDANDO_PAGAMENTO;
            }
            else if (Status == "Pagamento aprovado")
            {
                EnumStatus = StatusPagamentoEnum.PAGAMENTO_APROVADO;
            }
            else if (Status == "Enviado para transportadora")
            {
                EnumStatus = StatusPagamentoEnum.ENVIADO_PARA_TRANSPORTADORA;
            }
            else if (Status == "Entregue")
            {
                EnumStatus = StatusPagamentoEnum.ENTREGUE;
            }
            else if (Status == "Cancelada")
            {
                EnumStatus = StatusPagamentoEnum.CANCELADA;
            }
            else 
            {
                Notificacoes.Add("Status inexistente!");
            }
        }
    }
}
