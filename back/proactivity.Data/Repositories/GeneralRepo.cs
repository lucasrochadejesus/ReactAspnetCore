using proactivity.Data.Context;
using proactivity.Domain.Interfaces.Repositories; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proactivity.Data.Repositories
{
    public class GeneralRepo : IBaseRepo
    {

        private readonly DataContext _ctx;

        public GeneralRepo(DataContext ctx)
        {
            _ctx = ctx;
        }
        public void Add<T>(T entity) where T : class
        {
            _ctx.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _ctx.Remove(entity);
        }

        public async Task<bool> SaveChangesAssync()
        {
            
            return (await _ctx.SaveChangesAsync()) > 0;

        }

        public void Update<T>(T entity) where T : class
        {
            _ctx.Update(entity);
        }

    }
}
