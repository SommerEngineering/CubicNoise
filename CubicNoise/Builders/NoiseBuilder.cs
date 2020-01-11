using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;

namespace CubicNoise.Builders
{
    public sealed class NoiseBuilder
    {
        public NoiseTypes NoiseType { get; set; } = NoiseTypes.UNKNOWN;

        public int NoiseSeed { get; set; } = new Random().Next();

        public Dictionary<IParameterName, int> NoiseIntParameters = new Dictionary<IParameterName, int>();

        private NoiseBuilder()
        {
        }

        public static NoiseBuilder New()
        {
            return new NoiseBuilder();
        }

        public NoiseBuilder Type(NoiseTypes type)
        {
            this.NoiseType = type;
            return this;
        }

        public NoiseBuilder Seed(int seed)
        {
            this.NoiseSeed = seed;
            return this;
        }

        public NoiseBuilder Seed(string seed)
        {
            this.NoiseSeed = seed.GetHashCode();
            return this;
        }

        public NoiseBuilder SetParam(IParameterName param, int value)
        {
            this.NoiseIntParameters[param] = value;
            return this;
        }
    }
}
