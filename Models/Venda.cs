using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace webapi.Models
{
    public partial class Venda
    {
        public Venda()
        {
            VendaItens = new List<VendaItem>();
            DtCadastro = DateTime.Now;

            Notificacoes = new List<string>();
        }

        public Venda(int idVendedor, List<VendaItem> itens)
        {
            DtCadastro = DateTime.Now;

            UpdateIdVendedor(idVendedor);
            UpdateItens(itens);
        }

        public IList<string> Notificacoes { get; set; }

        public bool Valido => Notificacoes.Count == 0;
        public bool Invalido => !Valido;


        public int Id { get; }
        [Required(ErrorMessage = "A Data deve ser inserida")]
        public DateTime DtCadastro { get; set; }
        [Required(ErrorMessage = "O vendedor deve ser selecionado")]
        public int IdVendedor { get; set; }
        public StatusPagamentoEnum Status { get; set; }

        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual IList<VendaItem> VendaItens { get; set; }

        public void UpdateIdVendedor(int idVendedor)
        {
            if (idVendedor <= 0)
            {
                Notificacoes.Add("Vendedor inválido");
            }

            IdVendedor = idVendedor;
        }

        public void UpdateStatus(StatusPagamentoEnum status)
        {
            if (status == StatusPagamentoEnum.AGUARDANDO_PAGAMENTO && !(Id > 0) )
            {
                Status = StatusPagamentoEnum.AGUARDANDO_PAGAMENTO;
            }
            else if (status == StatusPagamentoEnum.PAGAMENTO_APROVADO && Status == StatusPagamentoEnum.AGUARDANDO_PAGAMENTO)
            {
                Status = StatusPagamentoEnum.PAGAMENTO_APROVADO;
            }
            else if (status == StatusPagamentoEnum.ENVIADO_PARA_TRANSPORTADORA && Status == StatusPagamentoEnum.PAGAMENTO_APROVADO)
            {
                Status = StatusPagamentoEnum.ENVIADO_PARA_TRANSPORTADORA;
            }
            else if (status == StatusPagamentoEnum.ENTREGUE && Status == StatusPagamentoEnum.ENVIADO_PARA_TRANSPORTADORA)
            {
                Status = StatusPagamentoEnum.ENTREGUE;
            } 
            else if (status == StatusPagamentoEnum.CANCELADA && (Status == StatusPagamentoEnum.AGUARDANDO_PAGAMENTO || Status == StatusPagamentoEnum.PAGAMENTO_APROVADO ))
            {
                Status = StatusPagamentoEnum.CANCELADA;
            }
            else 
            {
                Notificacoes.Add("Status inválido");
            }
        }

        public void UpdateItens(List<VendaItem> itens)
        {
            if (!itens.Any())
            {
                Notificacoes.Add("A lista de itens deve estar preenchida");
            }

            VendaItens = itens;
        }
    }
}
