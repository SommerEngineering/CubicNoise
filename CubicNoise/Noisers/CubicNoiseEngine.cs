using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CubicNoise.Contracts;

namespace CubicNoise.Noisers
{
    public sealed class CubicNoiseEngine : INoiseEngine
    {
        private const int RANDOM_NUMBER_A =   134_775_813;
        private const int RANDOM_NUMBER_B = 1_103_515_245;

        private readonly int octave;
        private readonly int periodX;
        private readonly int periodY;
        private readonly int seed;

        public CubicNoiseEngine(int seed, IReadOnlyDictionary<IParameterName, int> intParameters)
        {
            this.seed = seed;
            this.octave = intParameters?.ContainsKey(CubicNoiseIntParameters.OCTAVE) == true ? intParameters[CubicNoiseIntParameters.OCTAVE] : 16;
            this.periodX = intParameters?.ContainsKey(CubicNoiseIntParameters.PERIOD_X) == true ? intParameters[CubicNoiseIntParameters.PERIOD_X] : 1_000;
            this.periodY = intParameters?.ContainsKey(CubicNoiseIntParameters.PERIOD_Y) == true ? intParameters[CubicNoiseIntParameters.PERIOD_Y] : 512;
        }

        public float Get(float x)
        {
            var xi = (int)Math.Floor(x / this.octave);
            var octaveXFactor = x / this.octave - xi;

            return Interpolation(
                       a: this.RandomNumberGenerator(x: DeterminePatch(xi - 1, this.periodX), y: 0),
                       b: this.RandomNumberGenerator(x: DeterminePatch(xi + 0, this.periodX), y: 0),
                       c: this.RandomNumberGenerator(x: DeterminePatch(xi + 1, this.periodX), y: 0),
                       d: this.RandomNumberGenerator(x: DeterminePatch(xi + 2, this.periodX), y: 0),
                       x: octaveXFactor) * 0.5f + 0.25f;
        }

        public float Get(float x, float y)
        {
            var xi = (int)Math.Floor(x / octave);
            var yi = (int)Math.Floor(y / octave);

            var octaveXFactor = x / octave - xi;
            var octaveYFactor = y / octave - yi;

            return Interpolation(
                       a: Interpolation(
                           a: this.RandomNumberGenerator(x: DeterminePatch(xi - 1, this.periodX), y: DeterminePatch(yi - 1 + 0, this.periodY)),
                           b: this.RandomNumberGenerator(x: DeterminePatch(xi + 0, this.periodX), y: DeterminePatch(yi - 1 + 0, this.periodY)),
                           c: this.RandomNumberGenerator(x: DeterminePatch(xi + 1, this.periodX), y: DeterminePatch(yi - 1 + 0, this.periodY)),
                           d: this.RandomNumberGenerator(x: DeterminePatch(xi + 2, this.periodX), y: DeterminePatch(yi - 1 + 0, this.periodY)),
                           x: octaveXFactor),

                       b: Interpolation(
                           a: this.RandomNumberGenerator(x: DeterminePatch(xi - 1, this.periodX), y: DeterminePatch(yi - 1 + 1, this.periodY)),
                           b: this.RandomNumberGenerator(x: DeterminePatch(xi + 0, this.periodX), y: DeterminePatch(yi - 1 + 1, this.periodY)),
                           c: this.RandomNumberGenerator(x: DeterminePatch(xi + 1, this.periodX), y: DeterminePatch(yi - 1 + 1, this.periodY)),
                           d: this.RandomNumberGenerator(x: DeterminePatch(xi + 2, this.periodX), y: DeterminePatch(yi - 1 + 1, this.periodY)),
                           x: octaveXFactor),

                       c: Interpolation(
                           a: this.RandomNumberGenerator(x: DeterminePatch(xi - 1, this.periodX), y: DeterminePatch(yi - 1 + 2, this.periodY)),
                           b: this.RandomNumberGenerator(x: DeterminePatch(xi + 0, this.periodX), y: DeterminePatch(yi - 1 + 2, this.periodY)),
                           c: this.RandomNumberGenerator(x: DeterminePatch(xi + 1, this.periodX), y: DeterminePatch(yi - 1 + 2, this.periodY)),
                           d: this.RandomNumberGenerator(x: DeterminePatch(xi + 2, this.periodX), y: DeterminePatch(yi - 1 + 2, this.periodY)),
                           x: octaveXFactor),

                       d: Interpolation(
                           a: this.RandomNumberGenerator(x: DeterminePatch(xi - 1, this.periodX), y: DeterminePatch(yi - 1 + 3, this.periodY)),
                           b: this.RandomNumberGenerator(x: DeterminePatch(xi + 0, this.periodX), y: DeterminePatch(yi - 1 + 3, this.periodY)),
                           c: this.RandomNumberGenerator(x: DeterminePatch(xi + 1, this.periodX), y: DeterminePatch(yi - 1 + 3, this.periodY)),
                           d: this.RandomNumberGenerator(x: DeterminePatch(xi + 2, this.periodX), y: DeterminePatch(yi - 1 + 3, this.periodY)),
                           x: octaveXFactor),

                       x: octaveYFactor) * 0.5f + 0.25f;
        }

        private float RandomNumberGenerator(int x, int y)
        {
            return (float)((((x ^ y) * RANDOM_NUMBER_A) ^ (this.seed + x)) * (((RANDOM_NUMBER_B * x) << 16) ^ (RANDOM_NUMBER_B * y) - RANDOM_NUMBER_A)) / int.MaxValue;
        }

        private static int DeterminePatch(int coordinate, int period)
        {
            return coordinate % period;
        }

        private static float Interpolation(float a, float b, float c, float d, float x)
        {
            var p = (d - c) - (a - b);
            return x * (x * (x * p + ((a - b) - p)) + (c - a)) + b;
        }
    }
}
