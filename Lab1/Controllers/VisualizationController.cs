using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1.Data;
using Lab1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class VisualizationController : Controller
    {
        private readonly AppDbContext _db;

        public VisualizationController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Users()
        {
            var users = new List<User>();

            var maxDate = _db.GameLaunches.Max(gl => gl.Date);

            foreach (var fgl in _db.FirstGameLaunches)
            {
                users.Add(new User
                {
                    Age = fgl.Age,
                    Gender = fgl.Gender,
                    Country = fgl.Country
                });
            }

            return View(users);
        }

        public IActionResult DAU()
        {
            var datesLaunches = _db.GameLaunches.Select(m => m.Date).Distinct().OrderBy(d => d.Date).ToList();
            List<DAUViewModel> list = new List<DAUViewModel>();

            foreach (var date in datesLaunches)
            {
                var users = new List<string>();
                int quantity = 0;

                var iterationList = _db.GameLaunches.Where(gl => gl.Date == date);

                foreach (var gl in iterationList)
                {
                    if (users.FirstOrDefault(u => u == gl.UdId) == null)
                    {
                        users.Add(gl.UdId);
                        quantity++;
                    }
                }

                list.Add(new DAUViewModel
                {
                    UsersQuantity = quantity,
                    Date = date
                });
            }

            return View(list);
        }

        public IActionResult NewUsers()
        {
            return View(_db.FirstGameLaunches.ToList());
        }

        public IActionResult Revenue()
        {
            var datesLaunches = _db.CurrencyPurchases.Select(m => m.Date).Distinct().OrderBy(d => d.Date).ToList();

            var retList = new List<RevenueViewModel>();

            foreach (var date in datesLaunches)
            {
                double income = 0;

                var iterationList = _db.CurrencyPurchases.Where(cp => cp.Date == date);

                foreach (var cp in iterationList)
                {
                    income += cp.Price;
                }

                retList.Add(new RevenueViewModel
                {
                    Date = date,
                    Income = income
                });
            }

            return View(retList);
        }
    }
}