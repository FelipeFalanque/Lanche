using ApplicationCore.Domain.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Domain.Interfaces.Repositories
{
    public interface ILancheRepository : IRepository<Lanche>
    {
        IEnumerable<Lanche> GetAllEager();
    }
}
