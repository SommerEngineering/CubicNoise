using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Noisers;

namespace CubicNoise
{
    /// <summary>
    /// Extension methods for this library.
    /// </summary>
    public static class Extensions
    {
        // 
        /// <summary>
        /// This is a deterministic hash function for strings. The official hash methods in .NET Core are no longer
        /// deterministic due to possible hashing attacks, cf. https://youtu.be/R2Cq3CLI6H8.
        ///
        /// The source for this implementation: https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/.
        /// Thanks Andrew for providing such a hash function.
        ///
        /// Aware: Never use this hash function for any security-related task or for any hashtable storage, etc.
        /// 
        /// Please use it only in the case, that you really need a deterministic value. In the context of this
        /// library, the hash values are usually used for media, games, art, or simulations in order to share
        /// results with others. This is the only valid use case!
        /// </summary>
        /// <param name="str">The string for which a hash value is to be computed.</param>
        /// <returns>A deterministic 32 bit / 4 byte hash value of the given string.</returns>
        public static int GetDeterministicHashCode(this string str)
        {
            unchecked
            {
                var hash1 = (5381 << 16) + 5381;
                var hash2 = hash1;

                for (var i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;

                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }
    }
}
