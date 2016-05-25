using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using BussinesLogic;
using Presentation.Models;


namespace Presentation.Controllers
{
    public class CrudController : Controller
    {
        private List<Products> LProducts = BussinesLogic.Classes.EntityOperations.getProducts();

        //
        // GET: /CRUD/
        public ActionResult Index()
        {
            
            return View(LProducts);
        }


        //
        // GET: /CRUD/Details/5

        public ActionResult Details(int id = 0)
        {
            Products Product = LProducts.Single(r => r.ProductID == id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }


        //
        // GET: /CRUD/Create
        public ActionResult Create()
        {

            return View();
        }



        //
        // POST: /CRUD/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                Boolean modify = false;
                Boolean response = BussinesLogic.Classes.EntityOperations.DoEntityOperation(products, modify);
                if (!response)
                {
                    return HttpNotFound();
                }
            }
            else { return HttpNotFound(); }
            return RedirectToAction("Index");
        }



        //
        // GET: /CRUD/Edit/5

        public ActionResult Edit(int id = 0)
        {

            return View();
        }



        //
        // POST: /CRUD/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                Boolean modify = true;
                Boolean response = BussinesLogic.Classes.EntityOperations.DoEntityOperation(products, modify);
                if (!response)
                {
                    return HttpNotFound();
                }
            }
            else { return HttpNotFound(); }
            return RedirectToAction("Index");
        }



        //
        // GET: /CRUD/Delete/5

        public ActionResult Delete()
        {
            return View();
        }



        //
        // POST: /CRUD/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id = 0)
        {
            Boolean response = BussinesLogic.Classes.EntityOperations.DoEntityOperation(id);
            if (!response)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

    }
}
