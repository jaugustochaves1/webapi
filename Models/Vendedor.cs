using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace webapi.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "O CPF deve ser inserido")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O nome deve ser inserido")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres")]
        [MaxLength(150, ErrorMessage = "O nome deve conter no máximo 150 caracteres")]
        [RegularExpression(@"^[ a-zA-Z á]*$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email deve ser inserido")]
        [MinLength(10, ErrorMessage = "O email deve conter no mínimo 10 caracteres")]
        [MaxLength(150, ErrorMessage = "O email deve conter no máximo 150 caracteres")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O Email é inválido, insira outro.")]
        public string Email { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Venda> Venda { get; set; }
    }
}
