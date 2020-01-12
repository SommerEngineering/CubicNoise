using System;
using System.Collections.Generic;
using System.Text;
using NoiseEngine.Contracts;

namespace NoiseEngine.Noisers
{
    /// <summary>
    /// This is the random number engine which gets used in case that the UNKNOWN type was used.
    /// This engine is not meant for production. It is a placeholder for empty values, where a type
    /// is needed. The engine will generate a random value each time.
    /// </summary>
    internal sealed class RandomNumberEngine : INoiseEngine
    {
        private readonly Random rng;

        internal RandomNumberEngine(int seed)
        {
            this.rng = new Random(seed);
        }

        public float Get(float x)
        {
            return this.rng.Next();
        }

        public float Get(float x, float y)
        {
            return this.rng.Next();
        }
    }
}
