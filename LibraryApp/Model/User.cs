using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Model
{
    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле для ввода логина не может быть пустым")]
        [MaxLength(50, ErrorMessage = "Логин не может превышать более 50 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле для ввода пароля не может быть пустым")]
        [MaxLength(50, ErrorMessage = "Пароль не может превышать более 50 символов")]
        public string Password { get; set; }

        public User(){}

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
