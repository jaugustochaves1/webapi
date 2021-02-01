using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Application
{
    public class VendaApplication
    {
        private ApiContext _contexto;

        public VendaApplication(ApiContext contexto)
        {
            _contexto = contexto;
        }

        public string InsertVenda(VendaRequest request)
        {
            try
            {
                var itens = request.Itens.Select(item => new VendaItem(item.IdProduto,
                                                                       item.Quantidade,
                                                                       item.Valor)).ToList();

                var venda = new Venda(request.IdVendedor, itens);

                if (venda.Invalido)
                {
                    return "Não foi possível se comunicar com a base de dados!";
                }

                _contexto.Add(venda);
                _contexto.SaveChanges();

                return "OK";
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string UpdateVenda(int idVenda, StatusPagamentoEnum status)
        {
            try
            {
                var venda = _contexto.Vendas.FirstOrDefault(venda => venda.Id == idVenda);
                venda.UpdateStatus(status);

                if (venda == null || (venda != null && venda.Invalido))
                {
                    return "Não foi possível se comunicar com a base de dados!";
                }

                venda.Status = status;

                _contexto.Entry(venda).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _contexto.SaveChanges();

                return "OK";

            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public IEnumerable<Venda> GetAllVendas()
        {   
            try
            {

                return _contexto
                    .Vendas
                    .AsNoTracking()
                    .ToList();
                /*return _contexto
                    .Vendas
                    .AsNoTracking()
                    .Select(x => new VendaResponse
                    {
                        IdVendedor = x.IdVendedor,
                        DataCadatro = x.DtCadastro
                    })
                    .ToList();
                */
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string DeleteVenda(Venda venda)
        {
            try
            {
                if (venda != null)
                {
                    _contexto.Vendas.Remove(venda);
                    _contexto.SaveChanges();

                    return "Venda " + venda.Id + " deletada com sucesso!";
                }
                else
                {
                    return "Venda não cadastrada!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        //public Expression<Func<Venda, bool>> ObterPorIdDoVendedor(int idVendedor)
        //{
        //    return x => x.IdVendedor == idVendedor;
        //}
     }
}
