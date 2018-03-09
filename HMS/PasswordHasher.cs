using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace HMS
{
    public class PasswordHasher
    {
        public HashResult PasswordHash(string password, HashAlgorithm hashAlgo)
        {
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordBytes = new List<byte>();
            passwordBytes.AddRange(passwordAsBytes);
            byte[] digestBytes = hashAlgo.ComputeHash(passwordBytes.ToArray());
            return new HashResult(Convert.ToBase64String(digestBytes));
        }
    }
}
