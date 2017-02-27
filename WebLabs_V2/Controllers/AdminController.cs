using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLabs_V2.DAL.Interfaces;
using WebLabs_V2.DAL.Entities;

namespace WebLabs_V2.Controllers
{
    public class AdminController : Controller
    {
        IRepository<Dish> repository;
        public AdminController(IRepository<Dish> repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

       
        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Dish());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Dish dish, HttpPostedFileBase imageUpload=null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    dish.Image = new byte[count];
                    imageUpload.InputStream.Read(dish.Image, 0, (int)count);
                    dish.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Create(dish);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(dish);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Dish dish, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    dish.Image = new byte[count];
                    imageUpload.InputStream.Read(dish.Image, 0, (int)count);
                    dish.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Update(dish);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(dish);
                }
            }
            else return View(dish);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, bool result)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
