using ABN.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;

namespace ABN.DAL.Repositories
{
    public class DeletionRepository<TEntity> : ModificationRepository<TEntity> where TEntity : IDeletionEntity
    {
        public DeletionRepository(OpenAccessContext context) : base(context)
        {
        }

        public override IQueryable<TEntity> GetAll()
        {
            return base.GetAll().Where(o => !o.IsDeleted);
        }

        public virtual void Delete(TEntity entity)
        {
            entity.DeletionTime = DateTime.Now;
            entity.IsDeleted = true;
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Delete(entity);
            }
        }
    }
}
