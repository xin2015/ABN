using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABN.DAL.Entities
{
    public interface IModificationEntity : ICreationEntity
    {
        DateTime? LastModificationTime { get; }
    }
}
