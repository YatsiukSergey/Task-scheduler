using DAL.DBContext;
using DAL.Models;
using DLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class TeamRepository: IRepository<Team>
    {
        protected Context _db { get; set; }
        public TeamRepository(Context context)
        {
            this._db = context;
        }
        public async Task<IEnumerable<Team>> GetList()
        {
            return await _db.Teams.ToListAsync();
        }

        public async Task<Team> Get(int id)
        {
            return await _db.Teams.FindAsync(id);
        }

        public async Task Create(Team team)
        {
           await  _db.Teams.AddAsync(team);
        }

        public async Task Update(Team team)
        {
            _db.Entry(team).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Team team = await _db.Teams.FindAsync(id);
            if (team != null)
             _db.Teams.Remove(team);
           await  _db.SaveChangesAsync();
        }

        public async Task Save()
        {
          await   _db.SaveChangesAsync();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
