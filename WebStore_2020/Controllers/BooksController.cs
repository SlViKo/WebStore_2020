using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_2020.infrastructure.interfaces;
using WebStore_2020.Models;

namespace WebStore_2020.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
       

        public IActionResult BooksDescription(int? id)
        {
            ViewBag.OwnerId = id.Value;

            return View(_bookService.GetAllBookByOwnerId(id.Value));
        }

        [HttpGet]
        public IActionResult Edit(int? ownerId)
        {
            var model = new BookViewModel();

            model.OwnerId = ownerId.Value;

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {

            if (model.Id > 0)
            {
                var dbItem = _bookService.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                {
                    return NotFound();
                }

                dbItem.Name = model.Name;
                dbItem.Author = model.Author;
                dbItem.CountPage = model.CountPage;
                dbItem.Genre = model.Genre;
                dbItem.price = dbItem.price;
            }
            else
            {
                _bookService.AddNew(model);
            }
            
            return RedirectToAction("BooksDescription", new {id = model.OwnerId} );
        }

        public IActionResult Delete(int? id)
        {
            var model = _bookService.GetById(id.Value);
            

            if (model == null)
            {
                return NotFound();
            }
            int ownerId =  model.OwnerId;
            _bookService.Delete(id.Value);

            return RedirectToAction("BooksDescription", new{id = ownerId});
        }

    }
}