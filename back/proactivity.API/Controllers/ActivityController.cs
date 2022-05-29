using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proactivity.API.Models;

namespace proactivity.API.Controllers
{
    [Route("[controller]")]
    public class ActivityController : Controller
    {
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(ILogger<ActivityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string get()
        {
            return "";
        }

        [HttpGet("{id}")]
        public string getById(int id)
        {
            return $"Controller get method id test {id}";
        }

        [HttpPost]
        public Activity Post(Activity activity)
        {
            // activity.Id = 1;
            return activity;
        }

        [HttpPut("{id}")]
        public Activity Put(int id, Activity activity)
        {

            return activity;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Controller delete method test {id}";
        }

    // Created automatic and commented
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //      return View("Error!");
    //    }
    }
}