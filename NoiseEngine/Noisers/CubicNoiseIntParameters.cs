using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;

namespace CubicNoise.Noisers
{
    /// <summary>
    /// This class contains all known cubic noise's parameters.
    /// </summary>
    public class CubicNoiseIntParameters : IParameterName
    {
        /// <summary>
        /// Cubic noise's octave parameter.
        /// </summary>
        public static readonly IParameterName OCTAVE = new CubicNoiseIntParameters();

        /// <summary>
        /// Cubic noise's period x parameter.
        /// </summary>
        public static readonly IParameterName PERIOD_X = new CubicNoiseIntParameters();

        /// <summary>
        /// Cubic noise's period y parameter.
        /// </summary>
        public static readonly IParameterName PERIOD_Y = new CubicNoiseIntParameters();

        private CubicNoiseIntParameters()
        {
        }
    }
}
