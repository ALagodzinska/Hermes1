using HermesChat.Data;
using HermesChat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HermesChat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager; 
        }


        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("~/Home/Chat");
            }

            return View();
        }

        [Authorize]
        public IActionResult Chat()
        {
            var users = GetUsersList();
            return View("Chat", users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]

        public IActionResult Details(string userName)
        {
            
            var users = GetUsersList().All(c => c.UserName == userName);
            
            return View(users);
        }

       
        private static List<UsersModel> GetUsersList()
        {
            List<UsersModel> assignedToList = new List<UsersModel>();

            var dbContext = new ApplicationDbContext();
            var userList = dbContext.Users.ToList();
            

            assignedToList = userList.Select(u => new UsersModel
            {
                UserName = u.UserName
                
            }).ToList();
            
            return assignedToList;
        }

        //[HttpGet]

        //public IActionResult AddRoom(string roomName)
        //{

        //    var room = GetRoomList().All(c => c.RoomName == roomName);

        //    return View(room);
        //}

        //private static List<RoomModel> GetRoomList()
        //{
        //    List<RoomModel> assignedToList = new List<RoomModel>();

        //    //var dbContext = new ApplicationDbContext();
        //    //var roomList = dbContext.Room.ToList();


        //    assignedToList = roomList.Select(r => new RoomModel
        //    {
        //        RoomName = r.RoomName

        //    }).ToList();

        //    return assignedToList;
        //}
    }
}
