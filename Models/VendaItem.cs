using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace webapi.Models
{
    public partial class VendaItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A venda deve ser passada")]
        public int IdVenda { get; set; }
        [Required(ErrorMessage = "O Produto deve ser selecionado")]
        public int IdProduto { get; set; }
        [Required(ErrorMessage = "A Quantidade deve ser inserida")]
        public int? Quantidade { get; set; }
        [Required(ErrorMessage = "O valor deve ser inserido")]
        public double Valor { get; set; }

        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual Venda IdVendaNavigation { get; set; }

        public VendaItem(int idProduto, int quantidade, double valor)
        {
            IdProduto = idProduto;
            Quantidade = quantidade;
            Valor = valor;
        }
    }
}
