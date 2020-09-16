using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AgileEngineSite.Models;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using System.Transactions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace AgileEngineSite.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
      
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> History()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(
                    "https://localhost:44336/api/Transaction");
                var content = await response.Content.ReadAsStringAsync();
                List<TransactionResponse> lista = JsonConvert.DeserializeObject<List<TransactionResponse>>(content);

                return View("History",lista);
            }
        }

        public async Task<JsonResult> GenerateTransaction(decimal ammount ,int type)
        {
            if(type > 0)
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject( new TransactionRequest() { Type = type, Amount = ammount });
                    var response = await client.PostAsync(
                        "https://localhost:44336/api/Transaction",
                         new StringContent(json, Encoding.UTF8, "application/json"));
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        return Json(new {result = true});
                    }
                    else
                    {
                        return Json(new { result = false });
                    }
                }
            }
            return null;
        }

  
    }
}
