using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLabs_V2.Models;
using WebLabs_V2.DAL.Interfaces;
using WebLabs_V2.DAL.Entities;

namespace WebLabs_V2.Controllers
{
    public class MenuController : Controller
    {
        List<MenuItem> items;
        IRepository<Dish> repository;
          
        public MenuController(IRepository<Dish> repo)
        {
            repository = repo;
            items = new List<MenuItem>
            {
            new MenuItem{Name="Домой", Controller="Home", Action="Index", Active=string.Empty},
            new MenuItem{Name="Меню", Controller="Dish", Action="List", Active=string.Empty},
            new MenuItem{Name="Администрирование", Controller="Admin", Action="Index", Active=string.Empty},
            };
        }
        // GET: Menu
        public PartialViewResult Main(string c = "Home")
        {
            var current = items
                    .Where(i => string.Compare(i.Controller,c, true)==0)
                    .FirstOrDefault();
            if (current!=null)
            {
                current.Active="active";
            };
            return PartialView(items);
        }

        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        public PartialViewResult Side()
        {
            var groups = repository
                                .GetAll()
                                .Select(d => d.GroupName)
                                .Distinct();       
            return PartialView(groups);
        }

        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}