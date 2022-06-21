using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proactivity.API.Models;
using proactivity.API.Repository;

namespace proactivity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
       // private readonly ILogger<ActivityController> _logger;
        private readonly DataContext _context;
        

        public ActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _context.Activities;
        }

        [HttpGet("{id}")]
        public Activity getById(int id)
        {
            return _context.Activities.FirstOrDefault(Act => Act.Id == id);
        }

        [HttpPost]
        public IEnumerable<Activity> Post(Activity activity)
        {
            _context.Activities.Add(activity);
            if(_context.SaveChanges() > 0)
            {
                return _context.Activities;
            } else 
            {
                throw new Exception("Activity not included");
            }
        }

        [HttpPut("{id}")]
        public Activity Put(int id, Activity activity)
        {
            if (activity.Id != id) throw new Exception("Update wrong activity");

            _context.Update(activity);
            if (_context.SaveChanges() > 0)
            {
                return _context.Activities.FirstOrDefault(act => act.Id == id);
            }
            else
            {
                  return new Activity();
            }

        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var activity = _context.Activities.FirstOrDefault(act => act.Id == id);
            if(activity == null) throw new Exception("Activity doesnt exists");

            _context.Remove(activity);
            return _context.SaveChanges() > 0;
        }


     
       

    }
}