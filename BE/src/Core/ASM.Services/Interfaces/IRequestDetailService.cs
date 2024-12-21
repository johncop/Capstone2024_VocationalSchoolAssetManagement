using ASM.Core.DTOs.Request;
using ASM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Services.Interfaces
{
    public interface IRequestDetailService
    {
        public Task<IList<RequestResponseDTO>> GetAllAsync(Expression<Func<Request, bool>>? filter = null,
            Expression<Func<Request, object>>? includeEntities = null, bool disableChangeTracker = true);
    }
}
