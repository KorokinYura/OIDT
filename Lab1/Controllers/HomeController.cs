using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Lab1.Models.JsonFullObject;
using Lab1.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db, IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _db = db;
        }

        public IActionResult Index()
        {
            return View("Home");
        }

        [HttpPost]
        public IActionResult UploadJsonToDb(int index, int quantity)
        {
            var path = _appEnvironment.WebRootPath + "\\jsons";
            var files = Directory.GetFiles(path).Where(f => f.Contains(".json")).ToList();

            for (int j = index; j < quantity + index; j++)
            {
                var text = string.Empty;

                if (files.Count > j)
                    text = System.IO.File.ReadAllText(files[j]);
                else
                    break;

                List<JsonFullObject> jsonModels = new List<JsonFullObject>();

                jsonModels = JsonConvert.DeserializeObject<List<JsonFullObject>>(text);

                for (int i = 0; i < jsonModels.Count; i++)
                {
                    switch (jsonModels[i].EventId)
                    {
                        case 1:
                            var gl = new GameLaunch
                            {
                                Date = jsonModels[i].Date,
                                EventId = jsonModels[i].EventId
                            };

                            _db.GameLaunches.Add(gl);
                            break;
                        case 2:
                            var fgl = new FirstGameLaunch
                            {
                                Date = jsonModels[i].Date,
                                Gender = jsonModels[i].Parameters.Gender,
                                Age = jsonModels[i].Parameters.Age,
                                Country = jsonModels[i].Parameters.Country,
                                EventId = jsonModels[i].EventId
                            };

                            _db.FirstGameLaunches.Add(fgl);
                            break;
                        case 3:
                            var ss = new StageStart
                            {
                                Date = jsonModels[i].Date,
                                Stage = jsonModels[i].Parameters.Stage,
                                EventId = jsonModels[i].EventId
                            };

                            _db.StageStarts.Add(ss);
                            break;
                        case 4:
                            var se = new StageEnd
                            {
                                Date = jsonModels[i].Date,
                                Stage = jsonModels[i].Parameters.Stage,
                                Win = jsonModels[i].Parameters.Win,
                                Time = jsonModels[i].Parameters.Time,
                                Income = jsonModels[i].Parameters.Income,
                                EventId = jsonModels[i].EventId
                            };

                            _db.StageEnds.Add(se);
                            break;
                        case 5:
                            var ip = new IngamePurchase
                            {
                                Date = jsonModels[i].Date,
                                Item = jsonModels[i].Parameters.Item,
                                Price = jsonModels[i].Parameters.Price,
                                EventId = jsonModels[i].EventId
                            };

                            _db.IngamePurchases.Add(ip);
                            break;
                        case 6:
                            var cp = new CurrencyPurchase
                            {
                                Date = jsonModels[i].Date,
                                Name = jsonModels[i].Parameters.Name,
                                Price = jsonModels[i].Parameters.Price,
                                Income = jsonModels[i].Parameters.Income,
                                EventId = jsonModels[i].EventId
                            };

                            _db.CurrencyPurchases.Add(cp);
                            break;
                    }
                }
            }

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ClearDb()
        {
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [GameLaunches]");
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [FirstGameLaunches]");
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [StageStarts]");
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [StageEnds]");
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [IngamePurchases]");
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [CurrencyPurchases]");

            return RedirectToAction("Index");
        }
    }
}
