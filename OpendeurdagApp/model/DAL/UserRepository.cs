using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Model.DAL
{
    public static class UserRepository
    {
        public static async Task<bool> login(string email, string wachtwoord)
        {
            return email == "admin@hogent.be" && wachtwoord == "admin";
        }

        public static void loguit()
        {
            IsLoggedIn = false;
        }
        public static bool IsLoggedIn { get; set; }
    }
}
