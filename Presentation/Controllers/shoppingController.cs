using BussinesLogic.Classes;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class shoppingController : Controller
    {

        private static List<Product> LProducts = new List<Product>();

        //
        // GET: Shooping/
        public ActionResult Index()
        {
            return RedirectToAction("ShowProducts", "Shopping");
        }



        //
        // GET: Shooping/ShoppingCart/
        public ActionResult ShoppingCart()
        {
            if (LProducts.Count() == 0)
            {
                ViewBag.Message = "No hay Productos en el carrito";
            }
            else
            {
                ViewBag.Message = "";
            }

            WebServiceReference.CurrencyConvertor MoneyConventor = new WebServiceReference.CurrencyConvertor();
            decimal Change = (decimal)MoneyConventor.ConversionRate(WebServiceReference.Currency.USD, WebServiceReference.Currency.ARS);
            ViewBag.Total = Product.CalculateAmount(LProducts);
            ViewBag.TotalUSD = Product.CalculateAmount(LProducts) * Change;

            return View(LProducts);
        }


        //
        // GET: Shooping/ReturnProducts/
        public ActionResult ReturnProducts()
        {
            return Json(GoProducts.LosProducts(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: Shooping/ShowProducts/
        public ActionResult ShowProducts()
        {
            return View();
        }


        //
        // GET: Shooping/Delete/5
        public ActionResult Delete(int ID)
        {
            Product ProductToRemove = LProducts.Single(r => r.ProductID == ID);
            LProducts.Remove(ProductToRemove);
            return RedirectToAction("ShoppingCart", "Shopping");
        }



        //
        // GET: Shooping/Clear/
        public ActionResult Clear()
        {
            LProducts.Clear();
            return RedirectToAction("ShowProducts", "Shopping");
        }

        //
        // GET: Shooping/Finish/
        public ActionResult Finish()
        {
            LProducts.Clear();
            return RedirectToAction("Index", "home");
        }


        //
        // POST: Shooping/ShowProducts/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowProducts(Product model)
        {

            if (ModelState.IsValid)
            {
                Product EnterProduct = LProducts.SingleOrDefault(r => r.ProductID == model.ProductID);
                if (EnterProduct != null)
                {
                    LProducts.Remove(EnterProduct);
                    EnterProduct.ProductQuantity += model.ProductQuantity;
                    EnterProduct.TotalPrice = EnterProduct.ProductQuantity + EnterProduct.UnitPrice;
                    LProducts.Add(EnterProduct);
                }
                else
                {
                    LProducts.Add(model);
                }
            }

            return View();
        }



    }
}
