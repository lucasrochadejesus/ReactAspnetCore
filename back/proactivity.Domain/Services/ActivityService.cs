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

        public Task<Activity> DeleteActivity(Activity model)
        {
            throw new NotImplementedException();
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

        public Task<Activity> GetActivityById(int activityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Activity>> GetAllActivities(Activity model)
        {
            throw new NotImplementedException();
        }


    }
}
