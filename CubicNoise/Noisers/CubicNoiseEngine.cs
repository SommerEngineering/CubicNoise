using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;

namespace CubicNoise.Noisers
{
    public sealed class CubicNoiseEngine : INoiseEngine
    {
        private Dictionary<IParameterName, int> intParameters;
        private int seed;

        public CubicNoiseEngine(int seed, Dictionary<IParameterName, int> intParameters)
        {
            this.intParameters = intParameters;
            this.seed = seed;
        }

        public float Get(float x)
        {
            throw new NotImplementedException();
        }

        public float Get(float x, float y)
        {
            throw new NotImplementedException();
        }
    }
}
