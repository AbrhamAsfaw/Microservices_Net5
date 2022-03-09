using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Inventory.Service.Dtos;

namespace Inventory.Service.Clients
{
    public class CatalogClient
    {
        private readonly HttpClient httpClient;
        public CatalogClient(HttpClient httpClient)
        {
        this.httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<CatalogItemDto>> GetCatalogItemDtosAsync()
        {
            var items = await httpClient.GetFromJsonAsync<IReadOnlyCollection<CatalogItemDto>>("/items");
            return items;
        }
    }

    
}