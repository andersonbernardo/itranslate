using FuseDeskApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuseDeskApi.Application
{
    public interface IFuseDeskAppService
    {
        Task<IEnumerable<Ticket>> ObterTickets(ApiFilter filter);
    }
}