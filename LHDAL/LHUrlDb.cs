using LHBOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHDAL
{
    public interface ILHUrlDb
    {
        IEnumerable<LHUrl> GetAll();
        LHUrl GetById(int id);
        bool Create(LHUrl lHUrl);
        bool Update(LHUrl lHUrl);
        bool Delete(int id);
        IEnumerable<LHUrl> GetAll(bool isApproved);
    }
    public class LHUrlDb : ILHUrlDb
    {
        LHDbContext LHDbContext;

        public LHUrlDb(LHDbContext _LHDbContext)
        {
            LHDbContext = _LHDbContext;
        }
        public bool Create(LHUrl lHUrl)
        {
            LHDbContext.Add(lHUrl);
            LHDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var lHUrl = LHDbContext.LHUrls.Find(id);
            LHDbContext.Remove<LHUrl>(lHUrl);
            LHDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<LHUrl> GetAll()
        {
            return LHDbContext.LHUrls;
        }

        public IEnumerable<LHUrl> GetAll(bool isApproved)
        {
            var urls = LHDbContext.LHUrls.Where(x => x.IsApproved == isApproved)
                                         .Include(x => x.Category)
                                         .Include(x => x.LHUser);
            return urls;
        }

        public LHUrl GetById(int id)
        {
            return LHDbContext.LHUrls.Find(id);
        }

        public bool Update(LHUrl lHUrl)
        {
            LHDbContext.Update<LHUrl>(lHUrl);
            LHDbContext.SaveChanges();
            return true;
        }
    }
}
