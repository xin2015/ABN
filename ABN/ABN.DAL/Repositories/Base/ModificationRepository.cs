using ABN.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;

namespace ABN.DAL.Repositories
{
    public class ModificationRepository<TEntity> : CreationRepository<TEntity> where TEntity : IModificationEntity
    {
        public ModificationRepository(OpenAccessContext context) : base(context)
        {
        }


        public virtual void Update(TEntity entity)
        {
            entity.LastModificationTime = DateTime.Now;
        }
    }
}
