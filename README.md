# About this library
This library implements noise generators. Currently only the cubic noise generator is implemented. In the future, however, further algorithms might be added as required.

# .NET Core 3.1 LTS+ only
This library was implemented especially for .NET Core 3.1 and newer. It is therefore not available for .NET Standard 2.x or the outdated .NET Framework. This design decision was made based on the following background: (a) The .NET Framework will not be further developed (cf. https://devblogs.microsoft.com/dotnet/net-core-is-the-future-of-net/); (b) as of .NET 5.0, the .NET Standard is no longer expected to be required because Mono and the .NET Core will be merged together into the new .NET 5 (cf. https://devblogs.microsoft.com/dotnet/introducing-net-5/).

# Acknowledgments
I thank Job Talle for his cubic noise algorithm. In [his article](https://jobtalle.com/cubic_noise.html) you can read more about the algorithm and its properties. My implementation is based on [the implementation of Job](https://github.com/jobtalle/CubicNoise).

# Citation
The library can also be cited in scientific works, for example as follows:

*Sommer, Thorsten (2020): NoiseEngine. Github: https://github.com/SommerEngineering/NoiseEngine, DOI: [doi.org/10.5281/zenodo.3605398](https://doi.org/10.5281/zenodo.3605398)*

# License
This library uses the BSD 3-clause license.