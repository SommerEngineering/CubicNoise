using System;
using System.Collections.Generic;
using System.Text;
using CubicNoise.Noisers;

namespace CubicNoise.Builders
{
    public sealed class Parameters
    {
        private Parameters()
        {
        }

        public static CubicNoiseParameterKinds Cubic(CubicNoiseParameterKinds kind)
        {
            return kind;
        }
    }
}
