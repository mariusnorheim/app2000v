using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class HashResult
    {
        public string Salt
        {
            get;
        }

        public string Digest
        {
            get;
            set;
        }

        public HashResult(string salt, string digest)
        {
            Salt = salt;
            Digest = digest;
        }
    }
}
