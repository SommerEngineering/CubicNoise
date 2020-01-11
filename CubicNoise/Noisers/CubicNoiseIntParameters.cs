using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;

namespace CubicNoise.Noisers
{
    public class CubicNoiseIntParameters : IParameterName
    {
        public static readonly IParameterName OCTAVE = new CubicNoiseIntParameters();
        public static readonly IParameterName PERIOD_X = new CubicNoiseIntParameters();
        public static readonly IParameterName PERIOD_Y = new CubicNoiseIntParameters();

        private CubicNoiseIntParameters()
        {
        }
    }
}
