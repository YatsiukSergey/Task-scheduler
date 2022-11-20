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
   public class AssignmentRepository : IRepository<Assignment>
    {
        protected Context _db { get; set; }
        public AssignmentRepository(Context context)
        {
            this._db = context;
        }
        public async Task <IEnumerable<Assignment>> GetList()
        {
           return await _db.Assignments.ToListAsync();
        }

        public async Task<Assignment> Get(int id)
        {
            return await _db.Assignments.FindAsync(id);
        }

        public async Task Create(Assignment assignment)
        {
             await _db.Assignments.AddAsync(assignment);
        }

        public async Task Update(Assignment assignment)
        {

            _db.Entry(assignment).State =  EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
             Assignment assignment = await _db.Assignments.FindAsync(id);
            if (assignment != null)
            _db.Assignments.Remove(assignment);
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
