using System;
using System.Collections.Generic;
using System.Text;

namespace CubicNoise.Contracts
{
    public interface INoiseEngine
    {
        float Get(float x);

        float Get(float x, float y);
    }
}
