using System;
using System.Security.Cryptography;

namespace Pong__Open_Classroom_
{
    public class CryptoRandom : RandomNumberGenerator
    {
        private static RandomNumberGenerator r;

        public override void GetNonZeroBytes(byte[] data)
        {
            r.GetNonZeroBytes(data);
        }

        public CryptoRandom()
        {
            r = RandomNumberGenerator.Create();
        }

        public override void GetBytes(byte[] buffer)
        {
            r.GetBytes(buffer);
        }

        public double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double) BitConverter.ToUInt32(b, 0)/UInt32.MaxValue;
        }

        public int Next(int minValue, int maxValue)
        {
            long range = (long) maxValue - minValue;
            return (int)((long)Math.Floor(NextDouble() * range) + minValue);
        }

        public int Next()
        {
            return Next(0, Int32.MaxValue);
        }

        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }
}