using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;

namespace CubicNoise.Noisers
{
    public sealed class RandomNumberEngine : INoiseEngine
    {
        private Random rng;

        public RandomNumberEngine(int seed)
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
