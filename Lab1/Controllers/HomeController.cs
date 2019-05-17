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
        public IActionResult UploadJsonToDb(int index)
        {
            //ClearDb();

            var path = _appEnvironment.WebRootPath + "\\jsons";
            var files = Directory.GetFiles(path).Where(f => f.Contains(".json")).ToList();

            //var text = System.IO.File.ReadAllText(path + "\\2018-01-01-1.json");
            var text = System.IO.File.ReadAllText(files[index]);

            List<JsonFullObject> jsonModels = new List<JsonFullObject>();

            jsonModels = JsonConvert.DeserializeObject<List<JsonFullObject>>(text);

            for (int i = 0; i < jsonModels.Count; i++)
            {
                switch (jsonModels[i].EventId)
                {
                    case 1:
                        var gl = new GameLaunch();
                        gl.Date = jsonModels[i].Date;

                        _db.GameLaunches.Add(gl);
                        break;
                    case 2:
                        var fgl = new FirstGameLaunch();
                        fgl.Date = jsonModels[i].Date;
                        fgl.Gender = jsonModels[i].Parameters.Gender;
                        fgl.Age = jsonModels[i].Parameters.Age;
                        fgl.Country = jsonModels[i].Parameters.Country;

                        _db.FirstGameLaunches.Add(fgl);
                        break;
                    case 3:
                        var ss = new StageStart();
                        ss.Date = jsonModels[i].Date;
                        ss.Stage = jsonModels[i].Parameters.Stage;

                        _db.StageStarts.Add(ss);
                        break;
                    case 4:
                        var se = new StageEnd();
                        se.Date = jsonModels[i].Date;
                        se.Stage = jsonModels[i].Parameters.Stage;
                        se.Win = jsonModels[i].Parameters.Win;
                        se.Time = jsonModels[i].Parameters.Time;
                        se.Income = jsonModels[i].Parameters.Income;

                        _db.StageEnds.Add(se);
                        break;
                    case 5:
                        var ip = new IngamePurchase();
                        ip.Date = jsonModels[i].Date;
                        ip.Item = jsonModels[i].Parameters.Item;
                        ip.Price = jsonModels[i].Parameters.Price;

                        _db.IngamePurchases.Add(ip);
                        break;
                    case 6:
                        var cp = new CurrencyPurchase();
                        cp.Date = jsonModels[i].Date;
                        cp.Name = jsonModels[i].Parameters.Name;
                        cp.Price = jsonModels[i].Parameters.Price;
                        cp.Income = jsonModels[i].Parameters.Income;

                        _db.CurrencyPurchases.Add(cp);
                        break;
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
