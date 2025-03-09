using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Domain.Helpers
{
    /// <summary>
    /// Classe auxiliar para realizar criptografia padrão MD5
    /// </summary>
    public class MD5Helper
    {
        public static string Encrypt(string value)
        {
            using (MD5 md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(value);
                var hashBytes = md5.ComputeHash(inputBytes); //criptografia

                var stringBuilder = new StringBuilder();

                foreach(var item in hashBytes)
                {
                    stringBuilder.Append(item.ToString("x2")); //hexadecimal
                }

                return stringBuilder.ToString();
            }
        }
    }

}
