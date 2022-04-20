using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LibraryApp.Core.Singleton;
using LibraryApp.Model;

namespace LibraryApp.Controllers
{
    public class EmployeeViewModelController
    {
        private readonly string _serverLink;

        public EmployeeViewModelController()
        {
            _serverLink = ServerSingleton.GetServer();
        }

        public async Task<IEnumerable<Client>> GetClientList()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_serverLink + "/GetClientList");
            request.Headers["Authorization"] = $"Bearer {TokenSingleton.Token}";
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await JsonSerializer.DeserializeAsync<IEnumerable<Client>>(streamReader.BaseStream);

                if (result != null)
                {
                    return result;
                }
            }

            throw new OperationCanceledException();
        }
    }
}
