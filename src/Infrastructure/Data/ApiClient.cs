using System.Net.Http;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Infrastructure.Data
{
    public class ApiClient<T> : IApiClient<T>
    {
        protected readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> Get(T entity)
        {
            //TODO add code
            throw new NotImplementedException();
        }

        public async Task<T> Post(T entity)
        {
            //TODO add code
            throw new NotImplementedException();
        }

        public async Task<T> Put(T entity)
        {
            //TODO add code
            throw new NotImplementedException();
        }

        public async Task<T> Patch(T entity)
        {
            //TODO add code
            throw new NotImplementedException();
        }

        public async Task<T> Delete(T entity)
        {
            //TODO add code
            throw new NotImplementedException();
        }
    }
}