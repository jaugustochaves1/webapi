using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi
{
    public class ItemRequest
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
