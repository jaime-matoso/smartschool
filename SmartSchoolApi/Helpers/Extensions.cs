using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmartschoolApi.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, int CurrentPage, int ItemsPerPage, int TotalItems, int TotalPage)
        {
            var paginationHeader = new PaginationHeader(CurrentPage, ItemsPerPage, TotalItems, TotalPage);

            var CamelCaseFormatter = new JsonSerializerSettings();
            CamelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, CamelCaseFormatter)); 
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");

        }
    }
}
