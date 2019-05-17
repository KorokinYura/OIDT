using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1.Data;
using Lab1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class TablesController : Controller
    {
        private readonly AppDbContext _db;

        public TablesController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult NewUsers()
        {
            return View(_db.FirstGameLaunches.ToList());
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

        public IActionResult MAU()
        {
            var startDate = new DateTime(2018, 1, 1);
            var endDate = new DateTime(2018, 2, 1);

            var datesLaunches = _db.GameLaunches.Select(m => m.Date).Distinct().OrderBy(d => d.Date).ToList();

            var retList = _db.FirstGameLaunches.Where(fgl => fgl.Date > startDate && fgl.Date < endDate);

            var ret = new MAUViewModel
            {
                UsersQuantity = retList.Count(),
                StartDate = startDate,
                EndDate = endDate
            };

            return View(ret);
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

        public IActionResult Currency()
        {
            var datesLaunches = _db.CurrencyPurchases.Select(m => m.Date).Distinct().OrderBy(d => d.Date).ToList();

            var retList = new List<RevenueViewModel>();

            foreach (var date in datesLaunches)
            {
                double currency = 0;

                var iterationList = _db.CurrencyPurchases.Where(cp => cp.Date == date);

                foreach (var cp in iterationList)
                {
                    currency += cp.Income;
                }

                retList.Add(new RevenueViewModel
                {
                    Date = date,
                    Income = currency
                });
            }

            return View(retList);
        }

        public IActionResult Stage()
        {
            var retList = new List<StageViewModel>();

            var stages = _db.StageStarts.Select(m => m.Stage).Distinct().OrderBy(s => s).ToList();

            foreach (var stage in stages)
            {
                int starts = 0;
                int ends = 0;
                int wins = 0;
                int income = 0;

                var iterationListStarts = _db.StageStarts.Where(cp => cp.Stage == stage);

                foreach (var start in iterationListStarts)
                {
                    starts++;
                }

                var iterationListEnds = _db.StageEnds.Where(cp => cp.Stage == stage);

                foreach (var end in iterationListEnds)
                {
                    ends++;
                    if (end.Win)
                        wins++;
                    income += end.Income;
                }

                retList.Add(new StageViewModel
                {
                    StageStarts = starts,
                    StageEnds = ends,
                    WinsQuantity = wins,
                    AllIncome = income
                });
            }

            return View(retList);
        }

        public IActionResult Purchase()
        {
            var retList = new List<PurchaseViewModel>();

            var items = _db.IngamePurchases.Select(m => m.Item).Distinct().ToList();

            foreach(var item in items)
            {
                int quantity = 0;
                double price = 0;

                var iterationList = _db.IngamePurchases.Where(cp => cp.Item == item);

                foreach(var purchase in iterationList)
                {
                    quantity++;
                    price += purchase.Price;
                }

                retList.Add(new PurchaseViewModel
                {
                    Item = item,
                    ItemsQuantity = quantity,
                    AllPrice = price
                });
            }

            return View(retList);
        }
    }
}