using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using proactivity.Domain.Entities;
using proactivity.Domain.Interfaces.Services;

namespace proactivity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        // private readonly ILogger<ActivityController> _logger;
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            try
            {
                var activities = await _activityService.GetAllActivities();

                return Ok(activities);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"error get activity by Id {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var activity = await _activityService.GetActivityById(id);
               
                if(activity == null) { return NoContent(); };
                
                return Ok(activity);


            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"error get activity by Id + {id} + {ex.Message}");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Post (Activity model)
        {
            try
            {
                var activity = await _activityService.AddActivity(model);
                if(activity == null) { return NoContent(); }

                return Ok(activity);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"error to Post Activity + {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Activity model)
        {
            try
            {
                var activityTask = await _activityService.GetActivityById(id);
                
                if (activityTask == null) { return NoContent(); }

                var activity = await _activityService.UpdateActivity(model);
                 
                return Ok(activity);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"error to Update Activity + {ex.Message}");
            }
         

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var activity = _activityService.GetActivityById(id);
            
                if(activity == null) return NotFound();

                if (activity != null) await _activityService.DeleteActivity(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"error to Delete Activity + {ex.Message}");
            }
          
        }





    }
}