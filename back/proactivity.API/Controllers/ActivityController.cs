using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proactivity.API.Models;
using proactivity.API.Repository;

namespace proactivity.API.Controllers
{
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly DataContext _ctx;
        

        public ActivityController(DataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _ctx.Activities;
        }

        [HttpGet("{id}")]
        public Activity getById(int id)
        {
            return _ctx.Activities.FirstOrDefault(Act => Act.Id == id);
        }

        [HttpPost]
        public IEnumerable<Activity> Post(Activity activity)
        { 
            _ctx.Activities.Add(activity);
            if(_ctx.SaveChanges() > 0)
            {
                return _ctx.Activities;
            } else 
            {
                throw new Exception("Activity not included");
            }
        }

        [HttpPut("{id}")]
        public Activity Put(int id, Activity activity)
        {
            if(activity.Id != id) throw new Exception("Update wrong activity");
            
            _ctx.Update(activity);
            if(_ctx.SaveChanges() > 0)
            {
                return _ctx.Activities.FirstOrDefault(act => act.Id == id);
            } else {
                return new Activity();
            }
            
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var activity = _ctx.Activities.FirstOrDefault(act => act.Id == id);
            if(activity == null) throw new Exception("Activity doesnt exists");

            _ctx.Remove(activity);
            return _ctx.SaveChanges() > 0;
        }


     
       

    }
}