using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;

namespace CubicNoise
{
    /// <summary>
    /// This class stores all parameters needed to create a noise engine instance.
    /// </summary>
    public sealed class EngineParameters
    {
        /// <summary>
        /// The engine's seed value. To use a string value as seed, use the GetDeterministicHashCode() method
        /// which gets provided by this library. A different seed value results in a complete different result.
        /// When you generate e.g. a landscape, two different seeds will produce different landscapes.
        /// </summary>
        public int Seed { get; set; } = new Random().Next();

        /// <summary>
        /// The desired kind of noise generator.
        /// </summary>
        public NoiseTypes Type { get; set; } = NoiseTypes.UNKNOWN;

        /// <summary>
        /// A dictionary of additional parameters needed by the chosen noise generator.
        /// </summary>
        public IReadOnlyDictionary<IParameterName, int> IntParameters { get; set; }
    }
}
