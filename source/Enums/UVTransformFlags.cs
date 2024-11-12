using System;

namespace OpenAssetImporter;

[Flags]
public enum UVTransformFlags
{
    Scaling = 1,
    Rotation = 2,
    Translation = 4
}