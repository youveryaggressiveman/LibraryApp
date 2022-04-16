using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryApp.Model.DataViewModel
{
    public class TokenModel
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}
