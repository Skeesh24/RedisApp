using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedisApp.Models;
using RedisApp.Services;
using System.Diagnostics;

namespace RedisApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private Domain.AppContext? db;

        private RedisService? redis;

        public HomeController(ILogger<HomeController> logger, Domain.AppContext? db, RedisService? redis)
        {
            this.logger = logger;
            this.db = db;
            this.redis = redis;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }


    }
}