using MVC.LoanServiceReference;
using MVC.Models;
using System.Web.Mvc;

namespace MVC.Controllers {
    public class HomeController : Controller {
        LoanServiceClient Cliente;

        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Index(XMLViewModel Model) {
            Cliente = new LoanServiceClient();
            Model.Respuesta = Cliente.Request(Model.XMLEntrada);
            Cliente.Close();
            return View(Model);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}