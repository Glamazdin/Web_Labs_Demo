using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebLabs_V2.DAL.Entities
{
    class FoodContext:DbContext
    {
        public FoodContext()
        { }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        ///// <param name="name"> имя строки подключения </param>
        public FoodContext(string name) : base(name)
        {
            Database.SetInitializer(new FoodContextInitializer());
        }
        
        public DbSet<Dish> Dishes { get; set; }
    }
}
