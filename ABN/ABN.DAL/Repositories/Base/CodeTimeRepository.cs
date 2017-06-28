using ABN.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;

namespace ABN.DAL.Repositories
{
    public class CodeTimeRepository<TEntity> : Repository<TEntity> where TEntity : IEntity, ICodeTime
    {
        public CodeTimeRepository(OpenAccessContext context) : base(context)
        {
        }

        public bool Contain(string code, DateTime time)
        {
            return GetAll().Any(o => o.Code == code && o.Time == time);
        }

        public bool Contain(DateTime time)
        {
            return GetAll().Any(o => o.Time == time);
        }
    }
}
