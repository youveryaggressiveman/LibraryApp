using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Core.Singleton;
using LibraryApp.Model;

namespace LibraryApp.Controllers
{
    public class MainViewModelController
    {
        private readonly string _serverLink;

        public MainViewModelController()
        {
            _serverLink = ServerSingleton.GetServer();
        }

        public async Task<User> GetUser()
        {
            throw new OperationCanceledException();
        }
    }
}
