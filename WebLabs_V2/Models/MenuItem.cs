﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLabs_V2.Models
{
    public class MenuItem
    {
        public string Name { set; get; }        // Текст надписи
        public string Controller { set; get; }  // Имя контроллера
        public string Action { set; get; }      // Имя метода
        public string Active { set; get; }      // Текущий пункт

    }
}