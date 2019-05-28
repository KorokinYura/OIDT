using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1.Data;
using Lab1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Users()
        {
            var users = new List<User>();

            var maxDate = _db.GameLaunches.Max(gl => gl.Date);

            foreach(var fgl in _db.FirstGameLaunches.Take(1000))
            {
                users.Add(new User
                {
                    Age = fgl.Age,
                    Gender = fgl.Gender,
                    Country = fgl.Country,
                    Revenue = _db.CurrencyPurchases.Where(cp => cp.UdId == fgl.UdId).Sum(cp => cp.Price),
                    Spend = (int)_db.IngamePurchases.Where(ip => ip.UdId == fgl.UdId).Sum(ip => ip.Price),
                    Earned = _db.StageEnds.Where(se => se.UdId == fgl.UdId).Sum(se => se.Income)
                });
            }

            return View(users);
        }
    }
}