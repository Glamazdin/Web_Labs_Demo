using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLabs_V2.DAL.Entities;
using WebLabs_V2.DAL.Interfaces;

namespace WebLabs_V2.DAL.Repositories
{
    public class FakeRepository : IRepository<Dish>
    {
        public void Create(Dish t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> Find(Func<Dish, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Dish Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> GetAll()
        {
            return new List<Dish> {
                new Dish {DishId=1, DishName="Суп-харчо", Description="Очень острый, невкусный",
                    Calories =200, GroupName="Супы" },
                new Dish {DishId=2, DishName="Борщ", Description="Много сала, без сметаны",
                    Calories =330, GroupName="Супы" },
                new Dish {DishId=3, DishName="Котлета пожарская", Description="Хлеб - 80%, Морковь - 20%",
                    Calories =635, GroupName="Вторые блюда" },
                new Dish {DishId=4, DishName="Макароны по-флотски", Description="С охотничьей колбаской",
                    Calories =524, GroupName="Вторые блюда" },
                new Dish {DishId=5, DishName="Компот", Description="Быстро растворимый, 2 литра",
                    Calories =180, GroupName="Напитки" }
            };
        }

        public Task<Dish> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Dish t)
        {
            throw new NotImplementedException();
        }
    }
}
