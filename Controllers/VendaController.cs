using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Application;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("vendas")]
    public class VendaController : Controller
    {
        private ApiContext _contexto;
        public VendaController(ApiContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return Ok("Index API");
        }

        [HttpGet]
        [Route("todos")]
        public IEnumerable<Venda> Listar([FromServices] VendaApplication application)
        {
            return application.GetAllVendas();
        }

        /**
         * [FromBody]
         * [FromService]
         * [FromURL]
         * */

        [HttpPost]
        [Route("")]
        public IActionResult InserVenda([FromBody] VendaRequest request)
        {
            request.Validar();

            if (request.Invalido)
                return BadRequest(request.Notificacoes);

            var venda = new VendaApplication(_contexto);
            var retorno = venda.InsertVenda(request);
            if(retorno == "OK") 
            {
                return Ok("Venda cadastrada com sucesso!");
            }
            else 
            {
                return BadRequest(retorno);
            }
            
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaVenda(int id, [FromBody] VendaStatusRequest request)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            request.Validar();

            if (request.Invalido)
                return BadRequest(request.Notificacoes);

            var venda = new VendaApplication(_contexto);
            var retorno = venda.UpdateVenda(id, request.EnumStatus);
            if (retorno == "OK")
            {
                return Ok("Venda alterada com sucesso!");
            }
            else
            {
                return BadRequest(retorno);
            }
        }
    }
}
