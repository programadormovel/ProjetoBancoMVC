using ProjetoBancoMVC.Models;
using ProjetoBancoMVC.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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

        // GET: Funcionario/AdicionarFuncionario
        public ActionResult AdicionarFuncionario()
        {
            var model = new FuncionarioModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarFuncionario(FuncionarioModel funcionario)
        {
            var funcRepository = new FuncionarioRepository();
            var imageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/jpg",
                "image/png"
            };

            if(funcionario.ImagemUpload == null || funcionario.ImagemUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImagemUpload", "Este Campo é obrigatório");
            }
            else if(!imageTypes.Contains(funcionario.ImagemUpload.ContentType))
            {
                ModelState.AddModelError("ImagemUpload", "Escolha uma imagem GIF, JPG ou PNG.");
            }

            if(ModelState.IsValid)
            {
                var func = new FuncionarioModel();
                func.Nome = funcionario.Nome;
                func.Sobrenome = funcionario.Sobrenome; 
                func.Cidade = funcionario.Cidade;
                func.Endereco = funcionario.Endereco;
                func.Email = funcionario.Email;

                using(var binaryReader = new BinaryReader(funcionario.ImagemUpload.InputStream)) {
                    func.Imagem = binaryReader.ReadBytes(funcionario.ImagemUpload.ContentLength);                
                }
                funcRepository.AdicionarFuncionario(func);
                return RedirectToAction("SelecionarFuncionarios");
            }
            return View(funcionario);
        }
    }
}