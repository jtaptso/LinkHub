using LHBOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace LHDAL
{
    public interface ILHUserDb
    {
        IEnumerable<LHUser> GetAll();
        LHUser GetById(int id);
        bool Create(LHUser lHUser);
        bool Update(LHUser lHUser);
        bool Delete(int id);
    }
    public class LHUserDb : ILHUserDb
    {
        LHDbContext LHDbContext;

        public LHUserDb(LHDbContext _LHDbContext)
        {
            LHDbContext = _LHDbContext;
        }
        public bool Create(LHUser lHUser)
        {
            LHDbContext.Add(lHUser);
            LHDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var lHUser = LHDbContext.LHUsers.Find(id);
            LHDbContext.Remove<LHUser>(lHUser);
            LHDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<LHUser> GetAll()
        {
            return LHDbContext.LHUsers;
        }

        public LHUser GetById(int id)
        {
            return LHDbContext.LHUsers.Find(id);
        }

        public bool Update(LHUser lHUser)
        {
            LHDbContext.Update<LHUser>(lHUser);
            LHDbContext.SaveChanges();
            return true;
        }
    }
}
