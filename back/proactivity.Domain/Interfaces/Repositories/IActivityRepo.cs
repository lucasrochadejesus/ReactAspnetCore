using proactivity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proactivity.Domain.Interfaces.Repositories
{
    public interface IActivityRepo : IBaseRepo
    {
        Task<IEnumerable<Activity>> GetAllActivities();
        Task<Activity> GetActivityById(int id);
        Task<Activity> GetActivityByTitle(string title);
    }
}
