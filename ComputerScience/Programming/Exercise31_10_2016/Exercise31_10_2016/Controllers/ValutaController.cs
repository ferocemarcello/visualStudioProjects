using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise31_10_2016.Controllers
{
    public class ValutaController : Controller
    {
        // GET: Valuta
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string ISO1, string ISO2,double amount)
        {
            Models.Valutas model = new Models.Valutas();
            model.Valuta1 = new Models.Valuta(ISO1,model.GetExRateFromISO(ISO1));
            model.Valuta2 = new Models.Valuta(ISO2, model.GetExRateFromISO(ISO2));
            model.Amount = amount;
            try
            {
                model.CalculateExchangedAmount(model.Valuta1, model.Valuta2, amount);
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
    }
}