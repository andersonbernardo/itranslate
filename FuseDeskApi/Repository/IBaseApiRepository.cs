using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuseDeskApi.Repository
{
    public interface IBaseApiRepository
    {   

        Task<TEntity> GetAsUrlEncondeParamsAsync<TEntity>(string endpoint, string host, Dictionary<string, string> headers);      
    }
}
