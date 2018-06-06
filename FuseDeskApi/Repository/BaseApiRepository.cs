using FuseDeskApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FuseDeskApi.Repository
{
    public class BaseApiRepository : IBaseApiRepository
    {        
        public async Task<TEntity> GetAsUrlEncondeParamsAsync<TEntity>(string endpoint, string host, Dictionary<string, string> headers)
        {

            using (var _client = CreateClientWithHearders(endpoint, host, headers))
            {
                var response = await _client.GetAsync(endpoint).ConfigureAwait(false);
                return await TratarRequisicao<TEntity>(response);

            }
        }

       
        private static async Task<TRetorno> TratarRequisicao<TRetorno>(HttpResponseMessage requisicao)
        {
            if (!requisicao.IsSuccessStatusCode)
                throw new Exception("Erro na Fusedesk: " + requisicao.RequestMessage);            

            var conteudo = await requisicao.Content.ReadAsStringAsync();

            if (conteudo.Trim().StartsWith("<div"))
            {
                throw new Exception("Erro na Fusedesk: " + conteudo.Substring(0, conteudo.IndexOf("[{")));                
            }            
            
            //if (!string.IsNullOrEmpty(error.error) && !string.IsNullOrEmpty(error.errorcode))
            //{
            //    throw new Exception("Erro na Fusedesk: " + conteudo);
            //}

            return JsonConvert.DeserializeObject<TRetorno>(conteudo);           
        }

        #region CLIENTS
        private static HttpClient CreateClientWithHearders(string url, string host, Dictionary<string, string> headers)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var _UserAgent = "d-fens HttpClient";
            client.DefaultRequestHeaders.Add("User-Agent", _UserAgent);

            foreach (var value in headers)
            {
                client.DefaultRequestHeaders.Add(value.Key, value.Value);
            }

            return client;
        }

        private static HttpClient CreateClientWithAuthentication(string url, string host, string authHeader, string type)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(type, authHeader);

            return client;
        }

        private static HttpClient CreateClientSemAuthentication(string url, string host)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        #endregion

    }
}
