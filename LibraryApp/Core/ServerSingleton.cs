using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core
{
    public static class ServerSingleton
    {
        private static string _server = "";

        public static string GetServer()
            => _server;
    }
}
