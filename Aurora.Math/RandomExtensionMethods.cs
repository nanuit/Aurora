using System;

namespace Aurora.Math
{
    public static class RandomExtensionMethods
    {
        /// <summary>
        /// Returns a random long from min (inclusive) to max (exclusive)
        /// </summary>
        /// <param name="random">The given random instance</param>
        /// <param name="min">The inclusive minimum bound</param>
        /// <param name="max">The exclusive maximum bound.  Must be greater than min</param>
        public static ulong NextLong(this Random random, ulong min, ulong max)
        {
            if (max < min)
                throw new ArgumentOutOfRangeException("max", "max must be >= min!");
            else if (max == min)
                return max;

            //Working with ulong so that modulo works correctly with values > long.MaxValue
            ulong uRange = (ulong)(max - min);

            //Prevent a modolo bias; see https://stackoverflow.com/a/10984975/238419
            //for more information.
            //In the worst case, the expected number of calls is 2 (though usually it's
            //much closer to 1) so this loop doesn't really hurt performance at all.
            ulong ulongRand;
            do
            {
                byte[] buf = new byte[8];
                random.NextBytes(buf);
                ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
            } while (ulongRand > ulong.MaxValue - (ulong.MaxValue % uRange + 1) % uRange);

            return ulongRand % uRange + min;
        }

        /// <summary>
        /// Returns a random long from 0 (inclusive) to max (exclusive)
        /// </summary>
        /// <param name="random">The given random instance</param>
        /// <param name="max">The exclusive maximum bound.  Must be greater than 0</param>
        public static ulong NextLong(this Random random, ulong max)
        {
            return random.NextLong(0, max);
        }

        /// <summary>
        /// Returns a random long over all possible values of long (except long.MaxValue, similar to
        /// random.Next())
        /// </summary>
        /// <param name="random">The given random instance</param>
        public static ulong NextLong(this Random random)
        {
            return random.NextLong(ulong.MinValue, ulong.MaxValue);
        }
        /// <summary>
        /// returns a random string filed with character from A-Z, 0-9 and a-z
        /// </summary>
        /// <param name="random">Random class</param>
        /// <param name="length">length of the string to generate</param>
        /// <returns>generated string with random alphanumeric characters</returns>
        public static string AlphaNumeric(this Random random, int length)
        {
            byte[] byteBuffer = new byte[length];
            for (int charCounter = 0; charCounter < length; charCounter++)
            {
                byte[] variant = new byte[3];
                lock (random)
                    variant[0] = (byte)random.Next(0x41, 0x5A);  // A-Z
                lock (random)
                    variant[1] = (byte)random.Next(0x30, 0x39);  // 0-9
                lock (random)
                    variant[2] = (byte)random.Next(0x61, 0x7A);  // a-z

                lock (random)
                    byteBuffer[charCounter] = variant[random.Next(0, variant.Length - 1)];

            }
            return System.Text.Encoding.Default.GetString(byteBuffer);
        }
        /// <summary>
        /// returns a random string filed with character from A-Z and a-z
        /// </summary>
        /// <param name="random">Random class</param>
        /// <param name="length">length of the string to generate</param>
        /// <returns>generated string with random alphabetic characters</returns>
        public static string Alphabet(this Random random, int length)
        {
            byte[] byteBuffer = new byte[length];
            for (int charCounter = 0; charCounter < length; charCounter++)
            {
                byte[] variant = new byte[2];
                lock (random)
                    variant[0] = (byte)random.Next(0x41, 0x5A);  // A-Z
                lock (random)
                    variant[1] = (byte)random.Next(0x61, 0x7A);  // a-z

                lock (random)
                    byteBuffer[charCounter] = variant[random.Next(0, variant.Length - 1)];

            }
            return System.Text.Encoding.Default.GetString(byteBuffer);
        }
    }

}
