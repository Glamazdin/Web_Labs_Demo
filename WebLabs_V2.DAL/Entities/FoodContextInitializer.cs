using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebLabs_V2.DAL.Entities
{
    class FoodContextInitializer : DropCreateDatabaseIfModelChanges<FoodContext>
    {
        protected override void Seed(FoodContext context)
        {
            List<Dish> dishes = new List<Dish>
            {
            new Dish {DishName="Суп-харчо", Description="Очень острый, невкусный",
                    Calories =200, GroupName="Супы" },
                new Dish {DishName="Борщ", Description="Много сала, без сметаны",
                    Calories =330, GroupName="Супы" },
                new Dish {DishName="Котлета пожарская", Description="Хлеб - 80%, Морковь - 20%",
                    Calories =635, GroupName="Вторые блюда" },
                new Dish {DishName="Макароны по-флотски", Description="С охотничьей колбаской",
                    Calories =524, GroupName="Вторые блюда" },
                new Dish {DishName="Компот", Description="Быстро растворимый, 2 литра",
                    Calories =180, GroupName="Напитки" }
            };
            context.Dishes.AddRange(dishes);
            context.SaveChanges();
        }
    }
}
