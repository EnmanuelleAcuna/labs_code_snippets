using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.Models {
    public class XMLViewModel {
        [Display(Name = "XML")]
        [AllowHtml]
        public string XMLEntrada { get; set; }

        public string Respuesta { get; set; }
    }
}