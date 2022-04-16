using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LibraryApp.Core;
using LibraryApp.Core.Singleton;
using LibraryApp.Model;
using LibraryApp.Model.DataViewModel;
using LibraryApp.Model.DataVIewModel;

namespace LibraryApp.Controllers
{
    public class AuthController
    {
        private readonly string _serverLink;

        public AuthController()
        {
            _serverLink = ServerSingleton.GetServer();
        }

        public async Task<bool> Authorize(AuthorizeUser authorizeUser)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(_serverLink + "/token?login=" + authorizeUser.Login +
                                                                        "&password=" + authorizeUser.Password +
                                                                        "&roleID=" + authorizeUser.RoleID);
            request.Method = "POST";
            //request.Headers["Authorization"] = $"Bearer {TokenSingleton.Token}";
            request.Accept = "application/json";
            request.ContentType = "application/json";

            var result = JsonSerializer.Serialize<AuthorizeUser>(authorizeUser);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
               await streamWriter.WriteAsync(result);
            }

            var response = (HttpWebResponse)await request.GetResponseAsync();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var parsedResult = await JsonSerializer.DeserializeAsync<TokenModel>(streamReader.BaseStream);

                if (parsedResult != null)
                {
                    TokenSingleton.Token = parsedResult.Token;

                    return true;
                }
            }

            return false;
        }

        public async Task<User> GetUserByLoginAndPassword(User user)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_serverLink + "/GetUserByLoginAndPassword?login=" + user.Login +
                                                                       "&password=" + user.Password);
            request.Accept = "application/json";

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await JsonSerializer.DeserializeAsync<User>(streamReader.BaseStream);

                if (result != null)
                {
                    return result;
                }
            }

            throw new OperationCanceledException();
        }
    }
}
