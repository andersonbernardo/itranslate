using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FuseDeskApi.Models;
using FuseDeskApi.Repository;
using Newtonsoft.Json.Linq;

namespace FuseDeskApi.Application
{
    public class FuseDeskAppService : BaseApiRepository, IFuseDeskAppService
    {
        private static string _appName;        

        public async Task<IEnumerable<Ticket>> ObterTickets(ApiFilter filter)
        {
            _appName = filter.AppName;

            var _params = new Dictionary<string, string>
            {
                { "X-FuseDesk-API-Key", filter.ApiKey }
            };

            var parametros = new StringBuilder();

            var parameters = new List<KeyValuePair<string, object>>();

            if (filter.OpenAfterFilter.HasValue || filter.OpenBeforeFilter.HasValue)
            {
                dynamic open = new JObject();
                if (filter.OpenAfterFilter.HasValue)
                    open.after = filter.OpenAfterFilter.Value.ToString("yyyy-MM-dd");
                if (filter.OpenBeforeFilter.HasValue)
                    open.before = filter.OpenBeforeFilter.Value.ToString("yyyy-MM-dd");
                parameters.Add(new KeyValuePair<string, object>("date_opened", open.ToString()));
            };


            if (filter.ClosedAfterFilter.HasValue || filter.ClosedBeforeFilter.HasValue)
            {
                dynamic open = new JObject();
                if (filter.ClosedAfterFilter.HasValue)
                    open.after = filter.ClosedAfterFilter.Value.ToString("yyyy-MM-dd");
                if (filter.ClosedBeforeFilter.HasValue)
                    open.before = filter.ClosedBeforeFilter.Value.ToString("yyyy-MM-dd");
                parameters.Add(new KeyValuePair<string, object>("date_closed", open.ToString()));
            };


            if (!string.IsNullOrEmpty(filter.Status))
            {
                parameters.Add(new KeyValuePair<string, object>("status", filter.Status));
            }            
            
            parameters.Add(new KeyValuePair<string, object>("limit", filter.Limit));          


            var p = parameters.Aggregate(new StringBuilder(), (sb, x) => sb.Append(x.Key + "=" + x.Value + "&"), sb => sb.ToString(0, sb.Length - 1));

            return await GetAsUrlEncondeParamsAsync<IEnumerable<Ticket>>("api/v1/cases?"+ p, $"https://{_appName }.fusedesk.com/", _params);
        }
    }    
}
