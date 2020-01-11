using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Contracts;

namespace CubicNoise
{
    public sealed class EngineParameters
    {
        public int Seed { get; set; } = new Random().Next();

        public NoiseTypes Type { get; set; } = NoiseTypes.UNKNOWN;

        public Dictionary<IParameterName, int> IntParameters { get; set; }
    }
}
