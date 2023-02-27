using System.Diagnostics;
using System.Numerics;

namespace SchnorrModel
{
    public partial class Form1
    {
        // Utility function to store prime factors of a number
        static void FindPrimefactors(HashSet<BigInteger> s, BigInteger n)
        {
            while (n.IsEven)
            {
                n /= 2;
                if (!n.IsEven)
                {
                    s.Add(2);
                    break;
                }
            }
            // n must be odd, so we can skip even element
            for (BigInteger i = 3; i <= (BigInteger)Math.Exp(BigInteger.Log(n) / 2); i += 2)
            {
                // While i divides n, print i and divide n
                while (n % i == 0)
                {
                    var temp = i;
                    s.Add(temp);
                    n /= i;
                }
                if (i >= max)
                {
                    break;
                }
            }
            if (n > 2) s.Add(n);
        }
        static BigInteger FindPrimitive(BigInteger n)
        {
            HashSet<BigInteger> s = new();
            var phi = n - 1;

            // Find prime factors of phi and store in a set
            FindPrimefactors(s, phi);

            // Check for every number from 2 to phi
            for (BigInteger r = 2; r <= phi; r++)
            {
                // Iterate through all prime factors of phi and check if we found a power with value 1
                bool flag = false;
                foreach (BigInteger a in s)
                {
                    // Check if r^((phi)/primefactors) mod n is 1 or not
                    if (BigInteger.ModPow(r, phi / a, n) == 1)
                    {
                        flag = true;
                        break;
                    }
                }
                // If there was no power with value 1.
                if (flag == false)
                {
                    //return r; // Function to find smallest primitive root of n
                    list.Add(r);
                    if(list.Count >= max)
                    {
                        break;
                    }
                }
            }
            return -1;
        }
        public static BigInteger TryModInverse(BigInteger number, BigInteger modulo)
        {
            while (number < 1) number += modulo;
            //if (modulo < 2) throw new ArgumentOutOfRangeException(nameof(modulo));
            BigInteger n = number;
            BigInteger m = modulo, v = 0, d = 1;
            while (n > 0)
            {
                BigInteger t = m / n, x = n;
                n = m % x;
                m = x;
                x = d;
                d = checked(v - t * x); // Just in case
                v = x;
            }
            BigInteger result = v % modulo;
            if (result < 0) result += modulo;
            if (number * result % modulo == 1) return result;
            return 0;
        }
        static Tuple<BigInteger, BigInteger> P(string py, string ar, string im)
        {
            string arg = string.Format(py, ar, im);
            Process pro = new()
            {
                StartInfo = new ProcessStartInfo(@"C:/Users/Tuanminh1910/AppData/Local/Microsoft/WindowsApps/python3.10.exe", arg)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            pro.Start();
            string[] output = pro.StandardOutput.ReadToEnd().Split(" ");
            pro.WaitForExit();
            var q = BigInteger.Parse(output[0]);
            var p = BigInteger.Parse(output[1]);
            return Tuple.Create(p, q);
        }
    }
    public static class PrimeExtensions
    {
        private static readonly ThreadLocal<Random> s_Gen = new(() => new Random());

        // Random generator (thread safe)
        private static Random? Gen => s_Gen.Value;

        public static bool IsProbablyPrime(this BigInteger value, int witnesses = 10)
        {
            if (value <= 1)
                return false;

            if (witnesses <= 0)
                witnesses = 10;

            BigInteger d = value - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            byte[] bytes = new byte[value.GetByteCount()];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    Gen?.NextBytes(bytes);

                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);
                    if (x == 1) return false;
                    if (x == value - 1) break;
                }

                if (x != value - 1) return false;
            }
            return true;
        }
    }
}
