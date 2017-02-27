using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
 

namespace WebLabs_V2.DAL.Entities
{
    public class Dish
    {
        [HiddenInput]
        public int DishId { get; set; } // id блюда

        [Required(ErrorMessage ="Введите название")]
        [Display(Name ="Название блюда")]
        public string DishName { get; set; } // название блюда
                
        [Display(Name ="Описание")]
        public string Description { get; set; } // описание блюда

        [Required]
        [Range(minimum:10, maximum:1500)]
        public int Calories { get; set; } // кол. калорий на порцию

        [Required]
        [Display(Name ="Группа")]
        public string GroupName { get; set; } // группа блюд (например, первые блюда, напистки и т.д.)

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; } // данные изображения
        [ScaffoldColumn(false)]
        public string MimeType { get; set; } // Mime - тип данных изображения
    }
}
