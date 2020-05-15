using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.infrastructure.interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Получение списка книг
        /// </summary>
        /// <returns></returns>
        IEnumerable<BookViewModel> GetAll();

        BookViewModel GetById(int id);

        /// <summary>
        /// получение списка книг по id сотрудника
        /// </summary>
        /// <param name="ownerId">OwnerId</param>
        /// <returns></returns>
        IEnumerable<BookViewModel> GetAllBookByOwnerId(int ownerId);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Commit();

        /// <summary>
        /// Добавить новой книги
        /// </summary>
        /// <param name="model"></param>
        void AddNew(BookViewModel model);

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// удаление всех книг пользователя
        /// </summary>
        /// <param name="ownerId"></param>
        void DeleteAllByOwnerId(int ownerId);
    }
}

