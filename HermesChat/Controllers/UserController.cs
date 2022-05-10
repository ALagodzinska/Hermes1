using Microsoft.AspNetCore.Mvc;
using HermesChat.Data;
using Services;
using Entity;

namespace HermesChat.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly BLL _businessLogic;
        //private readonly DLL _dataLogic;
        ApplicationDbContext _context;  
        public UserController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _businessLogic = new BLL();
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.User.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Create(Users users)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        _businessLogic.CreateUser(users);
        //        return RedirectToAction("Index", "Users");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{

        //    Users users = _businessLogic.GetUsersList().Single(emp => emp.UserId == id);
        //    return View(users);
        //}
        //[HttpPost]
        //public ActionResult Edit(Users users)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        _businessLogic.UpdateUser(users);
        //        return RedirectToAction("Index", "Users");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{

        //    _businessLogic.DeleteUser(id);
        //    return RedirectToAction("Index", "Users");
        //}
        public ActionResult Details(int id)
        {

            Users users = _businessLogic.GetUsersList().Single(emp => emp.UserId == id);
            return View(users);
        }

    }
}