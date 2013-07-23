using SeiRPGManager.DAL.Repositorio;
using SeiRPGManager.Entidades.Modelo.ClassesBasicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeiRPGManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Teste()
        {
            Raca r = new Raca();

            r.Descricao = "ABC Descrição";
            r.Nome = "Nome XYZ";

            //RacaDAO rDao = new RacaDAO();

            //rDao.CriarFonteDeDados();
            SeiRPGManagerDAO<Raca> rDao = new SeiRPGManagerDAO<Raca>();
            
            rDao.Inserir(r);
            IList<Raca> listaRaca = rDao.ObterTodos<Raca>();
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
