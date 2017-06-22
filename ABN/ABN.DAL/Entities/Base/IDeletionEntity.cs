using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABN.DAL.Entities
{
    public interface IDeletionEntity : IModificationEntity
    {
        DateTime? DeletionTime { get; set; }
        bool IsDeleted { get; set; }
    }
}
