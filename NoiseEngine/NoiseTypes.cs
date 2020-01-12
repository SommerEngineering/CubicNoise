using System;
using System.Collections.Generic;
using System.Text;

namespace NoiseEngine
{
    /// <summary>
    /// All implemented noise generators.
    /// </summary>
    public enum NoiseTypes
    {
        /// <summary>
        /// The UNKNOWN generator is a placeholder for empty values. You should not use it in production. It generates random numbers on every call.
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        /// This is the cubic noise generator by Job Talle, cf. https://jobtalle.com/cubic_noise.html and https://github.com/jobtalle.
        /// </summary>
        CUBIC_NOISE = 1_000,
    }
}
