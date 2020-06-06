using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucPham.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private WebApiDbContext dbContext;

        public WebApiDbContext Init()
        {
            return dbContext ?? (dbContext = new WebApiDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}