using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;
using CubicNoise.Noisers;

namespace CubicNoise
{
    public sealed class NoiseEngine : INoiseEngine
    {
        private readonly INoiseEngine engine;

        private NoiseEngine(NoiseTypes type, int seed, Dictionary<IParameterName, int> intParameters)
        {
            this.engine = type switch
            {
                NoiseTypes.UNKNOWN => new RandomNumberEngine(seed),
                
                NoiseTypes.CUBIC_NOISE => new CubicNoiseEngine(seed, intParameters),
                
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "The provided noise type is unknown.")
            };
        }

        public static NoiseEngine Create(EngineParameters parameters) => new NoiseEngine(parameters.Type, parameters.Seed, parameters?.IntParameters);

        public float Get(float x) => this.engine.Get(x);

        public float Get(float x, float y) => this.engine.Get(x, y);
    }
}
