using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorAppDataSource1.Shared;
using DataSourceRazorLibrary1;

namespace BlazorAppDataSource1.Client.Service
{
    public class StudentiService<TSearch, TViewModel> : BaseService<TSearch, TViewModel>
    {
        private HttpClient client;

        public StudentiService(HttpClient http)
        {
            client = http;
        }

        public override async Task<ResultData<TViewModel>> FetchData(string url, TSearch search, int page, 
                           int pagesize, string orderbycolumn, string orderbydirection)
        {
            string param = CreateQueryString(search, page, pagesize, orderbycolumn, orderbydirection);
            return await client.GetFromJsonAsync<ResultData<TViewModel>>($"{url}?{param}");
        }

        public async Task InsertStudente(StudentiViewModel studente)
        {
            string url = $"Studenti/InsertStudente";
            HttpResponseMessage response = await client.PostAsJsonAsync(url, studente);
        }

        public async Task UpdateStudente(StudentiViewModel studente)
        {
            string url = $"Studenti/UpdateStudente";
            HttpResponseMessage response = await client.PostAsJsonAsync(url, studente);
        }

        public async Task DeleteStudente(int id)
        {
            string url = $"Studenti/DeleteStudente?id={id}";
            string response = await client.GetStringAsync(url);
        }
    }  
}
