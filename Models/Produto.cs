using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace webapi.Models
{
    public partial class Produto
    {
        public Produto()
        {
            VendaItem = new HashSet<VendaItem>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "O nome deve ser inserido")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo 100 caracteres")]
        [RegularExpression(@"^[ a-zA-Z0-9 á]*$", ErrorMessage = "O nome deve conter apenas letras ou números.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O valor deve ser inserido")]
        public decimal? Valor { get; set; }

        public virtual ICollection<VendaItem> VendaItem { get; set; }
    }
}
