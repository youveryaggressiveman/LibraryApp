using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Controllers;
using LibraryApp.Core.Singleton;
using LibraryApp.Model;
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

        public async Task<bool> AuthHelp(User user)
        {
            try
            {
                var verifiedUser = await _controller.GetUserByLoginAndPassword(user);

                if (user == null)
                {
                    return false;
                }

                if (verifiedUser.Login == user.Login && verifiedUser.Password == user.Password)
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
