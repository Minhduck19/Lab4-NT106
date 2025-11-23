using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Bai6
{
    public class UserApiService
    {
        private readonly string apiUrl = "https://nt106.uitiot.vn/api/v1/user/me";

        public async Task<UserInfoModel> GetUserAsync(string tokenType, string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);

                var resp = await client.GetAsync(apiUrl);
                var json = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                {
                    string detail = JObject.Parse(json)["detail"]?.ToString();
                    throw new HttpRequestException(detail);
                }

                var data = JObject.Parse(json);

                return new UserInfoModel
                {
                    Username = data["username"]?.ToString(),
                    Fullname = data["fullname"]?.ToString(),
                    Email = data["email"]?.ToString()
                };
            }
        }
    }
}
