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

            foreach(var fgl in _db.FirstGameLaunches)
            {
                users.Add(new User
                {
                    Age = fgl.Age,
                    Gender = fgl.Gender,
                    Country = fgl.Country,
                    Revenue = _db.CurrencyPurchases.Where(cp => cp.UdId == fgl.UdId && cp.Date == maxDate)
                        .Sum(cp => cp.Price),
                    BrokeEconomy = _db.IngamePurchases.Where(ip => ip.UdId == fgl.UdId && ip.Date == maxDate)
                        .Sum(ip => ip.Price) < 
                        _db.StageEnds.Where(se => se.UdId == fgl.UdId && se.Date == maxDate).Sum(se => se.Income)
                });
            }

            return View(users);
        }
    }
}