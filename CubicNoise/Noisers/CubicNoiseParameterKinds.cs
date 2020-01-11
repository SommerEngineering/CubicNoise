using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using CubicNoise.Builders;
using CubicNoise.Contracts;

namespace CubicNoise.Noisers
{
    public sealed class CubicNoiseParameterKinds
    {
        private CubicNoiseParameterKinds()
        {
        }

        public static CubicNoiseParameterKinds Int { get; } = new CubicNoiseParameterKinds();

        public IParameterName Use(CubicNoiseIntParameters name) => name;
    }
}
