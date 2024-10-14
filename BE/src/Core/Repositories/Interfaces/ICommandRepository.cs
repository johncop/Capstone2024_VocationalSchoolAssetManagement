using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Repositories.Interfaces
{
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        void Add(params TEntity[] entities);
        void Update(params TEntity[] entities);
        void Delete(params TEntity[] entities);
    }
}
