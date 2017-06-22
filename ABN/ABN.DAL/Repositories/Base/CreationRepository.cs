using ABN.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;

namespace ABN.DAL.Repositories
{
    public class CreationRepository<TEntity> : Repository<TEntity> where TEntity : ICreationEntity
    {
        public CreationRepository(OpenAccessContext context) : base(context)
        {
        }

        public virtual void Add(TEntity entity)
        {
            entity.CreationTime = DateTime.Now;
            Context.Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Add(entity);
            }
        }
    }
}
