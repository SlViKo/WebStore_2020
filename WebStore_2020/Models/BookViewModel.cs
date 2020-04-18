﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_2020.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название книги")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Страниц")]
        public int CountPage { get; set; }
        [Display(Name = "Жанр")]
        public string Genre { get; set; }
        [Display(Name = "Цена")]
        public double price { get; set; }
        public int OwnerId { get; set; }
    }
}