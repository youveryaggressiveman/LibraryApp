using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Controllers;
using LibraryApp.View.Windows;

namespace LibraryApp.Core.Helper
{
    public class AuthHelper
    {
        private readonly AuthController _controller;

        public AuthHelper()
        {
            _controller = new AuthController();
        }

        public async Task<bool> AuthHelp(string login, string password)
        {
            try
            {
                var user = await _controller.GetUserByLoginAndPassword(login, password);

                if (user == null)
                {
                    return false;
                }

                if (user.Login == login && user.Password == password)
                {
                    UserSingleton.User = user;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
        }
    }
}
