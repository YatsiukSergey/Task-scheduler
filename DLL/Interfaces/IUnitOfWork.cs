using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Member> Members { get; }
        public IRepository<Assignment> Assignments  { get; }
        public  IRepository<Project> Projects { get; }
        public IRepository<Team> Teams { get; }
        Task Save();
    }

    
}
