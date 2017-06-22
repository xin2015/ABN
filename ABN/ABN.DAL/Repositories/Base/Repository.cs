using ABN.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;

namespace ABN.DAL.Repositories
{
    public class Repository<TEntity> where TEntity : IEntity
    {
        protected OpenAccessContext Context { get; set; }

        public Repository(OpenAccessContext context)
        {
            Context = context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Context.GetAll<TEntity>();
        }
    }
}
