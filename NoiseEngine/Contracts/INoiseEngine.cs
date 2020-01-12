using System;
using System.Collections.Generic;
using System.Text;

namespace CubicNoise.Contracts
{
    /// <summary>
    /// An interface which each noise generator must implement.
    /// </summary>
    public interface INoiseEngine
    {
        /// <summary>
        /// Producing a one-dimensional based noise value.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <returns>The noise value.</returns>
        float Get(float x);

        /// <summary>
        /// Produces a two-dimensional based noise value.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The noise value.</returns>
        float Get(float x, float y);
    }
}
