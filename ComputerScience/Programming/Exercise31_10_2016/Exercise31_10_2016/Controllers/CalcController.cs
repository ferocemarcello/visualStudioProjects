using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise31_10_2016.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            Models.CalcModel model = new Models.CalcModel();
            return View(model);
        }

        // POST: Calc/Edit/5
        [HttpPost]
        public ActionResult Index(int Num1, int Num2, string submit)
        {
            Models.CalcModel model = new Models.CalcModel();
            try
            {
                
                if (submit=="Add")
                    {
                        model.Num1 = Num1;
                        model.Num2 = Num2;
                        model.Result = model.Num1 + model.Num2;
                        //ModelState.Clear();
                        return View(model);
                    }
                if (submit == "Subtract")
                {
                    model.Num1 = Num1;
                    model.Num2 = Num2;
                    model.Result = model.Num1 - model.Num2;
                    //ModelState.Clear();
                    return View(model);
                }
                if (submit == "Multiply")
                {
                    model.Num1 = Num1;
                    model.Num2 = Num2;
                    model.Result = model.Num1 * model.Num2;
                    //ModelState.Clear();
                    return View(model);
                }
                if (submit == "Divide")
                {
                    model.Num1 = Num1;
                    model.Num2 = Num2;
                    model.Result = model.Num1 / model.Num2;
                    //ModelState.Clear();
                    return View(model);
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        

       
    }
}
