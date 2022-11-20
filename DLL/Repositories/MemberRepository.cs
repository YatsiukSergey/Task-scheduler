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
   public class MemberRepository:IRepository<Member>
    {
        protected Context _db { get; set; }
        public MemberRepository(Context context)
        {
            this._db = context;
        }
        public async Task<IEnumerable<Member>> GetList()
        {
           return  await _db.Members.ToListAsync();
        }

        public async  Task<Member> Get(int id)
        {
            return await _db.Members.FindAsync(id);
        }

        public async Task Create(Member member)
        {
            await _db.Members.AddAsync(member);
        }

        public async Task Update(Member member)
        {
            _db.Entry(member).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Member member = await _db.Members.FindAsync(id);
            if (member != null)
           _db.Members.Remove(member);
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
