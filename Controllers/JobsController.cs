﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TecolocoClient.Models;
using System.Net.Http.Formatting;

namespace TecolocoClient.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        private static string url="https://localhost:44398/";
        public ActionResult Index()
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(url);
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
            clientHttp.BaseAddress = new Uri(url);
            var request = clientHttp.GetAsync("api/Jobs?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var job = JsonConvert.DeserializeObject<Jobs>(resultString);
                return View(job);
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateJob()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateJob(Jobs job)
        {
            if (ModelState.IsValid)
            {
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri(url);
                var request = clientHttp.PostAsync("api/Jobs", job, new JsonMediaTypeFormatter()).Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var IsOk = JsonConvert.DeserializeObject<bool>(resultString);
                    if (IsOk)
                    {
                        return RedirectToAction("Index");
                    }
                    return View(job);
                }
            }
            return View(job);
        }
        [HttpGet]
        public ActionResult UpdateJob(string id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(url);
            var request = clientHttp.GetAsync("api/Jobs?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var job = JsonConvert.DeserializeObject<Jobs>(resultString);
                return View(job);
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateJob(Jobs job)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(url);
            var request = clientHttp.PutAsync("api/Jobs", job, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var IsOk = JsonConvert.DeserializeObject<bool>(resultString);
                if (IsOk)
                {
                    return RedirectToAction("Index");
                }
                return View(job);

            }
            return View(job);
        }
        [HttpGet]
        public ActionResult DeleteJob(string id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri(url);
            var request = clientHttp.DeleteAsync("api/Jobs?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var IsOk = JsonConvert.DeserializeObject<bool>(resultString);
                if (IsOk)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}