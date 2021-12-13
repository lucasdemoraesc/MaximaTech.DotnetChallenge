using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.DotnetChallenge.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected StringContent GetContent(object data)
        {
            return new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializeResponseObject<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();

            T data = JsonSerializer.Deserialize<T>(
                json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return data;
        }
    }
}
