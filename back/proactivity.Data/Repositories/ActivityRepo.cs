using Microsoft.EntityFrameworkCore;
using proactivity.Data.Context;
using proactivity.Domain.Entities;
using proactivity.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proactivity.Data.Repositories
{
    public class ActivityRepo : GeneralRepo, IActivityRepo
    {
         
        private readonly DataContext _ctx;
        public ActivityRepo(DataContext context) : base(context)
        {
            _ctx = context;
        }

        public async Task<Activity> GetActivityById(int id)
        {
           
            IQueryable<Activity> query = _ctx.Activities;
         
            query = query
                    .AsNoTracking() //AsNoTracking to not lock table
                    .OrderBy(a => a.Id)
                    .Where(a => a.Id == id);
          
            return await  query.FirstOrDefaultAsync();

        }

        public async Task<Activity> GetActivityByTitle(string title)
        {
            
            IQueryable<Activity> query = _ctx.Activities;

            query = query
                    .AsNoTracking()
                    .Where(t => t.Title == title);

            return await query.FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Activity>> GetAllActivities()
        {

            IQueryable<Activity> query = _ctx.Activities;

            query = query.AsNoTracking()
                    .OrderBy(a => a.Id);

            return await query.ToArrayAsync();

        }

      
    }
}
