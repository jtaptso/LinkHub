using LHBOL;
using LHDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace LHBLL
{
    public interface ILHUrlBs
    {
        IEnumerable<LHUrl> GetAll();
        LHUrl GetById(int id);
        bool Create(LHUrl lHUrl);
        bool Update(LHUrl lHUrl);
        bool Delete(int id);
        IEnumerable<LHUrl> GetAll(bool IsApproved);
    }
    public class LHUrlBs : ILHUrlBs
    {
        ILHUrlDb LHUrlDb;
        public LHUrlBs(ILHUrlDb _LHUrlDb)
        {
            LHUrlDb = _LHUrlDb;
        }
        public bool Create(LHUrl lHUrl)
        {
            return LHUrlDb.Create(lHUrl);
        }

        public IEnumerable<LHUrl> GetAll()
        {
            return LHUrlDb.GetAll();
        }

        public LHUrl GetById(int id)
        {
            return LHUrlDb.GetById(id);
        }

        public bool Update(LHUrl lHUrl)
        {
            return LHUrlDb.Update(lHUrl);
        }
        public bool Delete(int id)
        {
            return LHUrlDb.Delete(id);
        }

        public IEnumerable<LHUrl> GetAll(bool IsApproved)
        {
            return LHUrlDb.GetAll(IsApproved);
        }
    }
}
