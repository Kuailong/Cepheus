using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Cepheus.Infrastructure
{
    public static class CriptoHelper
    {
        public static string CalculateMD5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static string CreateKey(string user, string password)
        {
            var preKey = string.Format("{0}::{1}::{0}", user, password);

            return CriptoHelper.CalculateMD5Hash(preKey);
        }
    }
}