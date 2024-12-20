using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHarbuz.Domain.Entities
{
    public abstract class Entity<IPrimaryKey>
    {
        public IPrimaryKey Id { get; set; }
    }
    public abstract class Entity : Entity<int>
    {
    }
}
