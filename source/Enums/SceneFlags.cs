using System;

namespace OpenAssetImporter;

[Flags]
public enum SceneFlags
{
    None = 0,
    Incomplete = 1,
    Validated = 2,
    ValidationWarning = 4,
    NonVerboseFormat = 8,
    Terrain = 16,
    AllowShared = 32
}
