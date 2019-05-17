﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1.Data;
using Lab1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class PredictionController : Controller
    {
        private readonly AppDbContext _db;
        private readonly int days = 182;

        public PredictionController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult DAU()
        {
            var dates = _db.GameLaunches.Select(m => m.Date).Distinct().OrderBy(d => d.Date).ToList();
            var iterDates = new List<DateTime>
            {
                dates.First(),
                dates.Last()
            };

            List<DAUViewModel> list = new List<DAUViewModel>();

            foreach (var date in iterDates)
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

            int uniqueUsersDifference = list[1].UsersQuantity - list[0].UsersQuantity;

            int uniqueUsers = uniqueUsersDifference * days / dates.Count;

            return View(uniqueUsers);
        }

        public IActionResult NewUsers()
        {
            var dates = _db.FirstGameLaunches.Select(m => m.Date).Distinct().OrderBy(d => d.Date).ToList();
            var iterDates = new List<DateTime>
            {
                dates.First(),
                dates.Last()
            };

            var users = new List<int>();

            foreach (var date in iterDates)
            {
                users.Add(_db.FirstGameLaunches.Count(fgl => fgl.Date == date));
            }

            int uniqueUsersDifference = users[1] - users[0];

            int newUsers = uniqueUsersDifference * days / dates.Count;

            return View(newUsers);
        }

        public IActionResult Revenue()
        {
            var dates = _db.CurrencyPurchases.Select(m => m.Date).Distinct().OrderBy(d => d.Date).ToList();
            var iterDates = new List<DateTime>
            {
                dates.First(),
                dates.Last()
            };

            var retList = new List<RevenueViewModel>();

            foreach (var date in iterDates)
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

            double averageRevenue = retList[1].Income - retList[0].Income;

            double dailyRevenue = averageRevenue / dates.Count;

            return View(dailyRevenue);
        }

        public IActionResult Purchase()
        {
            var dates = _db.IngamePurchases.Select(m => m.Date).Distinct().OrderBy(d => d.Date).ToList();
            var iterDates = new List<DateTime>
            {
                dates.First(),
                dates.Last()
            };

            List<int> soldItems = new List<int>();

            foreach (var date in iterDates)
            {
                soldItems.Add(_db.IngamePurchases.Count(ip => ip.Date == date));
            }

            int averagePurchases = soldItems[1] - soldItems[0];

            int dailyPurchase = averagePurchases / dates.Count;

            return View(dailyPurchase);
        }
    }
}