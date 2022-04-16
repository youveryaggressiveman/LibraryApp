using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Singleton
{
    public static class ServerSingleton
    {
        private static string _server = "http://localhost:4502";

        public static string GetServer()
            => _server;
    }
}
