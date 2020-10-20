using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TecolocoClient.Models;

namespace TecolocoClient.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index()
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44398/");
            var request = clientHttp.GetAsync("api/Jobs").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Jobs>>(resultString);
                return View(list);
            }

            return View();
        }
        [HttpGet]
        public ActionResult DetailJob(string id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44398/");
            var request = clientHttp.GetAsync("api/Jobs?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var job = JsonConvert.DeserializeObject<Jobs>(resultString);
                return View(job);
            }
            return View();
        }
    }
}