using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using WebLabs_V2.DAL.Entities;
using WebLabs_V2.DAL.Interfaces;
using WebLabs_V2.Models;


namespace WebLabs_V2.Controllers
{    
    public class DishController : Controller
    {
        int pageSize = 3 ;
        // Инициализация списка объектов:
        //List<Dish> dishes = new List<Dish>
        //{
        //    new Dish {DishId=1, DishName="Суп-харчо", Description="Очень острый, невкусный",
        //            Calories =200, GroupName="Супы" },
        //        new Dish {DishId=2, DishName="Борщ", Description="Много сала, без сметаны",
        //            Calories =330, GroupName="Супы" },
        //        new Dish {DishId=3, DishName="Котлета пожарская", Description="Хлеб - 80%, Морковь - 20%",
        //            Calories =635, GroupName="Вторые блюда" },
        //        new Dish {DishId=4, DishName="Макароны по-флотски", Description="С охотничьей колбаской",
        //            Calories =524, GroupName="Вторые блюда" },
        //        new Dish {DishId=5, DishName="Компот", Description="Быстро растворимый, 2 литра",
        //            Calories =180, GroupName="Напитки" }
        //};

        IRepository<Dish> repository;

        public DishController(IRepository<Dish> repo)
        {
            repository = repo;
        }

        // GET: Dish       
        public ActionResult List(string group, int page=1)
        {
            var lst = repository.GetAll()
                        .Where(d=> group==null
                                    || d.GroupName.Equals(group))
                        .OrderBy(d => d.Calories);
            var model = PageListViewModel<Dish>.CreatePage(lst, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }
            return View(model);
        }

        public async Task<FileResult> GetImage(int id)
        {
            var dish = await repository.GetAsync(id);
            if (dish != null)
            {
                return new FileContentResult(dish.Image, dish.MimeType);
            }
            else return null;
        }
    }
}