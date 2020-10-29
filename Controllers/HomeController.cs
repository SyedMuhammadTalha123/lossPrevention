using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Loss_Prevention.Models;
using IronWebScraper;

namespace Loss_Prevention.Controllers
{
    
    public class HomeController : Controller
    {
        private static int UserID;
        private readonly ILogger<HomeController> _logger;
        public LossPreventionDB _context;
        static List<String> AllTablesNamesR;
        static List<string[,]> TablesRefinedValuesR;

        public HomeController(ILogger<HomeController> logger, LossPreventionDB context)
        {
            _logger = logger;
            _context = context;
            AllTablesNamesR = null;
            TablesRefinedValuesR = null;
        }
        //userlogin
        public IActionResult Index(Login user)
        {
            if (user.Email == null)
                return RedirectToAction("Login");
            else
            {
                ViewBag.Email = user.Email;
                List<String> AllTablesNames = new List<string>();
                List<string[,]> TablesRefinedValues = new List<string[,]>();
                var scraper = new BlogScraper();
                scraper.Start();

                // TablesRefinedValuesR This contains all tables and their values
                // AllTablesNamesR This contains names

                if (AllTablesNamesR != null && TablesRefinedValuesR != null)
                {
                    ViewBag.Tables = TablesRefinedValuesR;
                    ViewBag.TablesName = AllTablesNamesR;
                    TablesRefinedValuesR = null;
                    AllTablesNamesR = null;
                    return View();

                }
                else
                {
                    return View();
                }
            }
        }
        public IActionResult History()
        {
            var UserData = _context.SignUp.ToList();
            ViewBag.Records = UserData;
            return View();
           
        }
        //adminlogin

      
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult AdminPortal()
        {
            return View();
        }
        public IActionResult Adminlivestock()
        {
            List<String> AllTablesNames = new List<string>();
            List<string[,]> TablesRefinedValues = new List<string[,]>();
            var scraper = new BlogScraper();
            scraper.Start();

            // TablesRefinedValuesR This contains all tables and their values
            // AllTablesNamesR This contains names

            if (AllTablesNamesR != null && TablesRefinedValuesR != null)
            {
                ViewBag.Tables = TablesRefinedValuesR;
                ViewBag.TablesName = AllTablesNamesR;
                TablesRefinedValuesR = null;
                AllTablesNamesR = null;
                return View();

            }
            else
            {
                return View();
            }

        }
        public IActionResult Aboutus()
        {
            
            
             return View(); 
           
          
        }
        public IActionResult Adminhistory(int id)
        {
            var data = _context.Selldata.Where(x=>x.userID == id).ToList(); 
            ViewBag.DBData = data;
    
            return View();
        }
        public IActionResult Purchasehistory(int id)
        {
            var data = _context.Buys.Where(x => x.userID == id).ToList();
            ViewBag.DBData = data;

            return View();
        }
        public IActionResult selldata(Login user)
        {
            
                
                    var data = _context.Buys.Where(x => x.userID == UserID).ToList();
                    ViewBag.DBData = data;
                    return View();
                
            
        }
        //user signup
        public ActionResult RegisterUser(Register user)
            {
            SignUp signUp = new SignUp();
            signUp.Email = user.Email;
            signUp.FName = user.FName;
            signUp.LName = user.LName;
            signUp.Password = user.Password;
            signUp.isAdmin = "false";
            signUp.Active = "true";
            _context.SignUp.Add(signUp);
            _context.SaveChanges();
            return View("Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult LoginUser(Login user)
        {
            var Email = user.Email;
            var Password = user.Password;
            var UserData = _context.SignUp.ToList();
            foreach (var data in UserData) {
                if (Email == data.Email && Password == data.Password && data.isAdmin == "false" && data.Active == "true")
                {
                    UserID = data.ID;
                    return RedirectToAction("Index", user);
                }
            }
            return RedirectToAction("Login");
        }
        public ActionResult AdminAction(int actionid,int id)
        {
            var rows = _context.SignUp.ToList();
            SignUp row = null;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].ID == id)
                {
                    row = rows[i];
                    break;
                }
            }
            if (actionid == 1)
            {
                if (row.isAdmin == "true")
                    row.isAdmin = "false";
                else
                    row.isAdmin = "true";
                _context.SignUp.Update(row);
            }
            if (actionid == 2)
            {
                if (row.Active == "true")
                    row.Active = "false";
                else
                    row.Active = "true";
                _context.SignUp.Update(row);
            }
            if (actionid == 3)
            {
                _context.SignUp.Remove(row);
            }
            _context.SaveChanges();
            return RedirectToAction("IndexAdmin");
        }
        public ActionResult AdminUser(Login user)
        {
            var Email = user.Email;
            var Password = user.Password;
            var UserData = _context.SignUp.ToList();
            foreach (var data in UserData)
            {
                if (Email == data.Email && Password == data.Password && data.isAdmin == "true" && data.Active == "true")
                {
                    UserID = data.ID;
                    return RedirectToAction("IndexAdmin");
                }
            }
            return RedirectToAction("AdminPortal");
        }
        public IActionResult IndexAdmin()
        {
            var UserData = _context.SignUp.ToList();
            ViewBag.Records = UserData;
            return View();
        }
      
        [HttpGet]
        public IActionResult Buystock(String? name,Double? value, int? ID, int? rowID)

            {
            ViewBag.Name = name;
            ViewBag.Value = value;
            ViewBag.ID = ID;
            ViewBag.rowID = rowID;
            return View();
            }
        
        public IActionResult Sellstock(string? Amount, double? Purchased ,int ID, int rowID)
        {
            ViewBag.Amount = Amount;
            ViewBag.Purchased = Purchased;
            ViewBag.rowID = rowID;
            ViewBag.ID = ID;
            List<String> AllTablesNames = new List<string>();
            List<string[,]> TablesRefinedValues = new List<string[,]>();
            var scraper = new BlogScraper();
            scraper.Start();

            // TablesRefinedValuesR This contains all tables and their values
            // AllTablesNamesR This contains names
            // Now do whatever with the data
            if (AllTablesNamesR != null && TablesRefinedValuesR != null)
            {
                ViewBag.Tables = TablesRefinedValuesR;
                ViewBag.TablesName = AllTablesNamesR;
                TablesRefinedValuesR = null;
                AllTablesNamesR = null;
                return View();

            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Test()

        { 
            List<String> AllTablesNames = new List<string>();
            List<string[,]> TablesRefinedValues = new List<string[,]>();
            var scraper = new BlogScraper();
            scraper.Start();

            // TablesRefinedValuesR This contains all tables and their values
            // AllTablesNamesR This contains names
            // Now do whatever with the data
            if (AllTablesNamesR != null && TablesRefinedValuesR != null)
            {
                ViewBag.Tables = TablesRefinedValuesR;
                ViewBag.TablesName = AllTablesNamesR;
                TablesRefinedValuesR = null;
                AllTablesNamesR = null;
                return View();

            }
            else
            {
                return View();
            }
        }
        public IActionResult Managestock()
        {
            return View();
        }
        public ActionResult Buystocks(Buy users )
        {
            
           
                Buy buystock = new Buy();
                buystock.Quantity = users.Quantity;
                buystock.Date = users.Date;
                buystock.Purchased = users.Purchased;
                buystock.Amount = users.Amount;
                buystock.userID = UserID;
                buystock.rowID = users.rowID;
                _context.Buys.Add(buystock);
                _context.SaveChanges();
                return RedirectToAction("Test");
            
          
        }
        //sell data method
        public ActionResult Sellstocks(Sell user)
        {
            var rows = _context.Buys.ToList();
            Buy row = null;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].ID == user.SID)
                {
                    row = rows[i];
                    break;
                }
            }

            Sell sellstock = new Sell();
            sellstock.AvailableQuantity = user.AvailableQuantity;
            sellstock.PurchasedCost = user.PurchasedCost;
            sellstock.QuantitySell = user.QuantitySell;
            sellstock.SellingCost = user.SellingCost;
            sellstock.userID = UserID;
            _context.Selldata.Add(sellstock);
            _context.SaveChanges();
            row.Purchased = row.Purchased - user.QuantitySell;
            _context.Buys.Update(row);
            _context.SaveChanges();
            return RedirectToAction("selldata");
        }
        class BlogScraper : WebScraper
        {
            public override void Init()
            {
                this.LoggingLevel = WebScraper.LogLevel.All;
                this.Request("https://www.psx.com.pk/market-summary/", Parse);
            }
            public override void Parse(Response response)
            {
                List<String> AllTables = new List<string>();
                List<String> AllTablesNames = new List<string>();
                String data = "";
                var tables = response.TextContent.Split("table-responsive");
                for (int i = 2; i < tables.Length; i++)
                {
                    var tableName = tables[i].Substring(tables[i].IndexOf("<h4>") + 5, tables[i].IndexOf("</h4>") - tables[i].IndexOf("<h4>") - 5);
                    AllTablesNames.Add(tableName);
                    var rawRows = tables[i].Split("</tr>");
                    for (int j = 1; j < rawRows.Length; j++)
                    {
                        var rawRowData = rawRows[j].Split("</td>");
                        for (int k = 0; k < rawRowData.Length - 1; k++)
                        {
                            data = data + "@U@" + rawRowData[k].Substring(rawRowData[k].IndexOf("<td>") + 4);
                        }
                        data = data + "@LB@";
                    }
                    AllTables.Add(data);
                    data = "";
                }
                List<string[,]> TablesRefinedValues = new List<string[,]>();
                string[,] table;
                for (int i = 0; i < AllTables.Count; i++)
                {
                    var tableAllRows = AllTables[i].Split("@LB@");
                    tableAllRows = tableAllRows.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    var firstRow = tableAllRows[0].Split("@U@");
                    firstRow = firstRow.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    table = new string[tableAllRows.Length, firstRow.Length];
                    for (int j = 0; j < tableAllRows.Length; j++)
                    {
                        var items = tableAllRows[j].Split("@U@");
                        items = items.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        for (int k = 0; k < items.Length; k++)
                        {
                            if (items[k].Contains("</span>"))
                                items[k] = items[k].Substring(items[k].IndexOf("</span> ") + 8);
                            table[j, k] = items[k];
                        }
                    }
                    TablesRefinedValues.Add(table);
                }
                AllTablesNamesR = AllTablesNames;
                TablesRefinedValuesR = TablesRefinedValues;
            }
        }
    }
}
