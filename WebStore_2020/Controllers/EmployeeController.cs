using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.infrastructure.interfaces;
using WebStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Controllers
{
    [Route("users")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IBookService _bookService;

        public EmployeeController(IEmployeesService employeesService, IBookService bookService)
        {
            _employeesService = employeesService;
            _bookService = bookService;
        }

        [Route("all")]
        // GET: /users/all
        [AllowAnonymous]
        public IActionResult Index()
        {
            //return Content("Hello from home controller");
            return View(_employeesService.GetAll());
        }

        [Route("{id}")]
        // GET: /users/{id}
        [Authorize(Roles = "Admins,Users")]
        public IActionResult Details(int id)
        {
            return View(_employeesService.GetById(id));
        }

        [Route("edit/{id?}")]
        [HttpGet]
        // GET: /users/edit/{id}
        [Authorize(Roles = "Admins")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeViewModel());

            var model = _employeesService.GetById(id.Value);
            if (model == null)
                return NotFound();// возвращаем результат 404 Not Found


            return View(model);
        }

        [Route("edit/{id?}")]
        [HttpPost]
        // GET: /users/edit/{id}
        [Authorize(Roles = "Admins")]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id > 0) // если есть Id, то редактируем модель
            {
                var dbItem = _employeesService.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();// возвращаем результат 404 Not Found

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Position = model.Position;
            }
            else // иначе добавляем модель в список
            {
                _employeesService.AddNew(model);
            }
            _employeesService.Commit(); // станет актуальным позднее (когда добавим БД)

            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id?}")]
        [Authorize(Roles = "Admins")]
        public IActionResult Delete(int? id)
        {
            var model = _employeesService.GetById(id.Value);

            if (model == null)
            {
                return NotFound();
            }

            _employeesService.Delete(id.Value);
            _bookService.DeleteAllByOwnerId(id.Value);
            return RedirectToAction("Index");

        }

    }
}