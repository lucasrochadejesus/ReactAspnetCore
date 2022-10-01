using proactivity.Domain.Entities;
using proactivity.Domain.Interfaces.Repositories;
using proactivity.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proactivity.Domain.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepo _activityRepo;

        public ActivityService(IActivityRepo activityRepo)
        {
            _activityRepo = activityRepo;
        }

        public async Task<Activity> AddActivity(Activity model)
        {
            if (await _activityRepo.GetActivityById(model.Id) == null)
            {
                _activityRepo.Add(model);
                if (await _activityRepo.SaveChangesAssync())
                    return model;

            }
            return null;
        }

        public async Task<Activity> UpdateActivity(Activity model)
        {
            if (await _activityRepo.GetActivityById(model.Id) != null)
            {
                _activityRepo.Update(model);
                if (await _activityRepo.SaveChangesAssync())
                    return model;

            }

            return null;
        }
         
        public async Task<bool> DeleteActivity(int activityId)
        {
            var activity = await _activityRepo.GetActivityById(activityId);
            if (activity == null) throw new Exception("Id not exists.");

            _activityRepo.Delete(activity);

            return await _activityRepo.SaveChangesAssync();

        }

        public async Task<bool> DoneActivity(Activity model)
        {
            if (model != null)
            {
                model.Conclusion();
                _activityRepo.Update<Activity>(model);
                return await _activityRepo.SaveChangesAssync();
            }
            return false;

        }

        public async Task<Activity> GetActivityById(int activityId)
        {
            try
            {
                var activity = await _activityRepo.GetActivityById(activityId);
                if (activity != null) 
                { 
                    return activity; 
                }
                return null;
                 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Activity>> GetAllActivities()
        {
            try
            {

                var activities = await _activityRepo.GetAllActivities();
                
                if (activities == null) return null;

                return activities;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           

        }


    }
}
