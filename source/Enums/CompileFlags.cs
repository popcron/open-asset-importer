using System;

namespace OpenAssetImporter;

[Flags]
public enum CompileFlags
{
    Shared = 1,
    STLport = 2,
    Debug = 4,
    NoBoost = 8,
    SingleThreaded = 16
}
