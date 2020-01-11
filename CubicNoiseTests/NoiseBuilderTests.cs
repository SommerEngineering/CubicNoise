using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise;
using CubicNoise.Contracts;
using CubicNoise.Noisers;
using NUnit.Framework;

namespace CubicNoiseTests
{
    public class NoiseBuilderTests
    {
        [Test]
        public void StraightCreation()
        {
            var engine = NoiseEngine.Create(new EngineParameters
            {
                Seed = "test seed".GetHashCode(),
                Type = NoiseTypes.CUBIC_NOISE,
                IntParameters = new Dictionary<IParameterName, int>
                {
                    { CubicNoiseIntParameters.OCTAVE, 57 },
                    { CubicNoiseIntParameters.PERIOD_X, 12 },
                    { CubicNoiseIntParameters.PERIOD_Y, 16 },
                },
            });

            Assert.That(engine, Is.Not.Null);

            try
            {
                engine.Get(16f);
                engine.Get(16f, 18f);
            }
            catch
            {
                Assert.Fail("Noise engine seems not to be implemented.");
            }
        }

        [Test]
        public void NoParameters()
        {
            var engine = NoiseEngine.Create(new EngineParameters());

            Assert.That(engine, Is.Not.Null);

            try
            {
                engine.Get(16f);
                engine.Get(16f, 18f);
                Assert.That(true);
            }
            catch
            {
                Assert.Fail("Noise engine seems not to be implemented.");
            }
        }

        [Test]
        public void NullCheck()
        {
            try
            {
                var engine = NoiseEngine.Create(null);
                Assert.Fail("Null instead of parameters should not work.");
            }
            catch
            {
                Assert.That(true);
            }
        }

        [Test]
        public void PartialParameters()
        {
            var engine = NoiseEngine.Create(new EngineParameters
            {
                Seed = "test seed".GetHashCode(),
                Type = NoiseTypes.CUBIC_NOISE,
                IntParameters = new Dictionary<IParameterName, int>
                {
                    { CubicNoiseIntParameters.OCTAVE, 57 },
                    { CubicNoiseIntParameters.PERIOD_X, 12 },
                    //{ CubicNoiseIntParameters.PERIOD_Y, 16 }, // is missing!
                },
            });

            Assert.That(engine, Is.Not.Null);

            try
            {
                engine.Get(16f);
                engine.Get(16f, 18f);
            }
            catch
            {
                Assert.Fail("Noise engine seems not to be implemented.");
            }
        }
    }
}
