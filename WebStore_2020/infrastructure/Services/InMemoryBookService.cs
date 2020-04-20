using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.infrastructure.interfaces;
using WebStore.Models;

namespace WebStore.infrastructure.Services
{
    public class InMemoryBookService : IBookService
    {

        private List<BookViewModel> _books;

        public InMemoryBookService()
        {
            _books = new List<BookViewModel>
            {
                new BookViewModel
                {
                    Id = 1,
                    Name = "Гарри Потер",
                    Author = "Джоан Роулинг",
                    CountPage = 444,
                    Genre = "Сказка",
                    price = 342.44d,
                    OwnerId =2
                },
                new BookViewModel
                {
                    Id = 2,
                    Name = "Шерлок Холмс",
                    Author = "Артур Конан Дойл",
                    CountPage = 332,
                    Genre = "Детектив",
                    price = 200,
                    OwnerId = 2
                },
                new BookViewModel
                {
                    Id = 3,
                    Name = "Мастер и Маргарита",
                    Author = "Михаил Булгаков",
                    CountPage = 553,
                    Genre = "Мистика",
                    price = 344,
                    OwnerId = 1
                }
            };
        }



        public IEnumerable<BookViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookViewModel GetById(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);

        }

        public IEnumerable<BookViewModel> GetAllBookByOwnerId(int ownerId)
        {
            return _books.Where(x => x.OwnerId == ownerId);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void AddNew(BookViewModel model)
        {
            if (_books.Count == 0)
            {
                model.Id = 1;
            }
            else
            {
                model.Id = _books.Max(e => e.Id) + 1;
            }

            _books.Add(model);
        }

        public void DeleteAllByOwnerId(int ownerId)
        {
            _books.RemoveAll(x => x.OwnerId == ownerId);
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book is null)
            {
                return;
            }

            _books.Remove(book);
        }
    }
}
