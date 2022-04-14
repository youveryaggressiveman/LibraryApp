using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LibraryApp.Core;
using LibraryApp.Model;

namespace LibraryApp.Controllers
{
    public class AuthController
    {
        private string _serverLink;

        public AuthController()
        {
            _serverLink = ServerSingleton.GetServer();
        }

        public async Task<User> GetUserByLoginAndPassword(string login, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var stringTask = await client.GetAsync(_serverLink);

                if (stringTask.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonSerializer.Deserialize<User>(await stringTask.Content.ReadAsStringAsync());

                    return result;
                }
            }

            throw new OperationCanceledException();
        }
    }
}
