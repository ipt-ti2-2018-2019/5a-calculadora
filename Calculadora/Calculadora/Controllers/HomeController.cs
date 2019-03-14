using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculadora.Controllers {
   public class HomeController : Controller {

      // GET: Home
      public ActionResult Index() {

         // inicializa o valor inicial do VISOR
         ViewBag.Ecra = "0";

         // vars. auxiliares
         Session["primeiraVezOPerador"] = true;

         return View();
      }


      // POST: Home
      [HttpPost]
      public ActionResult Index(string bt, string visor) {
         // var. auxiliar
         string ecra = visor;

         // identificar o valor na variável 'bt'
         switch(bt) {
            // se entrar aqui, é pq foi selecionado um 'algarismo'
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
               // vou decidir o que fazer qd no visor só existe o 'zero'
               if(visor == "0") {   // visor.Equals("0")
                  ecra = bt;
               }
               else {
                  ecra = ecra + bt;
               }
               break;

            // processar o caso da ','
            case ",":
               if(!visor.Contains(",")) ecra = ecra + bt;
               break;

            // se entrar aqui, é pq foi selecionado um 'operador'
            case "+":
            case "-":
            case "x":
            case ":":
               // é a 1ª vez q carreguei num destes operadores?
               if((bool)Session["primeiraVezOPerador"] == true) { };

               break;
         }



         // prepara o conteúdo a aparecer no VISOR da View
         ViewBag.Ecra = ecra;

         return View();
      }



   }
}