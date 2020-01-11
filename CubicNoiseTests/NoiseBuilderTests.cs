using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise;
using CubicNoise.Builders;
using CubicNoise.Noisers;
using NUnit.Framework;

namespace CubicNoiseTests
{
    public class NoiseBuilderTests
    {
        [Test]
        public void SimpleBuild()
        {
            var engine = NoiseEngine.CreateEngine(NoiseBuilder.New().Type(NoiseTypes.CUBIC_NOISE).Seed("test seed").SetParam(Parameters.Cubic(CubicNoiseParameterKinds.Int.Use(CubicNoiseIntParameters.OCTAVE))))
        }
    }
}
