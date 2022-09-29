using proactivity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proactivity.Domain.Interfaces.Services
{
    public interface IActivityService
    {
        Task<Activity> AddActivity(Activity model);
        Task<Activity> UpdateActivity(Activity model); 
        Task<IEnumerable<Activity>> GetAllActivities(Activity model);
        Task<Activity> GetActivityById(int activityId);
        Task<bool> DeleteActivity(int activityId);

        Task<bool> DoneActivity(Activity model);


    }
}
