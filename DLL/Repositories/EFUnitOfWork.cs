using DAL.DBContext;
using DAL.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
        
    {
        protected Context _db;
        protected AssignmentRepository assignmentRepository;
        protected MemberRepository memberRepository;
        protected ProjectRepository projectRepository;
        protected TeamRepository teamRepository;
        public EFUnitOfWork()
        {
            _db = new Context();
        }

        public IRepository<Assignment> Assignments
        {
            get
            {
                if (assignmentRepository == null)
                    assignmentRepository = new AssignmentRepository(_db);
                return assignmentRepository;
            }
        }

        public IRepository<Member> Members
        {
            get
            {
                if (memberRepository == null)
                    memberRepository = new MemberRepository(_db);
                return memberRepository;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(_db);
                return projectRepository;
            }
        }

        public IRepository<Team> Teams
        {
            get
            {
                if(teamRepository == null)
                   teamRepository = new TeamRepository(_db);
                return teamRepository;
            }
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
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
