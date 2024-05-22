using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidGunFinal.Services
{
    public class LoginClass
    {
        public LoginClass(string pass, string login)
        {
            this.pass = pass;
            this.login = login;
        }

        public string pass { get; set; }
        public string login { get; set; }
    }


}
