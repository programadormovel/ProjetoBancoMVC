using ProjetoBancoMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancoMVC.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult SelecionarFuncionarios()
        {
            var funcRepository = new FuncionarioRepository();
            ModelState.Clear();

            return View(funcRepository.SelecionarFuncionarios());
        }
    }
}