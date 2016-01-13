using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.Dal.Persistence;
using Projeto.Web.Models;

namespace Projeto.Web.Controllers
{
    public class ProdutoController : Controller
    {
        //
        // GET: /Produto/
        public ActionResult Pesquisa()
        {
            return View();
        }

        public JsonResult CadastrarProduto(CadastroViewModelProduto objeto)
        {
            try
            {
                Produto p = new Produto();
                p.Nome = objeto.Nome;
                p.Preco = objeto.Preco;
                p.Quantidade = objeto.Quantidade;
                p.DataCadastro = DateTime.Now;

                ProdutoDal d = new ProdutoDal();

                d.Insert(p);

                return Json("Produto " + p.Nome + ", cadastro com sucesso.");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }  
        }

        public JsonResult ConsultarProduto(string Nome)
        {
            try
            {
                ProdutoDal d = new ProdutoDal();

                List<Produto> lista = d.FindByNome(Nome);
                var dados = new List<ConsultaViewModelCadastro>();

                foreach (Produto p in lista)
                {
                    var model = new ConsultaViewModelCadastro();
                    model.Codigo = p.IdProduto;
                    model.Nome = p.Nome;
                    model.Preco = p.Preco;
                    model.Quantidade = p.Quantidade;
                    model.Total = p.Preco * p.Quantidade;
                    model.DataCadastro = p.DataCadastro.ToString("ddd dd/MM/yyyy");

                    dados.Add(model);
                }

                return Json(dados);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult ExcluirProduto(int Codigo)
        {
            try
            {
                ProdutoDal d = new ProdutoDal();
                d.Delete(d.FindById(Codigo));

                return Json("Produto excluido com sucesso.");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult ObterProduto(int codigo)
        {
            try
            {
                ProdutoDal d = new ProdutoDal();
                Produto p = d.FindById(codigo);

                var model = new ConsultaViewModelCadastro();
                model.Codigo = p.IdProduto;
                model.Nome = p.Nome;
                model.Preco = p.Preco;
                model.Quantidade = p.Quantidade;

                return Json(model);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        public JsonResult AtualizarProduto(EdicaoViewModelProducao model)
        {
            try
            {
                ProdutoDal d = new ProdutoDal();
                Produto p = d.FindById(model.Codigo);

                p.Nome = model.Nome;
                p.Preco = model.Preco;
                p.Quantidade = model.Quantidade;

                d.Update(p);

                return Json("Produto " + p.Nome + ", atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
	}
}