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
    public class ProjectRepository : IRepository<Project>
    {
        protected Context _db { get; set; }
        public ProjectRepository(Context context)
        {
            this._db = context;
        }
        public async Task<IEnumerable<Project>> GetList()
        {
            return await _db.Projects.ToListAsync();
        }

        public async Task<Project> Get(int id)
        {
            return await _db.Projects.FindAsync(id);
        }

        public async Task Create(Project project)
        {
           await  _db.Projects.AddAsync(project);
        }

        public async Task Update(Project project)
        {
           _db.Entry(project).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Project project = await _db.Projects.FindAsync(id);
            if (project != null)
                _db.Projects.Remove(project);
            await _db.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
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
