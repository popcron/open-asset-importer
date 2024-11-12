using System;

namespace OpenAssetImporter;

[Flags]
public enum ImporterFeatureFlags
{
    SupportsText = 1,
    SupportsBinary = 2,
    SupportsCompressed = 4,
    LimitedSupport = 8,
    Experimental = 16
}