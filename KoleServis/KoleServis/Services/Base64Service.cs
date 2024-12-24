using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoleServis.Services
{
    public class Base64Service
    {

        public Base64Service() { }

        public string ConvertPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }
        public string ConvertBase64(string password)
        {
            byte[] bytes = Convert.FromBase64String(password);
            return Encoding.UTF8.GetString(bytes);
        }


    }
}
