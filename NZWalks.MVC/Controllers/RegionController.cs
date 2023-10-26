using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NZWalks.MVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.MVC.Controllers
{
    public class RegionController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7080/api");
        private readonly HttpClient _client;
        public RegionController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Region> regionsList = new List<Region>();
            HttpResponseMessage httpResponse = _client.GetAsync(_client.BaseAddress+ "/Region/GetAll").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                string data = httpResponse.Content.ReadAsStringAsync().Result;
                regionsList = JsonConvert.DeserializeObject<List<Region>>(data);
            }
            return View(regionsList);
        }
    }
}

