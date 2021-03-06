﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Web.Utils
{
    public class PasswordHasher
    {
        public HashResult HashNewSalt(string password, int saltLength, HashAlgorithm hashAlgo)
        {
            // Instanserer Random Number Generator (RNG)
            RNG rng = new RNG();
            string saltdata = rng.GenerateRandomCryptographicKey(saltLength);
            byte[] saltBytes = Encoding.UTF8.GetBytes(saltdata);
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);
            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());
            return new HashResult(Encoding.UTF8.GetString(saltBytes), Convert.ToBase64String(digestBytes));
        }

        public HashResult HashStoredSalt(string password, string salt, HashAlgorithm hashAlgo)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);
            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());
            return new HashResult(Encoding.UTF8.GetString(saltBytes), Convert.ToBase64String(digestBytes));
        }
    }
}
