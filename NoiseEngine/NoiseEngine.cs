using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;
using CubicNoise.Noisers;

namespace CubicNoise
{
    /// <summary>
    /// The main class of the library. You should use it to generate a noise engine. This class is thread-safe.
    /// You can use all methods from as many threads, as you want. There a no async methods, because the
    /// performance is very high. Even on a 2019 mid-size business laptop with Intel i5 CPU, each core
    /// is able to produce > 6 million values per second (2 dimensions).
    ///
    /// Not only the factory method is thread-safe. Each instance of the class is thread-safe as well.
    /// </summary>
    public sealed class NoiseEngine : INoiseEngine
    {
        private readonly INoiseEngine engine;

        private NoiseEngine(NoiseTypes type, int seed, IReadOnlyDictionary<IParameterName, int> intParameters)
        {
            this.engine = type switch
            {
                NoiseTypes.UNKNOWN => new RandomNumberEngine(seed),
                
                NoiseTypes.CUBIC_NOISE => new CubicNoiseEngine(seed, intParameters),
                
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "The provided noise type is unknown.")
            };
        }

        /// <summary>
        /// The factory method to use for generating a noise engine. This method is thread-safe. Call it from as many threads
        /// as you want.
        /// </summary>
        /// <param name="parameters">The parameters for the desired noise engine.</param>
        /// <returns>The desired noise engine instance.</returns>
        public static NoiseEngine Create(EngineParameters parameters) => new NoiseEngine(parameters.Type, parameters.Seed, parameters?.IntParameters);

        /// <summary>
        /// Yields a one-dimensional based noise value. This method is thread-safe as well. Call it from as
        /// many threads as you want. You can expect about 16 million calls per CPU core per second (year 2019).
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <returns>The corresponding noise value for the given coordinate.</returns>
        public float Get(float x) => this.engine.Get(x);

        /// <summary>
        /// Yields a two-dimensional based noise value. This method is thread-safe as well. Call it from as
        /// many threads as you want. You can expect about 6 million calls per CPU core per second (year 2019).
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The corresponding noise value for the given 2d coordinate.</returns>
        public float Get(float x, float y) => this.engine.Get(x, y);
    }
}
