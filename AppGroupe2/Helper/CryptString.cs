using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Helper
{
    public static class CryptString
    {
        public static string GetMd5Hash(string input)
        {
            StringBuilder sBuilder = new StringBuilder();

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));


                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("d3"));
                }

            }
            return sBuilder.ToString();

        }

///* <summary>
/// methofe de verification
/// </summary>
/// <param name="input">chaine a crypter</param>
/// <param name="hash">chaine crypter</param>
/// <returns>true si egale</returns>
        public static bool VerifyMd5Hash(string input, string hash )
        {

            string hasOfInput = GetMd5Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (comparer.Compare(hasOfInput, hash) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}