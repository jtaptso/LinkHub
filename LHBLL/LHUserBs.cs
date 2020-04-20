using LHBOL;
using LHDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace LHBLL
{
    public interface ILHUserBs
    {
        IEnumerable<LHUser> GetAll();
        LHUser GetById(int id);
        bool Create(LHUser lHUser);
        bool Update(LHUser lHUser);
        bool Delete(int id);
    }
    public class LHUserBs : ILHUserBs
    {
        ILHUserDb LHUserDb;
        public LHUserBs(ILHUserDb _LHUserDb)
        {
            LHUserDb = _LHUserDb;
        }
        public bool Create(LHUser lHUser)
        {
            return LHUserDb.Create(lHUser);
        }

        public IEnumerable<LHUser> GetAll()
        {
            return LHUserDb.GetAll();
        }

        public LHUser GetById(int id)
        {
            return LHUserDb.GetById(id);
        }

        public bool Update(LHUser lHUser)
        {
            return LHUserDb.Update(lHUser);
        }

        public bool Delete(int id)
        {
            return LHUserDb.Delete(id);
        }
    }
}
